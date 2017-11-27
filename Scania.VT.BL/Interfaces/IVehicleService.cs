using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scania.VT.Entities;
using Scania.VT.Helpers.Enums;

namespace Scania.VT.BL
{
    public interface IVehicleService : IService<Vehicle>
    {
        /// <summary>
        /// Returns all vehicles by customer
        /// </summary>
        /// <param name="customerId"> The customer id where vehicle is associated with</param>
        /// <returns>Returns list of vehicles</returns>
        List<Vehicle> GetAll();


        /// <summary>
        /// Returns vehicle by id
        /// </summary>
        /// <returns>Returns vehicle</returns>
        Vehicle GetByVehicle(string vehicleId);

        /// <summary>
        /// Returns vehicles by customer
        /// </summary>
        /// <param name="customerId"> The customer id where vehicle is associated with</param>
        /// <returns>Returns list of vehicles</returns>
        List<Vehicle> GetByCustomer(int customerId);

        /// <summary>
        /// Returns vehicles by status
        /// </summary>
        /// <param name="customerId"> Vehicle status</param>
        /// <returns>Returns list of vehicles</returns>
        List<Vehicle> GetByStatus(VehicleStatusEnum status);

        /// <summary>
        /// Return vehicles for specific customer with specific status
        /// </summary>
        /// <param name="status">Vehicle status</param>
        /// <returns></returns>
        List<Vehicle> Search(int customerId, int status);

        /// <summary>
        /// Updates spcific vehcile status
        /// </summary>
        /// <param name="vehicleId">The vehicle id to update its status</param>
        /// <param name="status">The new vehicle status</param>
        /// <returns>True if the vehcle status is updated successfully, false otherwise</returns>
        bool UpdateStatus(string vehicleId, int status);
       
    }
}
