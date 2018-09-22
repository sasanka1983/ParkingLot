using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parking_Lot.BusinessObjects;
using Parking_Lot.Implementations;
using Parking_Lot.Interfaces;

namespace Parking_LotTests
{
    [TestClass]
    public class ParkingManagementTests
    {
        [TestMethod]
        public void AddVehicleToSlot_returns_SlotNumber_Happypath()
        {
            var vehicle1 = new Vehicle() {VehicleNumber = "KA-03-8986"};
            var vehicle2 = new Vehicle() { VehicleNumber = "KA-03-8981" };
            var vehicle3 = new Vehicle() { VehicleNumber = "KA-03-8982" };
            var vehicle4 = new Vehicle() { VehicleNumber = "KA-03-8983" };
            var vehicle5 = new Vehicle() { VehicleNumber = "KA-03-8984" };
            var vehicle6 = new Vehicle() { VehicleNumber = "KA-03-8985" };

            IParkingManagement parkingMgmt= new ParkingManagement(5);

            var slotNumber1 = parkingMgmt.AddVehicleToSlot(vehicle1);
            var slotNumber2 = parkingMgmt.AddVehicleToSlot(vehicle2);
            var slotNumber3 = parkingMgmt.AddVehicleToSlot(vehicle3);
            var slotNumber4 = parkingMgmt.AddVehicleToSlot(vehicle4);
            var slotNumber5 = parkingMgmt.AddVehicleToSlot(vehicle5);
            var slotNumber6 = parkingMgmt.AddVehicleToSlot(vehicle6);

            Assert.AreEqual(1,slotNumber1);
            Assert.AreEqual(2, slotNumber2);
            Assert.AreEqual(3, slotNumber3);
            Assert.AreEqual(4, slotNumber4);
            Assert.AreEqual(5, slotNumber5);
            Assert.AreEqual(-1,slotNumber6);

        }
        [TestMethod]
        public void UnParkVehicleFromSlot_returns_SlotNumber_Happypath()
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

            var t=parkingMgmt.UnParkVehicleFromSlot("KA-03-8981");
            var vehicle = parkingMgmt.UnParkVehicleFromSlot(4);

            Assert.AreEqual("KA-03-8983",vehicle.VehicleNumber);
            Assert.AreEqual(2, t);
            
        }
        [TestMethod]
        public void UnParkVehicleFromSlot_returns_Null_Happypath()
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

            var t = parkingMgmt.UnParkVehicleFromSlot("KA-03-8987");
            var vehicle = parkingMgmt.UnParkVehicleFromSlot(7);

            Assert.IsNull(vehicle);
            Assert.AreEqual(-1, t);

        }
        [TestMethod]
        public void AlocateCorrectSequence_returns_CorrectSlotNumber_Happypath()
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

            var t = parkingMgmt.UnParkVehicleFromSlot("KA-03-8981");
            var vehicle = parkingMgmt.UnParkVehicleFromSlot(4);

            Assert.AreEqual("KA-03-8983", vehicle.VehicleNumber);
            Assert.AreEqual(2, t);

            var vehicle6 = new Vehicle() { VehicleNumber = "KA-03-9982" };
            var vehicle7 = new Vehicle() { VehicleNumber = "KA-03-9983" };
            var vehicle8 = new Vehicle() { VehicleNumber = "KA-03-9984" };

            var allocatedParking1=parkingMgmt.AddVehicleToSlot(vehicle6);
            var allocatedParking2 = parkingMgmt.AddVehicleToSlot(vehicle7);
            Assert.AreEqual(2, allocatedParking1);
            Assert.AreEqual(4, allocatedParking2);
            parkingMgmt.UnParkVehicleFromSlot(1);
            var allocatedParking3 = parkingMgmt.AddVehicleToSlot(vehicle8);
            Assert.AreEqual(1, allocatedParking3);
        }
        [TestMethod]
        public void GetParkingSlotsInformation_returns_count()
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

            Assert.IsTrue(parkingMgmt.GetParkingSlotsInformation().Count==5);
        }
    }
}
