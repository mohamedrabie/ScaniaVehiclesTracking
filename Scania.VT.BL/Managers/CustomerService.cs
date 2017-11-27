using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scania.VT.Entities;
using Repository.Pattern.Repositories;
using Service.Pattern;

namespace Scania.VT.BL
{
    public class CustomerService : Service<Customer>, ICustomerService
    {
        private readonly IRepositoryAsync<Customer> _repository;

        public CustomerService(IRepositoryAsync<Customer> repository) : base(repository)
        {
            _repository = repository;
        }

        public List<Customer> GetAllCutomers()
        {
            return _repository.Queryable().Where(c => c.IsDeleted == false && c.IsActive == true).ToList();
        }
    }
}
