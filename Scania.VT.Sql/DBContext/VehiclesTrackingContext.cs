namespace Scania.VT.Sql
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Scania.VT.Entities;
    using System.Data.Common;
    using Migrations;
    using Models.Mapping;

    public partial class VehiclesTrackingContext : DbContext
    {

        static VehiclesTrackingContext()
        {
            Database.SetInitializer<VehiclesTrackingContext>(null);
        }

        public VehiclesTrackingContext()
            : base("name=VehiclesTrackingContext")
        {
            Configuration.ProxyCreationEnabled = false;
            //Database.SetInitializer<VehiclesTrackingContext>(new DBInitializer());

        }



        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Vehicle> Vehicle { get; set; }
        public virtual DbSet<VehicleStatus> VehicleStatus { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CustomerMap());
            modelBuilder.Configurations.Add(new VehicleMap());
            modelBuilder.Configurations.Add(new VehicleStatusMap());
        }
    }
}
