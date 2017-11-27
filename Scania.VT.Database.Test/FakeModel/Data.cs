using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scania.VT.Entities;

namespace Scania.VT.Database.Test
{
    public static class SeedData
    {
        public static void Initialize(FakeDbContext _context)
        {
            _context.Set<VehicleStatus>().Add(new VehicleStatus()
            {
                Id = 1,
                Name = "Online"
            });
            _context.Set<VehicleStatus>().Add(new VehicleStatus()
            {
                Id = 2,
                Name = "Offline"
            });
            _context.Set<VehicleStatus>().Add(new VehicleStatus()
            {
                Id = 3,
                Name = "Unknown"
            });
            _context.Set<Customer>().Add(new Customer()
            {
                Id = 1,
                CustomerName = "Kalles Grustransporter AB",
                CustomerAddress = "Cementvägen 8, 111 11 Södertälje",
                IsDeleted = false,
                IsActive = true,
            });
            _context.Set<Customer>().Add(new Customer()
            {
                Id = 2,
                CustomerName = "Johans Bulk AB",
                CustomerAddress = "Balkvägen 12, 222 22 Stockholm",
                IsDeleted = false,
                IsActive = true
            });
            _context.Set<Customer>().Add(new Customer()
            {
                Id = 3,
                CustomerName = "Haralds Värdetransporter AB",
                CustomerAddress = "Budgetvägen 1, 333 33 Uppsala",
                IsDeleted = false,
                IsActive = true
            });
            _context.Set<Vehicle>().Add(new Vehicle()
            {
                Id = 1,
                RegistrationNo = "ABC123",
                VIN = "YS2R4X20005399401",
                CustomerId = 1,
                VehicleStatusId = 2,
                IsDeleted = false,
                IsActive = true
            });
            _context.Set<Vehicle>().Add(new Vehicle()
            {
                Id = 2,
                RegistrationNo = "DEF456",
                VIN = "VLUR4X20009093588",
                CustomerId = 1,
                VehicleStatusId = 2,
                IsDeleted = false,
                IsActive = true
            });
            _context.Set<Vehicle>().Add(new Vehicle()
            {
                Id = 3,
                RegistrationNo = "GHI789",
                VIN = "VLUR4X20009048066",
                CustomerId = 1,
                VehicleStatusId = 2,
                IsDeleted = false,
                IsActive = true
            });
            _context.Set<Vehicle>().Add(new Vehicle()
            {
                Id = 4,
                RegistrationNo = "JKL012",
                VIN = "YS2R4X20005388011",
                CustomerId = 2,
                VehicleStatusId = 2,
                IsDeleted = false,
                IsActive = true
            });
            _context.Set<Vehicle>().Add(new Vehicle()
            {
                Id = 5,
                RegistrationNo = "MNO345",
                VIN = "YS2R4X20005387949",
                CustomerId = 2,
                VehicleStatusId = 2,
                IsDeleted = false,
                IsActive = true
            });
            _context.Set<Vehicle>().Add(new Vehicle()
            {
                Id = 6,
                RegistrationNo = "PQR678",
                VIN = "YS2R4X20005387765",
                CustomerId = 3,
                VehicleStatusId = 2,
                IsDeleted = false,
                IsActive = true
            });
            _context.Set<Vehicle>().Add(new Vehicle()
            {
                Id = 7,
                RegistrationNo = "STU901",
                VIN = "YS2R4X20005387055",
                CustomerId = 3,
                VehicleStatusId = 2,
                IsDeleted = false,
                IsActive = true
            });

            _context.SaveChanges();
        }
    }
}
