using System.Collections.Generic;
using System.Web.Http;
using Scania.VT.BL;
using Scania.VT.Entities;
using Scania.VT.Helpers;
using Scania.VT.Helpers.Enums;
using Scania.VT.DTO;
using System.Web.Http.Cors;
using Repository.Pattern.UnitOfWork;

namespace Scania.VT.WebAPI.Controllers
{
    [Authorize]
    [EnableCors(origins: "http://localhost:8415", headers: "*", methods: "*")]
    public class VehicleController : ApiController
    {

        private readonly IVehicleService _vehicleService;
        private readonly IUnitOfWorkAsync _unitOfWorkAsync;

        public VehicleController(IVehicleService vehicleService, IUnitOfWorkAsync unitOfWorkAsync)
        {
            _vehicleService = vehicleService;
            _unitOfWorkAsync = unitOfWorkAsync;
        }



        // GET api/<controller>
        public IEnumerable<VehicleDTO> Get()
        {
            return _vehicleService.GetAll().GetDTO();
        }

        // GET api/<controller>/5
        public IEnumerable<VehicleDTO> GetByCustomer(int id)
        {
            return _vehicleService.GetByCustomer(id).GetDTO();
        }
        // GET api/<controller>/<action>/5
        public IEnumerable<VehicleDTO> GetByStatus(int id)
        {
            return _vehicleService.GetByStatus((VehicleStatusEnum)id).GetDTO();
        }
        [HttpGet]
        public IEnumerable<VehicleDTO> SearchVehicles(int customerId, int status)
        {
            return _vehicleService.Search(customerId, status).GetDTO();
        }

        // POST api/<controller>
        [HttpPost]
        public bool UpdateMyStatus(VehicleStatusStruct vehicleStatus)
        {
            if (vehicleStatus.status > 1)
            {
                return false;
            }
            var result=_vehicleService.UpdateStatus(vehicleStatus.vehicleId, vehicleStatus.status);
            return _unitOfWorkAsync.SaveChanges()== 1;

          
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}