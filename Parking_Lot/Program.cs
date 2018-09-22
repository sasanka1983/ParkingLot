using System;
using System.Linq;
using Parking_Lot.BusinessObjects;
using Parking_Lot.Constants;
using Parking_Lot.Enums;
using Parking_Lot.Implementations;
using Parking_Lot.Interfaces;

namespace Parking_Lot
{
    class Program
    {
        private static bool _interactive = true;
        static void Main(string[] args)
        {
            string[] argsList;
            IParkingManagement _parkingManagement = new ParkingManagement();
            if (args.Length == 0)
            {
                Console.WriteLine("Please provide File Name with path or commands");
                while (_interactive)
                {
                    Console.WriteLine();
                    var input = Console.ReadLine();
                    Console.WriteLine();
                    argsList = input.Split(' ');
                    if (argsList.Length == 1 && argsList[0] != Commands.Status && argsList[0] != Commands.Exit)
                    {
                        ReadFile(_parkingManagement, argsList);
                    }
                    else
                    {
                        ProcessCommands(_parkingManagement, argsList);
                    }
                    
                }
            }
            else
            {
                if (args.Length == 1 && args[0]!=Commands.Status && args[0]!=Commands.Exit)
                {
                    ReadFile(_parkingManagement, args);
                }
                Console.WriteLine("Invalid arguments");
            }





        }

