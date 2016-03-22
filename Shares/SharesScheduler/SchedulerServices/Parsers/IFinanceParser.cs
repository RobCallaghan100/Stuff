using Models;

namespace SchedulerServices.Parsers
{
    public interface IFinanceParser
    {
        Price Parse(string epicCode, string line);
    }
}
