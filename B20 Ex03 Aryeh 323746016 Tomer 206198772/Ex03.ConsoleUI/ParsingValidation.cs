using Ex03.GarageLogic;
using System;

namespace Ex03.ConsoleUI
{
    class ParsingValidation
    {  
        internal static int checkModePicker()
        {
            string input = Console.ReadLine();
            if (input.Length > 1 || !char.IsDigit(input[0]) || int.Parse(input) > 7)
            {
                throw new FormatException(input);
            }

            return int.Parse(input);
        }

        internal static eStatus checkVehicleStatus(bool i_allowNone)
        {
            eStatus vehicleStatus = eStatus.Paid;
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    vehicleStatus = eStatus.Paid;
                    break;
                case "2":
                    vehicleStatus = eStatus.Fixed;
                    break;
                case "3":
                    vehicleStatus = eStatus.InRepair;
                    break;
                case "4":
                    if (i_allowNone)
                    {
                        vehicleStatus = eStatus.None;
                        break;
                    }
                    else
                    {
                        throw new FormatException(input);
                    }
                default:
                    throw new FormatException(input);
            }

            return vehicleStatus;
        }

        internal static string checkLicenseNumber()
        {
            string input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                throw new FormatException();
            }

            return input;
        }

        internal static eVehicleType checkVehicleType()
        {
            eVehicleType vehicleType = eVehicleType.Car;
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    vehicleType = eVehicleType.Car;
                    break;
                case "2":
                    vehicleType = eVehicleType.MotorCycle;
                    break;
                case "3":
                    vehicleType = eVehicleType.Truck;
                    break;
                default:
                    throw new FormatException(input);
            }

            return vehicleType;
        }

        internal static eEnergyType checkEnergyType()
        {
            eEnergyType energyType = eEnergyType.Octan95;
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    energyType = eEnergyType.Soler;
                    break;
                case "2":
                    energyType = eEnergyType.Octan95;
                    break;
                case "3":
                    energyType = eEnergyType.Octan96;
                    break;
                case "4":
                    energyType = eEnergyType.Octan98;
                    break;
                default:
                    throw new FormatException(input);
            }

            return energyType;
        }

        internal static float checkEnergyAmount()
        {
            string input = Console.ReadLine();
            if (!float.TryParse(input, out float energyAmount) || energyAmount <= 0)
            {
                throw new FormatException(input);
            }

            return energyAmount;
        }
    }
}