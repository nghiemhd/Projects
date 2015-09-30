using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Core.Infrastructure;
using TestProject.Logging;
using TestProject.Service.ServiceContracts;

namespace TestProject.Service
{
    public class Bootstrapper
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        public static void RegisterTypes(IUnityContainer container)
        {
            var connection = ConfigurationManager.ConnectionStrings["DataContext"];
            var connectionString = connection.ConnectionString;

            container.RegisterType<IDbContext, DataContext>(new InjectionConstructor(connectionString));
            container.RegisterType<IUnitOfWork, UnitOfWork<DataContext>>();
            container.RegisterType<ILogger, Logger>(new InjectionConstructor("TestWeb"));
            container.RegisterType<IAuthenticationService, AuthenticationService>();
            container.RegisterType<IInvoiceService, InvoiceService>();
        }
    }
}
