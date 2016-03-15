namespace SchedulerServices
{
    using Models;

    public interface IFinanceClient
    {
        Price Get(string epicCode);
    }
}