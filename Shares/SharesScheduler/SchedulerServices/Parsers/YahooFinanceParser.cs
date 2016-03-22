using System;
using Models;
using static System.Decimal;

namespace SchedulerServices.Parsers
{
    public class YahooFinanceParser : IFinanceParser
    {
        public Price Parse(string epicCode, string line)
        {
            Price price = null;
            try
            {
                var splitLine = line.Split(',');

                price = new Price
                {
                    Date = DateTime.Parse(splitLine[0]),
                    Open = Decimal.Parse(splitLine[1]),
                    High = Decimal.Parse(splitLine[2]),
                    Low = Decimal.Parse(splitLine[3]),
                    Close = Decimal.Parse(splitLine[4]),
                    Volume = Decimal.Parse(splitLine[5]),
                    AdjustedClose = Decimal.Parse(splitLine[6])
                };

                price.Market = GetMarket(epicCode);
                price.Epic = GetEpicCode(epicCode);
            }
            catch (Exception ex)
            {
                // TODO: log
                    throw new ApplicationException("Error parsing values", ex);
            }

            return price;
        }

        private static string GetEpicCode(string epicCode)
        {
            return epicCode.Split('.')[0];
        }

        private string GetMarket(string epicCode)
        {
            var splitEpicCode = epicCode.Split('.');
            if (splitEpicCode.Length > 1)
            {
                return splitEpicCode[1];
            }

            return "NY";
        }
    }
}
