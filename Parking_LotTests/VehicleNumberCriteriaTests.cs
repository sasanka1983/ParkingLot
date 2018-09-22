using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parking_Lot.BusinessObjects;
using Parking_Lot.Implementations;
using Parking_Lot.Interfaces;

namespace Parking_LotTests
{
    [TestClass]
    public class VehicleNumberCriteriaTests
    {
        [TestMethod]
        public void IsCriteriaMet_returns_True()
        {
            var vehicle1 = new Vehicle() { VehicleNumber = "KA-03-8986" };
            
            IParkingManagement parkingMgmt = new ParkingManagement(5);

            parkingMgmt.AddVehicleToSlot(vehicle1);
            
            var slots = parkingMgmt.GetParkingSlotsInformation();
            var criteria=new VehicleNumberCriteria("KA-03-8986");
            Assert.IsTrue(criteria.IsCriteriaMet(slots.ToArray()[0]));
        }

        [TestMethod]
        public void IsCriteriaMet_returns_False()
        {
            var vehicle1 = new Vehicle() { VehicleNumber = "KA-03-8986" };

            IParkingManagement parkingMgmt = new ParkingManagement(5);

            parkingMgmt.AddVehicleToSlot(vehicle1);

            var slots = parkingMgmt.GetParkingSlotsInformation();
            var criteria = new VehicleNumberCriteria("KA-03-8987");
            Assert.IsFalse(criteria.IsCriteriaMet(slots.ToArray()[0]));
        }
    }
}
