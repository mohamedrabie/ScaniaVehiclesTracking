using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Repository.Pattern.Ef6;

using Scania.VT.Entities;

namespace Scania.VT.Database.Test
{

    public class CustomerDbSet : FakeDbSet<Customer>
    {
        public override Customer Find(params object[] keyValues)
        {
            return this.SingleOrDefault(t => t.Id == (int)keyValues.FirstOrDefault());
        }

        public override Task<Customer> FindAsync(params object[] keyValues)
        {
            return new Task<Customer>(() => Find(keyValues));
        }

        public override Task<Customer> FindAsync(CancellationToken cancellationToken, params object[] keyValues)
        {
            return new Task<Customer>(() => Find(keyValues));
        }
    }

   
    public class VehicleDbSet : FakeDbSet<Vehicle>
    {
        public override Vehicle Find(params object[] keyValues)
        {
            return this.SingleOrDefault(t => t.Id == (int) keyValues.FirstOrDefault());
        }

        public override Task<Vehicle> FindAsync(CancellationToken cancellationToken, params object[] keyValues)
        {
            return new Task<Vehicle>(() => this.SingleOrDefault(t => t.Id == (int) keyValues.FirstOrDefault()));
        }
    }

    public class VehicleStatusDbSet : FakeDbSet<VehicleStatus>
    {
        public override VehicleStatus Find(params object[] keyValues)
        {
            return this.SingleOrDefault(t => t.Id == (int)keyValues.FirstOrDefault());
        }

        public override Task<VehicleStatus> FindAsync(CancellationToken cancellationToken, params object[] keyValues)
        {
            return new Task<VehicleStatus>(() => this.SingleOrDefault(t => t.Id == (int)keyValues.FirstOrDefault()));
        }
    }
}