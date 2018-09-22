using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parking_Lot.BusinessObjects;
using Parking_Lot.Interfaces;

namespace Parking_Lot.Implementations
{
    public class VehicleNumberCriteria: IParkingSlotCriteria<ParkingSlot>
    {
        private string _vehicleNumber;
        public VehicleNumberCriteria(string vehicleNumber)
        {
            _vehicleNumber = vehicleNumber;
        }
        public bool IsCriteriaMet(ParkingSlot t)
        {
            return t.VehicleInSlot.VehicleNumber == _vehicleNumber;
        }
    }
}
