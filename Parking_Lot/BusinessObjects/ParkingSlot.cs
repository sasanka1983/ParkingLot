using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking_Lot.BusinessObjects
{
    public class ParkingSlot
    {
        public int SlotNumber { get; set; }
        public Vehicle VehicleInSlot { get; set; }
    }
}
