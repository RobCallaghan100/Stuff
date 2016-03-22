using System;
using Models;

namespace SchedulerServices.Parsers
{
    public class YahooFinanceParser : IYahooFinanceParser
    {
        public Price Parse(string line)
        {
            var splitLine = line.Split(',');

            var price = new Price
            {
                Date = DateTime.Parse(splitLine[0]),
                Open = Decimal.Parse(splitLine[1]),
                High = Decimal.Parse(splitLine[2]),
                Low = Decimal.Parse(splitLine[3]),
                Close = Decimal.Parse(splitLine[4]),
                Volume = Decimal.Parse(splitLine[5]),
                AdjustedClose = Decimal.Parse(splitLine[6])
            };

            return price;
        }
    }
}
