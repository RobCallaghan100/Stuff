namespace SchedulerServices
{
    using System;
    using System.Threading.Tasks;
    using Models;

    public class FinanceService
    {
        private readonly IFinanceClient _financeClient;
        
        // TODO: Use Ninject

        public FinanceService(IFinanceClient financeClient)
        {
            _financeClient = financeClient;
        }

        public Task<Price> Get(string epicCode, DateTime dateTime)
        {
            return _financeClient.Get(epicCode, dateTime);
        }
    }
}