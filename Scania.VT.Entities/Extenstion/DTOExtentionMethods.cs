using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scania.VT.DTO;
using Scania.VT.Helpers.Enums;
namespace Scania.VT.Entities
{
    public static class DTOExtentionMethods
    {

        public static List<VehicleDTO> GetDTO(this List<Vehicle> vehiclesList)
        {
            var vehicleList = new List<VehicleDTO>();

            foreach (Vehicle vehicle in vehiclesList)
            {
                vehicleList.Add(new VehicleDTO()
                {
                    CustomerName = vehicle.Customer.CustomerName,
                    RegistrationNo = vehicle.RegistrationNo,
                    VehicleId = vehicle.VIN,
                    VehicleStatus = vehicle.VehicleStatusId.ToString()
                });
            }

            return vehicleList;
        }

        public static List<CustomerDTO> GetDTO(this List<Customer> customerList)
        {
            var customerDTOs = new List<CustomerDTO>();

            foreach (Customer customer in customerList)
            {
                customerDTOs.Add(new CustomerDTO()
                {
                    CustomerId = customer.Id,
                    CustomerName = customer.CustomerName
                });
            }

            return customerDTOs;
        }

    }
}
