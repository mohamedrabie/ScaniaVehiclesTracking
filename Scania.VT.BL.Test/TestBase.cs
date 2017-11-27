using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scania.VT.BL;
using System.Data.Entity;
using Scania.VT.Sql;
using Effort;
using System.Data.Entity.Core.Objects;
using Microsoft.Practices.Unity;
using Scania.VT.Entities;
using Repository.Pattern.Ef6;
using Repository.Pattern.Repositories;
using Microsoft.Practices.ServiceLocation;
using Repository.Pattern.UnitOfWork;
using Scania.VT.Database.Test;

namespace Scania.VT.BL.Test
{
    public class TestBase
    {
      
        protected IVehicleService vehicleService;
        protected ICustomerService customerService;

        VTModelFakeContext _context;
        public TestBase()
        {
            _context = new VTModelFakeContext();
            SeedData.Initialize(_context);


            //Dependency injection configuration
            var container = new UnityContainer();

            container.RegisterInstance<DbContext>(_context)
             .RegisterType<IUnitOfWorkAsync, UnitOfWork>(new PerResolveLifetimeManager())
             .RegisterType<IRepositoryAsync<Customer>, Repository<Customer>>()
             .RegisterType<IRepositoryAsync<Vehicle>, Repository<Vehicle>>()
             .RegisterType<IVehicleService, VehicleService>()
             .RegisterType<ICustomerService, CustomerService>();
            ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(container));

            vehicleService = ServiceLocator.Current.GetInstance<IVehicleService>();
            customerService = ServiceLocator.Current.GetInstance<ICustomerService>();

        }
     
    }
    
}
