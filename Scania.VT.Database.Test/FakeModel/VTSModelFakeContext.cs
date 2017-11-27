
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scania.VT.Entities;

namespace Scania.VT.Database.Test
{
    public class VTModelFakeContext : FakeDbContext
    {
        public VTModelFakeContext() 
        {

    
           AddFakeDbSet<Customer, CustomerDbSet>();
            AddFakeDbSet<Vehicle, VehicleDbSet>();
            AddFakeDbSet<VehicleStatus, VehicleStatusDbSet>();
        }

      
    }
}
