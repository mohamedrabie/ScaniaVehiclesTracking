using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Scania.VT.WebAPI;
using Scania.VT.WebAPI.Controllers;
using Scania.VT.DTO;
using Scania.VT.BL;
using Scania.VT.Helpers;

namespace Scania.VT.WebAPI.Test.Controllers
{
    [TestClass]
    public class CustomerControllerTest : BaseControllerTest
    {
        [TestMethod]
        public void Get_Success()
        {
            // Arrange
            CustomerController controller = new CustomerController(unitOfWork,customerService);

            // Act
            IEnumerable<CustomerDTO> result = controller.Get();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count());
            Assert.AreEqual("Kalles Grustransporter AB", result.ElementAt(0).CustomerName);
            
        }
        
    }
}
