
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scania.VT.BL;
using Microsoft.Practices.Unity;
using Repository.Pattern.UnitOfWork;
using Repository.Pattern.Ef6;
using Repository.Pattern.Repositories;
using Scania.VT.Entities;
using Microsoft.Practices.ServiceLocation;
using System.Data.Entity;
using Scania.VT.Database.Test;

namespace Scania.VT.WebAPI.Test.Controllers
{
    [TestClass]
    public class BaseControllerTest
    {
        protected IUnitOfWorkAsync unitOfWork;
        protected IVehicleService vehicleService;
        protected ICustomerService customerService;

        VTModelFakeContext _context;

        public BaseControllerTest()
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
            unitOfWork = ServiceLocator.Current.GetInstance<IUnitOfWorkAsync>();
        }
      
    }
}
