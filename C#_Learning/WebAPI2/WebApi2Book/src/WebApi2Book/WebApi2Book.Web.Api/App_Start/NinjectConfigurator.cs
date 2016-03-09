namespace WebApi2Book.Web.Api
{
    using log4net.Config;
    using Ninject;
    using WebApi2Book.Common;
    using WebApi2Book.Common.Logging;

    public class NinjectConfigurator
    {
        public void Configure(IKernel container)
        {
            AddBindings(container);
        }

        private void AddBindings(IKernel container)
        {
            Configurelog4net(container);

            container.Bind<IDateTime>().To<DateTimeAdapter>().InSingletonScope();
        }

        private void Configurelog4net(IKernel container)
        {
            XmlConfigurator.Configure();

            var logManager = new LogManagerAdapter();
            container.Bind<ILogManager>().ToConstant(logManager);
        }
    }
}