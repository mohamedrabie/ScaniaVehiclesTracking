using System.Collections.Generic;
using System.Web.Http;
using Scania.VT.BL;
using Scania.VT.Entities;
using Scania.VT.DTO;
using System.Web.Http.Cors;
using Repository.Pattern.UnitOfWork;

namespace Scania.VT.WebAPI.Controllers
{
    [EnableCors(origins: "http://localhost:8415", headers: "*", methods: "*")]
    public class CustomerController : ApiController
    {
        private readonly ICustomerService _customerService;
        private readonly IUnitOfWorkAsync _unitOfWorkAsync;

        public CustomerController(
        IUnitOfWorkAsync unitOfWorkAsync,
        ICustomerService customerService)
        {
            _unitOfWorkAsync = unitOfWorkAsync;
            _customerService = customerService;
        }

        // GET api/<controller>
        [Authorize]
        public IEnumerable<CustomerDTO> Get()
        {
            return _customerService.GetAllCutomers().GetDTO();
        }

       
    }
}