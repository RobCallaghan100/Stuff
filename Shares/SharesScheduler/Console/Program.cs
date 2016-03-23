using SchedulerServices;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO: Put Ninject in!
            // TODO: create library for ElasticSearch. STart with tests first - Implement from IRepository<T> (ie ElasticSearchRepository<T> : IRepository<T> (where T is Price in this case)
            // TODO: Use builder pattern to create query (do I need this yet?)
            var x = new YahooFinanceClient();
        }
    }
}
