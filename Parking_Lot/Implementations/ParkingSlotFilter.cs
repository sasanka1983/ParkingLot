using System;
using System.Collections.Generic;
using Parking_Lot.BusinessObjects;
using Parking_Lot.Interfaces;

namespace Parking_Lot.Implementations
{
    public class ParkingSlotFilter:IParkingLotFilter<ParkingSlot>
    {
        public IEnumerable<ParkingSlot> Filter(IEnumerable<ParkingSlot> items, IParkingSlotCriteria<ParkingSlot> t)
        {
            foreach (var item in items)
            {
                if (t.IsCriteriaMet(item))
                {
                    yield return item;
                }
            }
            
        }
    }
}
