using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parking_Lot.BusinessObjects;

namespace Parking_Lot.Interfaces
{
   public interface IParkingManagement
   {
       int MaxParkingSlots { get; set; }
       int AddVehicleToSlot(Vehicle vehicle);
       int UnParkVehicleFromSlot(string vehicleNumber);
       IReadOnlyCollection<ParkingSlot> GetParkingSlotsInformation();
       Vehicle UnParkVehicleFromSlot(int slotNumber);
   }
}
