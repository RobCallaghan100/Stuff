namespace SchedulerServices
{
    using Models;

    public class FinanceService
    {
        private readonly IFinanceClient _financeClient;
        
        // TODO: Use Ninject

        public FinanceService(IFinanceClient financeClient)
        {
            _financeClient = financeClient;
        }

        public Price Get(string epicCode)
        {
            return _financeClient.Get(epicCode);
        }
    }
}