using System;
using System.Collections.Generic;

namespace SportsStore.WebUI.Infrastructure
{
    using System.Web.Mvc;
    using Domain.Abstract;
    using Domain.Entities;
    using Moq;
    using Ninject;

    public class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly IKernel _kernel;

        public NinjectDependencyResolver(IKernel kernel)
        {
            _kernel = kernel;
            AddBindings();
        }

        private void AddBindings()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products)
                .Returns(new List<Product>
                {
                    new Product {Name = "Football", Price = 25},
                    new Product {Name = "Surf board", Price = 179},
                    new Product {Name = "Running shoes", Price = 95}
                });
            _kernel.Bind<IProductRepository>().ToConstant(mock.Object);
        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }
    }
}