using System;
using Microsoft.Practices.Unity;
using Repository.Pattern.UnitOfWork;
using Repository.Pattern.Repositories;
using Scania.VT.BL;
using Scania.VT.Sql;
using Repository.Pattern.Ef6;
using Scania.VT.Entities;
using System.Data.Entity;

namespace Scania.VT.WebAPI.App_Start
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
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

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your types here
            container.RegisterType<DbContext, VehiclesTrackingContext>(new PerRequestLifetimeManager())
             .RegisterType<IUnitOfWorkAsync, UnitOfWork>(new PerRequestLifetimeManager())
             .RegisterType<IRepositoryAsync<Customer>, Repository<Customer>>()
             .RegisterType<IRepositoryAsync<Vehicle>, Repository<Vehicle>>()
             .RegisterType<IVehicleService, VehicleService>()
             .RegisterType<ICustomerService, CustomerService>();
        }
    }
}
