using System.IO;
using Models;
using SchedulerServices.Builders;
using SchedulerServices.Parsers;
using SchedulerServices.Validators;
using static System.Decimal;

namespace SchedulerServices
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class YahooFinanceClient : IFinanceClient, IDisposable
    {
        private readonly IQueryStringBuilder _queryStringBuilder;
        private readonly IValidator _validator;
        private readonly IFinanceParser _financeParser;
        private readonly HttpClient _httpClient;
        private Uri _baseAddress;

        public Uri BaseAddress  
        {
            get { return _baseAddress; }
            set { _baseAddress = value;  }
        }
            
        public YahooFinanceClient(IQueryStringBuilder queryStringBuilder, IValidator validator, IFinanceParser financeParser)
        {
            _queryStringBuilder = queryStringBuilder;
            _validator = validator;
            _financeParser = financeParser;

            _baseAddress = new Uri("http://real-chart.finance.yahoo.com"); // TODO: get from config
            _httpClient = new HttpClient();
        }

        private HttpClient GetHttpClient()
        {
            _httpClient.BaseAddress = _baseAddress;

            return _httpClient;
        }

        public async Task<Price> Get(string epicCode, DateTime dateTime)
        {
            var price = new Price();

            try
            {
                var queryString = _queryStringBuilder.BuildQueryString(epicCode, dateTime);
                using (var response = await GetHttpClient().GetAsync(queryString))
                using (var content = response.Content)
                {
                    var stream = await content.ReadAsStreamAsync();
                    using (var streamReader = new StreamReader(stream))
                    {
                        int lineNumber = 0;
                        string line = "";
                        while ((line = streamReader.ReadLine()) != null)
                        {
                            var splitLine = line.Split(',');
                                
                            if (lineNumber > 0)
                            {
                                price = _financeParser.Parse(line, epicCode);
                            }
                            else
                            {
                                if (!_validator.CheckHeaders(splitLine).IsValid)
                                {
                                    throw new ApplicationException("Expecting columns in the following order: Date,Open,High,Low,Close,Volume,Adj Close");
                                }
                            }

                            lineNumber++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // TODO: logging  
                throw new ApplicationException("Problem calling yahoo finance", ex);
            }

            return price;
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}
