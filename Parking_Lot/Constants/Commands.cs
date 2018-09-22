using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking_Lot.Constants
{
    public static class Commands
    {
        public const string CreateParkingLot = "create_parking_lot";
        public const string Park = "park";
        public const string Leave = "leave";
        public const string Status = "status";
        public const string RegNumbersForCarsWithColor = "registration_numbers_for_cars_with_colour";
        public const string SlotNumbersForCarsWithColor = "slot_numbers_for_cars_with_colour";
        public const string SlotNumberForRegistrationNumber="slot_number_for_registration_number";
        public const string Exit = "exit";
    }
}
