using System.Diagnostics;
using System.IO;
using Models;
using static System.Decimal;

namespace SchedulerServices
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class YahooFinanceClient : IFinanceClient, IDisposable
    {
        private readonly HttpClient _httpClient;

        public YahooFinanceClient()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://real-chart.finance.yahoo.com")
            };
        }

        public async Task<Price> Get(string epicCode, DateTime dateTime)
        {
            var price = new Price();

            try
            {
                var queryString = $"table.csv?s={epicCode}&a={dateTime.Month - 1}&b={dateTime.Day}&c={dateTime.Year}&d={dateTime.Month - 1}&e={dateTime.Day}&f={dateTime.Year}&g=d";
                using (var response = await _httpClient.GetAsync(queryString))
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
                throw;
            }

            return price;
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}
