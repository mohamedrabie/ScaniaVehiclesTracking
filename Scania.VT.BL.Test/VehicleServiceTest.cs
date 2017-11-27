using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Scania.VT.BL.Test
{
    [TestClass]
    public class VehicleServiceTest : TestBase
    {
        
        [TestMethod]
        public void GetAll_Success()
        {
            var vehiclesList = vehicleService.GetAll();

            Assert.AreEqual(vehiclesList.Count, 7);
        }

        [TestMethod]
        public void GetVehiclesByCustomer_Success()
        {
            var vehiclesList = vehicleService.GetByCustomer(1);

            Assert.AreEqual(vehiclesList.Count, 3);
        }
        [TestMethod]
        public void GetVehiclesByCustomer_NoResults()
        {
            var vehiclesList = vehicleService.GetByCustomer(5);

            Assert.AreEqual(vehiclesList.Count, 0);
        }

        [TestMethod]
        public void GetVehiclesByStatus_Success()
        {
            var vehiclesList = vehicleService.GetByStatus(Helpers.Enums.VehicleStatusEnum.Offline);

            Assert.AreEqual(vehiclesList.Count, 7);
        }
        [TestMethod]
        public void GetVehiclesByStatus_NoResults()
        {
            var vehiclesList = vehicleService.GetByStatus(Helpers.Enums.VehicleStatusEnum.Unknown);

            Assert.AreEqual(vehiclesList.Count, 0);

            vehiclesList = vehicleService.GetByStatus(Helpers.Enums.VehicleStatusEnum.Online);

            Assert.AreEqual(vehiclesList.Count, 0);
        }

        [TestMethod]
        public void UpdateVehicleStatus_Success()
        {
           var result = vehicleService.UpdateStatus("VLUR4X20009093588", (int)Helpers.Enums.VehicleStatusEnum.Online);

            Assert.AreEqual(result, true);

            var vehiclesList = vehicleService.GetByStatus(Helpers.Enums.VehicleStatusEnum.Online);

            Assert.AreEqual(vehiclesList.Count, 1);

            Assert.AreEqual(vehiclesList[0].VIN, "VLUR4X20009093588");
        }
        [TestMethod]
        public void UpdateVehicleStatus_InvalidVehicle()
        {
            var result = vehicleService.UpdateStatus("xxxx0000", (int)Helpers.Enums.VehicleStatusEnum.Online);

            Assert.AreEqual(result, false);

        }

        [TestMethod]
        public void SearchVehicles_Success()
        {
            var vehiclesList = vehicleService.Search(1, 2);

            Assert.AreEqual(vehiclesList.Count, 3);

            vehiclesList = vehicleService.Search(2, 2);

            Assert.AreEqual(vehiclesList.Count, 2);

        }

        [TestMethod]
        public void SearchVehicles_WrongStatus_NoResults()
        {
            var vehiclesList = vehicleService.Search(1, 1);

            Assert.AreEqual(vehiclesList.Count, 0);
        }

        [TestMethod]
        public void SearchVehicles_WrongCustomer_NoResults()
        {
            var vehiclesList = vehicleService.Search(5, 1);

            Assert.AreEqual(vehiclesList.Count, 0);
        }


    }
}