        private static void ReadFile(IParkingManagement parkingManagement, string[] argsList)
        {
            string[] lines = System.IO.File.ReadAllLines(argsList[0]);
            foreach (var line in lines)
            {
                var commands = line.Split(' ');
                ProcessCommands(parkingManagement, commands);
            }
        }
        private static void ProcessCommands(IParkingManagement parkingManagement, string[] commands)
        {
            switch (commands[0])
            {
                case Commands.CreateParkingLot:
                    {
                        if (commands.Length == 2)
                        {
                            int slots;
                            if (int.TryParse(commands[1], out slots))
                            {
                                parkingManagement.MaxParkingSlots = slots;
                                Console.WriteLine("Created a parking lot with {0} slots", slots);
                            }
                            else
                            {
                                Console.WriteLine("please Provide numeric value for command {0}", Commands.CreateParkingLot);
                            }
                        }
                        else
                        {
                            Console.WriteLine("please Provide numeric parameter value for command {0}", Commands.CreateParkingLot);
                        }
                    }
                    break;
                case Commands.Park:
                    {
                        if (parkingManagement.MaxParkingSlots <= 0)
                        {
                            Console.WriteLine("Please allocate parking slots");
                            return;
                        }
                        if (commands.Length == 3)
                        {
                            ColorEnums color;
                            if (ColorEnums.TryParse(commands[2], true, out color))
                            {
                                var slotNumber = parkingManagement.AddVehicleToSlot(new Vehicle() { VehicleNumber = commands[1], VehicleColor = color });
                                if (slotNumber == -1)
                                {
                                    Console.WriteLine("Sorry, parking lot is full");
                                    return;
                                }
                                Console.WriteLine("Allocated slot number:{0}", slotNumber);
                            }
                            else
                            {
                                Console.WriteLine("Please provide appropriate Color.");
                            }
                        }
                        else
                        {
                            Console.Write("Please provide exact 2 parameters. format- park [vehicleNumber] [color]");
                        }
                    }
                    break;
                case Commands.Leave:
                    {
                        if (parkingManagement.MaxParkingSlots <= 0)
                        {
                            Console.WriteLine("Please allocate parking slots");
                            return;
                        }
                        if (commands.Length == 2)
                        {
                            int slotNumber;
                            if (int.TryParse(commands[1], out slotNumber))
                            {
                                var vehicle = parkingManagement.UnParkVehicleFromSlot(slotNumber);
                                if (vehicle == null)
                                {
                                    Console.WriteLine("Slot number {0} does not exist", slotNumber);
                                    return;
                                }
                                Console.WriteLine("Slot number {0} is free", slotNumber);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Please provide appropriate Slot Number");
                        }
                    }
                    break;
                case Commands.RegNumbersForCarsWithColor:
                    {
                        if (parkingManagement.MaxParkingSlots <= 0)
                        {
                            Console.WriteLine("Please allocate parking slots");
                            return;
                        }
                        if (commands.Length == 2)
                        {
                            ColorEnums color;
                            if (ColorEnums.TryParse(commands[1], true, out color))
                            {
                                var colorCriteria = new VehicleColorCriteria(color);
                                var filledSlots = parkingManagement.GetParkingSlotsInformation().AsEnumerable();
                                var filter = new ParkingSlotFilter();
                                var matchedItems = filter.Filter(filledSlots, colorCriteria);
                                if (matchedItems.Count() == 0)
                                {
                                    Console.WriteLine("Not Found");
                                    return;
                                }
                                foreach (var item in matchedItems)
                                {
                                    Console.Write(item.VehicleInSlot.VehicleNumber + ",");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Please provide appropriate Color");
                            }

                        }
                        else
                        {
                            Console.Write("Please provide exact Color name as parameter.");
                        }
                    }
                    break;
                case Commands.SlotNumberForRegistrationNumber:
                    {
                        if (parkingManagement.MaxParkingSlots <= 0)
                        {
                            Console.WriteLine("Please allocate parking slots");
                            return;
                        }
                        if (commands.Length == 2)
                        {
                            string number = commands[1];
                            if (!string.IsNullOrEmpty(number))
                            {
                                var numberCriteria = new VehicleNumberCriteria(number);
                                var filledSlots = parkingManagement.GetParkingSlotsInformation().AsEnumerable();
                                var filter = new ParkingSlotFilter();
                                var matchedItems = filter.Filter(filledSlots, numberCriteria);
                                if (matchedItems.Count() == 0)
                                {
                                    Console.WriteLine("Not Found");
                                    return;
                                }
                                foreach (var item in matchedItems)
                                {
                                    Console.Write(item.SlotNumber + ",");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Please provide appropriate vehicle number");
                            }

                        }
                        else
                        {
                            Console.Write("Please provide exact vehicle number as parameter.");
                        }
                    }
                    break;
                case Commands.SlotNumbersForCarsWithColor:
                    {
                        if (parkingManagement.MaxParkingSlots <= 0)
                        {
                            Console.WriteLine("Please allocate parking slots");
                            return;
                        }
                        if (commands.Length == 2)
                        {
                            ColorEnums color;
                            if (ColorEnums.TryParse(commands[1], true, out color))
                            {
                                var colorCriteria = new VehicleColorCriteria(color);
                                var filledSlots = parkingManagement.GetParkingSlotsInformation().AsEnumerable();
                                var filter = new ParkingSlotFilter();
                                var matchedItems = filter.Filter(filledSlots, colorCriteria);
                                if (matchedItems.Count() == 0)
                                {
                                    Console.WriteLine("Not Found");
                                    return;
                                }
                                foreach (var item in matchedItems)
                                {
                                    Console.Write(item.SlotNumber + ",");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Please provide appropriate Color");
                            }

                        }
                        else
                        {
                            Console.Write("Please provide exact Color name as parameter.");
                        }
                    }
                    break;
                case Commands.Exit:
                    {
                        _interactive = false;
                    }
                    break;
                case Commands.Status:
                {
                    if (parkingManagement.MaxParkingSlots <= 0)
                    {
                        Console.WriteLine("Please allocate parking slots");
                        return;
                        }

                    var slots=parkingManagement.GetParkingSlotsInformation().AsEnumerable();
                    if (slots.Count() == 0)
                    {
                        Console.WriteLine("Not Found");
                        return;
                    }
                    Console.WriteLine("Slot No      Registration No.        Colour");
                    Console.WriteLine();
                    foreach (var slot in slots)
                    {
                        Console.WriteLine("{0}          {1}         {2}",slot.SlotNumber,slot.VehicleInSlot.VehicleNumber,slot.VehicleInSlot.VehicleColor.ToString());
                    }
                }
                    break;
                default:
                {
                    Console.WriteLine("Please check your command");
                }
                    break;
            }
            Console.WriteLine();
        }
    }
}
