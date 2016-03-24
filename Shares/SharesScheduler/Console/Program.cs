using System;
using Ninject;
using SchedulerServices;

namespace Console
{
    class Program
    {
        private static IKernel _kernel;

        static void Main(string[] args)
        {
            _kernel = new StandardKernel(new SchedulerModule());

            Extract();

            System.Console.ReadLine();
        }

        private static async void Extract()
        {
            var yahooFinanceClient = _kernel.Get<YahooFinanceClient>();

            var price = await yahooFinanceClient.Get("VOD.L", DateTime.Today.AddDays(-1));
        }
    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                