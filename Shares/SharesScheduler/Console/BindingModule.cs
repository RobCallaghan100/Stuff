using ElasticSearchService.Gateway;
using ElasticSearchService.Indexers;
using Ninject.Modules;
using SchedulerServices.Builders;
using SchedulerServices.Parsers;
using SchedulerServices.Validators;

namespace Console
{
    public class BindingModule : NinjectModule
    {
        public override void Load()
        {
            AddSchedulerBindings();
            AddSearchGatewayBindings();
        }

        private void AddSchedulerBindings()
        {
            Bind<IQueryStringBuilder>().To<YahooQueryStringBuilder>();
            Bind<IValidator>().To<YahooFinanceValidator>();
            Bind<IFinanceParser>().To<YahooFinanceParser>();
        }

        private void AddSearchGatewayBindings()
        {
            Bind<IIndexer>().To<Indexer>();
            Bind<IElasticSearchGateway>().To<ElasticSearchGateway>();
        }
    }
}
