namespace SchedulerServices
{
    using System;
    using System.Threading.Tasks;
    using Models;

    public interface IFinanceClient
    {
        Task<Price> Get(string epicCode, DateTime dateTime);
    }
}