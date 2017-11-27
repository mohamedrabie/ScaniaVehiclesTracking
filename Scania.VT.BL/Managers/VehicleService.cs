using System;
using System.Collections.Generic;
using System.Linq;
using Scania.VT.Entities;
using Scania.VT.Helpers.Enums;
using Service.Pattern;
using Repository.Pattern.Repositories;

namespace Scania.VT.BL
{
    public class VehicleService : Service<Vehicle>, IVehicleService
    {
        private readonly IRepositoryAsync<Vehicle> _repository;

        public VehicleService(IRepositoryAsync<Vehicle> repository) : base(repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// Returns all vehicles 
        /// </summary>
        /// <returns>Returns list of vehicles</returns>
        public List<Vehicle> GetAll()
        {
            return _repository.Query()
                .Include(m => m.Customer)
                .Include(m => m.VehicleStatus)
                .Select()
                .Where(v => v.IsDeleted == false && v.IsActive == true)
                .ToList();
        }
        /// <summary>
        /// Returns vehicles by customer
        /// </summary>
        /// <param name="customerId"> The customer id where vehicle is associated with</param>
        /// <returns>Returns list of vehicles</returns>
        public List<Vehicle> GetByCustomer(int customerId)
        {
            return _repository.Query().Include(m => m.Customer).Include(m => m.VehicleStatus).Select().Where(v => v.CustomerId == customerId).ToList();
        }

        public Vehicle GetByVehicle(string vehicleId)
        {
            return _repository.Queryable().FirstOrDefault(m => m.VIN == vehicleId);
        }
        /// <summary>
        /// Returns vehicles by status
        /// </summary>
        /// <param name="customerId"> Vehicle status</param>
        /// <returns>Returns list of vehicles</returns>
        public List<Vehicle> GetByStatus(VehicleStatusEnum status)
        {
            return _repository.Query().Include(m => m.Customer).Include(m => m.VehicleStatus).Select().Where(v => v.VehicleStatusId == (int)status).ToList();
        }
        /// <summary>
        /// Returns vehicles for specific customer and status
        /// </summary>
        /// <param name="customerId">Customer Id</param>
        /// <param name="status">Vehicle status</param>
        /// <returns></returns>
        public List<Vehicle> Search(int customerId, int status)
        {
            return _repository.Query().Include(m => m.Customer).Include(m => m.VehicleStatus).Select().Where(v => v.CustomerId == customerId && v.VehicleStatusId == status).ToList();
        }
        /// <summary>
        /// Updates spcific vehcile status
        /// </summary>
        /// <param name="vehicleId">The vehicle id to update its status</param>
        /// <param name="status">The new vehicle status</param>
        /// <returns>True if the vehcle status is updated successfully, false otherwise</returns>
        public bool UpdateStatus(string vehicleId, int status)
        {
            try
            {
                var vehicle = _repository.Queryable().FirstOrDefault(m => m.VIN == vehicleId);

                if (vehicle == null)
                {
                    return false;
                }

                vehicle.VehicleStatusId = status;
                vehicle.TrackingState = TrackableEntities.TrackingState.Modified;

                _repository.Update(vehicle);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
