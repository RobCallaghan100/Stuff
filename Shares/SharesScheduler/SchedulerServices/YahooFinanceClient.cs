using System.Diagnostics;
using System.IO;
using Models;
using SchedulerServices.Builders;
using static System.Decimal;

namespace SchedulerServices
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class YahooFinanceClient : IFinanceClient, IDisposable
    {
        private readonly IQueryStringBuilder _queryStringBuilder;
        private readonly HttpClient _httpClient;
        private Uri _baseAddress;

        public Uri BaseAddress  
        {
            get { return _baseAddress; }
            set { _baseAddress = value;  }
        }
            
        public YahooFinanceClient(IQueryStringBuilder queryStringBuilder)
        {
            _queryStringBuilder = queryStringBuilder;

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
                            // TODO: validate that column headers are correct

                            if (lineNumber > 0)
                            {
                                // TODO: another reason to change, imagine if new columns or the order of column changed - put in new class (PriceParser)
                                var splitLine = line.Split(',');
                                var splitEpicCode = epicCode.Split('.');

                                price.Epic = epicCode;
                                price.Date = DateTime.Parse(splitLine[0]);
                                price.Open = Parse(splitLine[1]);
                                price.High = Parse(splitLine[2]);
                                price.Low = Parse(splitLine[3]);
                                price.Close = Parse(splitLine[4]);
                                price.Volume = Parse(splitLine[5]);
                                price.AdjustedClose = Parse(splitLine[6]);

                                if (splitEpicCode.Length >= 1)
                                {
                                    price.Market = splitEpicCode[1];
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
