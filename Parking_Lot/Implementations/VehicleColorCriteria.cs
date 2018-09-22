using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parking_Lot.BusinessObjects;
using Parking_Lot.Enums;
using Parking_Lot.Interfaces;

namespace Parking_Lot.Implementations
{
    public class VehicleColorCriteria:IParkingSlotCriteria<ParkingSlot>
    {
        private ColorEnums _color;

        public VehicleColorCriteria(ColorEnums color)
        {
            _color = color;
        }

        public bool IsCriteriaMet(ParkingSlot p)
        {
            return p.VehicleInSlot.VehicleColor == _color;
        }
    }
}
