using Ninject.Modules;
using SchedulerServices.Builders;
using SchedulerServices.Parsers;
using SchedulerServices.Validators;

namespace Console
{
    public class SchedulerModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IQueryStringBuilder>().To<YahooQueryStringBuilder>().InSingletonScope();
            Bind<IValidator>().To<YahooFinanceValidator>().InSingletonScope();
            Bind<IFinanceParser>().To<YahooFinanceParser>().InSingletonScope();
        }
    }
}
