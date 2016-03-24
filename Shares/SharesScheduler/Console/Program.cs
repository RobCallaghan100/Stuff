using System;
using System.Threading.Tasks;
using ElasticSearchService.Indexers;
using Models;
using Ninject;
using SchedulerServices;

namespace Console
{
    class Program
    {
        private static IKernel _kernel;

        static void Main(string[] args)
        {
            _kernel = new StandardKernel(new BindingModule());

            SaveSharePrices();

            System.Console.ReadLine();
        }

        private static void SaveSharePrices()
        {
            var price = ExtractPrice().Result;
            PopulateRepository(price);
        }

        private static void PopulateRepository(Price price)
        {
            var indexer = _kernel.Get<Indexer>();

            indexer.Index("Shares", "Price", price);
        }

        private static async Task<Price> ExtractPrice()
        {
            var yahooFinanceClient = _kernel.Get<YahooFinanceClient>();

            var price = await yahooFinanceClient.Get("VOD.L", GetLastWorkingDay());

            return price;
        }

        private static DateTime GetLastWorkingDay()
        {
            return DateTime.Today.AddDays(-1); // TODO: this need changing to be more clever
        }
    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                