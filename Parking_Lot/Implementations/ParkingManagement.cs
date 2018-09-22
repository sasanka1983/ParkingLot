using System;
using System.Collections.Generic;
using Parking_Lot.BusinessObjects;
using Parking_Lot.Interfaces;

namespace Parking_Lot.Implementations
{
    public class ParkingManagement : IParkingManagement
    {
        public int MaxParkingSlots
        {
            get { return _parkingSlots;}
            set { _parkingSlots = value; }
        }
        public ParkingManagement()
        {
            
        }
        public ParkingManagement(int maxParkingSlots)
        {
            _parkingSlots = maxParkingSlots;
        }
        private List<ParkingSlot> _slots = new List<ParkingSlot>();
        private int _parkingSlots;
        public virtual int AddVehicleToSlot(Vehicle vehicle)
        {
            for (int slotNumber = 1; slotNumber <= _parkingSlots; slotNumber++)
            {
                bool occupied = false;
                foreach (var slot in _slots)
                {
                    if (slotNumber == slot.SlotNumber)
                    {
                        occupied = true;
                        break;
                    }
                }

                if (!occupied)
                {
                    _slots.Add(new ParkingSlot() { SlotNumber = slotNumber, VehicleInSlot = vehicle });
                    return slotNumber;
                }
            }
            return -1;
        }

        public int UnParkVehicleFromSlot(string vehicleNumber)
        {
            var parkingSlot = _slots.Find(x =>
                x.VehicleInSlot.VehicleNumber.Equals(vehicleNumber, StringComparison.InvariantCultureIgnoreCase));
            _slots.Remove(parkingSlot);
            if (parkingSlot == null)
            {
                return -1;
            }
            return parkingSlot.SlotNumber;
        }
        public Vehicle UnParkVehicleFromSlot(int slotNumber)
        {
            var parkingSlot = _slots.Find(x =>
                x.SlotNumber==slotNumber);
            _slots.Remove(parkingSlot);
            if (parkingSlot == null)
            {
                return null;

            }
            return parkingSlot.VehicleInSlot;
        }
        public virtual IReadOnlyCollection<ParkingSlot> GetParkingSlotsInformation()
        {
            return _slots.AsReadOnly();
        }
    }
}
