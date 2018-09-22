using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parking_Lot.BusinessObjects;
using Parking_Lot.Interfaces;

namespace Parking_Lot.Implementations
{
    public class SlotNumberCriteria:IParkingSlotCriteria<ParkingSlot>
    {
        private int _slotNumber;

        public SlotNumberCriteria(int slotNumber)
        {
            _slotNumber = slotNumber;
        }
        public bool IsCriteriaMet(ParkingSlot t)
        {
            return t.SlotNumber == _slotNumber;
        }
    }
}
