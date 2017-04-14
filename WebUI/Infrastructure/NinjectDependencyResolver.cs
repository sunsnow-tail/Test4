using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Moq;
using Ninject;
using Domain;
using System.Configuration;

namespace WebUI.Infrastructure
{

    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam) {

            kernel = kernelParam;

            AddBindings();
        }

        public object GetService(Type serviceType) {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType) {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings() {

            Mock<IProductRepository> mock = new Mock<IProductRepository>();

            mock.Setup(m => m.Products).Returns(
                new List<Product> {
                    new Product { Name = "Football", Price = 25, Category="Soccer", Description="k", ProductID=1 },
                    new Product { Name = "Surf board", Price = 179, Category="test", Description="k" , ProductID=2 },
                    new Product { Name = "Running shoes", Price = 95, Category="Shoes", Description="k" , ProductID=3 },
                    new Product { Name = "Football1", Price = 25, Category="Soccer", Description="k" , ProductID=4 },
                    new Product { Name = "Surf board1", Price = 179, Category="test", Description="k" , ProductID=5 },
                    new Product { Name = "Running shoes1", Price = 95, Category="Shoes", Description="k", ProductID=6  },
                    new Product { Name = "Football2", Price = 25, Category="Soccer", Description="k" , ProductID=7 },
                    new Product { Name = "Surf board2", Price = 179, Category="test", Description="k" , ProductID=8 },
                    new Product { Name = "Running shoes2", Price = 95, Category="Shoes" , Description="k" , ProductID=9},
                    new Product { Name = "Surf board21", Price = 179, Category="test" , Description="k", ProductID=10 }
                });

            kernel.Bind<IProductRepository>().ToConstant(mock.Object);

            EmailSettings emailSettings = new EmailSettings {
                WriteAsFile = bool.Parse(ConfigurationManager.AppSettings["Email.WriteAsFile"] ?? "false")
            };

            kernel.Bind<IOrderProcessor>().To<EmailOrderProcessor>().WithConstructorArgument("settings", emailSettings);
        }
    }
}