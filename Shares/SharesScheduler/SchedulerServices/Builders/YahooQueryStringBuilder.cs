using System;

namespace SchedulerServices.Builders
{
    public class YahooQueryStringBuilder : IQueryStringBuilder
    {
        public string BuildQueryString(string epicCode, DateTime dateTime)
        {
            return BuildQueryString(epicCode, dateTime, dateTime);
        }

        public string BuildQueryString(string epicCode, DateTime fromDate, DateTime toDate)
        {
           return $"table.csv?s={epicCode}&a={fromDate.Month - 1}&b={fromDate.Day}&c={fromDate.Year}&d={toDate.Month - 1}&e={toDate.Day}&f={toDate.Year}&g=d";
        }
    }
}
