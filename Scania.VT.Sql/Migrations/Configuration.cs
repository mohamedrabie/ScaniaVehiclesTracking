namespace Scania.VT.Sql.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Collections.Generic;
    using System.Linq;
    using Scania.VT.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<VehiclesTrackingContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(VehiclesTrackingContext context)
        {
            var vehiclesList = new List<Vehicle>();

            vehiclesList.Add(new Vehicle()
            {
                RegistrationNo = "PQR678",
                VIN = "YS2R4X20005387765",
                VehicleStatusId = 2,
                IsDeleted = false,
                IsActive = true
            });
            vehiclesList.Add(new Vehicle()
            {
                RegistrationNo = "STU901",
                VIN = "YS2R4X20005387055",
                VehicleStatusId = 2,
                IsDeleted = false,
                IsActive = true
            });


            context.Customer.Add(new Customer()
            {
                CustomerName = "Haralds Värdetransporter AB",
                CustomerAddress = "Budgetvägen 1, 333 33 Uppsala",
                IsDeleted = false,
                IsActive = true,
                Vehicles = vehiclesList
            });


            vehiclesList = new List<Vehicle>();

            vehiclesList.Add(new Vehicle()
            {
                RegistrationNo = "JKL012",
                VIN = "YS2R4X20005388011",
                VehicleStatusId = 2,
                IsDeleted = false,
                IsActive = true
            });
            vehiclesList.Add(new Vehicle()
            {
                RegistrationNo = "MNO345",
                VIN = "YS2R4X20005387949",
                VehicleStatusId = 2,
                IsDeleted = false,
                IsActive = true
            });
            context.Customer.Add(new Customer()
            {
                CustomerName = "Johans Bulk AB",
                CustomerAddress = "Balkvägen 12, 222 22 Stockholm",
                IsDeleted = false,
                IsActive = true,
                Vehicles = vehiclesList
            });

            vehiclesList = new List<Vehicle>();

            vehiclesList.Add(new Vehicle()
            {
                RegistrationNo = "ABC123",
                VIN = "YS2R4X20005399401",
                VehicleStatusId = 2,
                IsDeleted = false,
                IsActive = true
            });
            vehiclesList.Add(new Vehicle()
            {
                RegistrationNo = "DEF456",
                VIN = "VLUR4X20009093588",
                VehicleStatusId = 2,
                IsDeleted = false,
                IsActive = true
            });
            vehiclesList.Add(new Vehicle()
            {
                RegistrationNo = "GHI789",
                VIN = "VLUR4X20009048066",
                VehicleStatusId = 2,
                IsDeleted = false,
                IsActive = true
            });
            context.Customer.Add(new Customer()
            {
                CustomerName = "Kalles Grustransporter AB",
                CustomerAddress = "Cementvägen 8, 111 11 Södertälje",
                IsDeleted = false,
                IsActive = true,
                Vehicles = vehiclesList
            });


            context.VehicleStatus.Add(new VehicleStatus()
            {
                Id = 1,
                Name = "Online"
            });
            context.VehicleStatus.Add(new VehicleStatus()
            {
                Id = 2,
                Name = "Offline"
            });
            context.VehicleStatus.Add(new VehicleStatus()
            {
                Id = 3,
                Name = "Unknown"
            });

            context.SaveChanges();
        }
    }
}
