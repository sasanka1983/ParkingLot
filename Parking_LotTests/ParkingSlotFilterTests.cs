using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parking_Lot.BusinessObjects;
using Parking_Lot.Enums;
using Parking_Lot.Implementations;
using Parking_Lot.Interfaces;

namespace Parking_LotTests
{
    [TestClass]
    public class ParkingSlotFilterTests
    {
        [TestMethod]
        public void Filter_ForSlotNumber_returns_Matched()
        {
            var vehicle1 = new Vehicle() { VehicleNumber = "KA-03-8986" };
            var vehicle2 = new Vehicle() { VehicleNumber = "KA-03-8981" };
            var vehicle3 = new Vehicle() { VehicleNumber = "KA-03-8982" };
            var vehicle4 = new Vehicle() { VehicleNumber = "KA-03-8983" };
            var vehicle5 = new Vehicle() { VehicleNumber = "KA-03-8984" };


            IParkingManagement parkingMgmt = new ParkingManagement(5);

            parkingMgmt.AddVehicleToSlot(vehicle1);
            parkingMgmt.AddVehicleToSlot(vehicle2);
            parkingMgmt.AddVehicleToSlot(vehicle3);
            parkingMgmt.AddVehicleToSlot(vehicle4);
            parkingMgmt.AddVehicleToSlot(vehicle5);

            var filter = new ParkingSlotFilter();
            var criteria = new SlotNumberCriteria(3);
            var result = filter.Filter(parkingMgmt.GetParkingSlotsInformation().AsEnumerable(), criteria);
            Assert.IsTrue(result.Count() == 1);
            Assert.IsTrue(result.ElementAt(0).VehicleInSlot.VehicleNumber == "KA-03-8982");
        }

        [TestMethod]
        public void Filter_ForSlotNumber_returns_Empty()
        {
            IParkingManagement parkingMgmt = new ParkingManagement(0);
            var filter = new ParkingSlotFilter();
            var criteria = new SlotNumberCriteria(3);
            var result = filter.Filter(parkingMgmt.GetParkingSlotsInformation().AsEnumerable(), criteria);
            Assert.IsTrue(result.Count() == 0);
        }

        [TestMethod]
        public void Filter_ForVehicleColorNumber_returns_Matched()
        {
            var vehicle1 = new Vehicle() {VehicleNumber = "KA-03-8986", VehicleColor = ColorEnums.Black};
            var vehicle2 = new Vehicle() {VehicleNumber = "KA-03-8981", VehicleColor = ColorEnums.Black};
            var vehicle3 = new Vehicle() {VehicleNumber = "KA-03-8982", VehicleColor = ColorEnums.Brown};
            var vehicle4 = new Vehicle() {VehicleNumber = "KA-03-8983", VehicleColor = ColorEnums.Yellow};
            var vehicle5 = new Vehicle() {VehicleNumber = "KA-03-8984", VehicleColor = ColorEnums.Magenta};


            IParkingManagement parkingMgmt = new ParkingManagement(5);

            parkingMgmt.AddVehicleToSlot(vehicle1);
            parkingMgmt.AddVehicleToSlot(vehicle2);
            parkingMgmt.AddVehicleToSlot(vehicle3);
            parkingMgmt.AddVehicleToSlot(vehicle4);
            parkingMgmt.AddVehicleToSlot(vehicle5);

            var filter = new ParkingSlotFilter();
            var criteria = new VehicleColorCriteria(ColorEnums.Black);
            var slots = parkingMgmt.GetParkingSlotsInformation().AsEnumerable();
            var result = filter.Filter(slots, criteria);
            Assert.IsTrue(result.Count() == 2);
            Assert.IsTrue(result.ElementAt(1).VehicleInSlot.VehicleNumber == "KA-03-8981");
            Assert.IsTrue(result.ElementAt(0).VehicleInSlot.VehicleNumber == "KA-03-8986");

            var criteria1 = new VehicleNumberCriteria("KA-03-8981");
            var result1 = filter.Filter(slots, criteria1);
            Assert.IsTrue(result1.Count() == 1);
            Assert.IsTrue(result1.ElementAt(0).VehicleInSlot.VehicleNumber == "KA-03-8981");

            var criteria3 = new ConjunctionCriteria<ParkingSlot>(criteria, criteria1);
            var result2= filter.Filter(slots, criteria3);
            Assert.IsTrue(result2.Count() == 1);
            Assert.IsTrue(result2.ElementAt(0).VehicleInSlot.VehicleNumber == "KA-03-8981");
            Assert.IsTrue(result2.ElementAt(0).VehicleInSlot.VehicleColor == ColorEnums.Black);
        }

        [TestMethod]
        public void Filter_ForVehicleColorNumber_returns_Empty()
        {

            var vehicle1 = new Vehicle() { VehicleNumber = "KA-03-8986", VehicleColor = ColorEnums.Black };
            var vehicle2 = new Vehicle() { VehicleNumber = "KA-03-8981", VehicleColor = ColorEnums.Black };
            var vehicle3 = new Vehicle() { VehicleNumber = "KA-03-8982", VehicleColor = ColorEnums.Brown };
            var vehicle4 = new Vehicle() { VehicleNumber = "KA-03-8983", VehicleColor = ColorEnums.Yellow };
            var vehicle5 = new Vehicle() { VehicleNumber = "KA-03-8984", VehicleColor = ColorEnums.Magenta };


            IParkingManagement parkingMgmt = new ParkingManagement(5);

            parkingMgmt.AddVehicleToSlot(vehicle1);
            parkingMgmt.AddVehicleToSlot(vehicle2);
            parkingMgmt.AddVehicleToSlot(vehicle3);
            parkingMgmt.AddVehicleToSlot(vehicle4);
            parkingMgmt.AddVehicleToSlot(vehicle5);

            var slots = parkingMgmt.GetParkingSlotsInformation().AsEnumerable();
            var filter = new ParkingSlotFilter();
            var criteria = new VehicleColorCriteria(ColorEnums.Red);
            var result = filter.Filter(slots, criteria);
            Assert.IsTrue(result.Count() == 0);

            var criteria1 = new VehicleNumberCriteria("KA-03-8981");
            var result1 = filter.Filter(slots, criteria1);
            Assert.IsTrue(result1.Count() == 1);
            Assert.IsTrue(result1.ElementAt(0).VehicleInSlot.VehicleNumber == "KA-03-8981");

            var criteria3 = new ConjunctionCriteria<ParkingSlot>(criteria, criteria1);
            var result2 = filter.Filter(slots, criteria3);
            Assert.IsTrue(result2.Count() == 0);

            var criteria4 = new VehicleNumberCriteria("KA-03-8988");
            var result3 = filter.Filter(slots, criteria4);
            Assert.IsTrue(result3.Count() == 0);

            var criteria5 = new ConjunctionCriteria<ParkingSlot>(criteria, criteria4);
            var result4 = filter.Filter(slots, criteria5);
            Assert.IsTrue(result4.Count() == 0);


        }
    }
}
