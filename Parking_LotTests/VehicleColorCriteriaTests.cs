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
    public class VehicleColorCriteriaTests
    {
        [TestMethod]
        public void IsCriteriaMet_returns_True()
        {
            var vehicle1 = new Vehicle() { VehicleNumber = "KA-03-8986",VehicleColor = ColorEnums.Black};

            IParkingManagement parkingMgmt = new ParkingManagement(5);

            parkingMgmt.AddVehicleToSlot(vehicle1);

            var slots = parkingMgmt.GetParkingSlotsInformation();
            var criteria = new VehicleColorCriteria(ColorEnums.Black);
            Assert.IsTrue(criteria.IsCriteriaMet(slots.ToArray()[0]));
        }

        [TestMethod]
        public void IsCriteriaMet_returns_False()
        {
            var vehicle1 = new Vehicle() { VehicleNumber = "KA-03-8986" ,VehicleColor = ColorEnums.Aqua};

            IParkingManagement parkingMgmt = new ParkingManagement(5);

            parkingMgmt.AddVehicleToSlot(vehicle1);

            var slots = parkingMgmt.GetParkingSlotsInformation();
            var criteria = new VehicleColorCriteria(ColorEnums.Green);
            Assert.IsFalse(criteria.IsCriteriaMet(slots.ToArray()[0]));
        }
    }
}
