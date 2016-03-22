using Models;

namespace SchedulerServices.Parsers
{
    public interface IYahooFinanceParser
    {
        Price Parse(string line);
    }
}
