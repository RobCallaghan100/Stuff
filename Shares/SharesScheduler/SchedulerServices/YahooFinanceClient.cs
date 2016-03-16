namespace SchedulerServices
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Models;

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
            var queryString = $"table.csv?s={epicCode}&a{dateTime.Month - 1}&b={dateTime.Day}&c={dateTime.Year}&d={dateTime.Month-1}&e={dateTime.Day}&f={dateTime.Year}&g=d";
            using (var response = await _httpClient.GetAsync(queryString))
            using (var content = response.Content)
            {
                TODO: change stream and get back as csv
            }

            return price;

            // &ignore=.csv
            // http://real-chart.finance.yahoo.com/table.csv?s=VOD.L&a=02&b=15&c=2016&d=02&e=15&f=2016&g=d&ignore=.csv
            //             https://uk.finance.yahoo.com/q/hp?s=VOD.L&b=14&a=01&c=2016&e=15&d=02&f=2016&g=d
            // https://uk.finance.yahoo.com/q/hp?s=VOD.L  &a=00 &b=01 &c=2016 | &d=11 &e=31 &f=2016 &g=d
            //_httpClient.BaseAddress
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}
