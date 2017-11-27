using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scania.VT.Entities;

namespace Scania.VT.BL
{
    public interface ICustomerService : IService<Customer>
    {
        /// <summary>
        /// Returns all active and not deleted customers
        /// </summary>
        /// <returns>List of active customers</returns>
        List<Customer> GetAllCutomers();

    }
}
