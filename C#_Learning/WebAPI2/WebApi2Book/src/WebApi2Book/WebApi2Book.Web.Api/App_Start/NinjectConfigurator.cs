﻿using WebApi2Book.Web.Api.AutoMappingConfiguration;
using WebApi2Book.Web.Api.MaintenanceProcessing;

namespace WebApi2Book.Web.Api
{
    using Data.QueryProcessors;
    using Data.SqlServer.Mapping;
    using Data.SqlServer.QueryProcessors;
    using FluentNHibernate.Cfg;
    using FluentNHibernate.Cfg.Db;
    using log4net.Config;
    using NHibernate;
    using NHibernate.Context;
    using Ninject;
    using Ninject.Activation;
    using Ninject.Web.Common;
    using Security;
    using WebApi2Book.Common;
    using WebApi2Book.Common.Logging;
    using WebApi2Book.Common.Security;
    using WebApi2Book.Common.TypeMapping;

    public class NinjectConfigurator
    {
        public void Configure(IKernel container)
        {
            AddBindings(container);
        }

        private void AddBindings(IKernel container)
        {
            Configurelog4net(container);
            ConfigureUserSession(container);
            ConfigureNHibernate(container);
            ConfigureAutoMapper(container);

            container.Bind<IDateTime>().To<DateTimeAdapter>().InSingletonScope();

            container.Bind<IAddTaskQueryProcessor>().To<AddTaskQueryProcessor>().InRequestScope();
            container.Bind<ITaskByIdQueryProcessor>().To<TaskByIdQueryProcessor>().InRequestScope();
            container.Bind<IUpdateTaskStatusQueryProcessor>().To<UpdateTaskStatusQueryProcessor>().InRequestScope();
        }

        private void ConfigureAutoMapper(IKernel container)
        {
            container.Bind<IAutoMapper>().To<AutoMapperAdapter>().InSingletonScope();

            container.Bind<IAutoMapperTypeConfigurator>().To<StatusEntityToStatusAutoMapperTypeConfigurator>().InSingletonScope();
            container.Bind<IAutoMapperTypeConfigurator>().To<StatusToStatusEntityAutoMapperTypeConfigurator>().InSingletonScope();
            container.Bind<IAutoMapperTypeConfigurator>().To<UserEntityToUserAutoMapperTypeConfigurator>().InSingletonScope();
            container.Bind<IAutoMapperTypeConfigurator>().To<UserToUserEntityAutoMapperTypeConfigurator>().InSingletonScope();
            container.Bind<IAutoMapperTypeConfigurator>().To<NewTaskToTaskEntityAutoMapperConfigurator>().InSingletonScope();
            container.Bind<IAutoMapperTypeConfigurator>().To<TaskEntityToTaskAutoMapperTypeConfigurator>().InSingletonScope();

            container.Bind<IAddTaskMaintenanceProcessor>().To<AddTaskMaintenanceProcessor>().InRequestScope();

            container.Bind<IBasicSecurityService>().To<BasicSecurityService>().InSingletonScope();
        }

        private void ConfigureUserSession(IKernel container)
        {
            var userSession = new UserSession();
            container.Bind<IUserSession>().ToConstant(userSession).InSingletonScope();
            container.Bind<IWebUserSession>().ToConstant(userSession).InSingletonScope();
        }

        private void Configurelog4net(IKernel container)
        {
            XmlConfigurator.Configure();

            var logManager = new LogManagerAdapter();
            container.Bind<ILogManager>().ToConstant(logManager);
        }

        private void ConfigureNHibernate(IKernel container)
        {
            var sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012
                    .ConnectionString(c => c.FromConnectionStringWithKey("WebApi2BookDb")))
                .CurrentSessionContext("web")
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<TaskMap>())
                .BuildSessionFactory();

            container.Bind<ISessionFactory>().ToConstant(sessionFactory); // single ISessionFactory per application
            container.Bind<ISession>().ToMethod(CreateSession).InRequestScope();
            container.Bind<IActionTransactionHelper>().To<ActionTransactionHelper>().InRequestScope();
        }

        private ISession CreateSession(IContext context)
        {
            var sessionFactory = context.Kernel.Get<ISessionFactory>();

            if (!CurrentSessionContext.HasBind(sessionFactory))
            {
                var session = sessionFactory.OpenSession();
                CurrentSessionContext.Bind(session);
            }

            return sessionFactory.GetCurrentSession();
        }
    }
}