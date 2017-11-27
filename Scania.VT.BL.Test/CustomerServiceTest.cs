using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Scania.VT.BL.Test
{
    [TestClass]
    public class CustomerServiceTest : TestBase
    {
        
        [TestMethod]
        public void GetAllVehicles_Success()
        {
            var customerList = customerService.GetAllCutomers();

            Assert.AreEqual(customerList.Count, 3);
        }
    }
}
