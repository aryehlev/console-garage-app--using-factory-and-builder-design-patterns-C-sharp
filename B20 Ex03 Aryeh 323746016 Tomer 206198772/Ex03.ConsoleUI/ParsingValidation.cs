using Ex03.GarageLogic;
using System;
using System.Text.RegularExpressions;

namespace Ex03.ConsoleUI
{
    class ParsingValidation
    {  
        //internal static int checkModePicker()
        //{
        //    string input = Console.ReadLine();
        //    if (input.Length > 1 || !char.IsDigit(input[0]) || int.Parse(input) > 7)
        //    {
        //        throw new FormatException(input);
        //    }

        //    return int.Parse(input);
        //}

        ////internal static Enum checkEnum(bool i_AllowFirstValueOfEnum, Type i_enumType)
        ////{
        ////    Enum[] enumValues = (Enum[])Enum.GetValues(i_enumType);
        ////    string input = Console.ReadLine();
        ////    int numOfOptions = i_AllowFirstValueOfEnum ? enumValues.Length : enumValues.Length - 1;
        ////    if (!int.TryParse(input, out int result) || result <= 0 || result > numOfOptions)
        ////    {
        ////        throw new FormatException(input);
        ////    }

        ////    return enumValues[result - 1];
        ////}

        ////internal static eStatus checkVehicleStatus(bool i_allowNone)
        ////{
        ////    eStatus[] vehicleStatuses = (eStatus[])Enum.GetValues(typeof(eStatus));
        ////    string input = Console.ReadLine();
        ////    int numOfOptions = i_allowNone ? vehicleStatuses.Length : vehicleStatuses.Length - 1;
        ////    if (!int.TryParse(input, out int result) || result <= 0 || result > numOfOptions)
        ////    {
        ////        throw new FormatException(input);
        ////    }

        ////    return vehicleStatuses[result - 1];
        ////}

        //internal static string checkValidString(string i_Input, bool i_DigitsOnly, bool i_LettersOnly)
        //{
        //    if (string.IsNullOrEmpty(i_Input))
        //    {
        //        throw new FormatException("empty");
        //    }
        //    if (i_DigitsOnly && !Regex.IsMatch(i_Input, @"^[0-9]+$"))
        //    {
        //        throw new FormatException("not digits only");
        //    }
        //    if (i_LettersOnly && !Regex.IsMatch(i_Input, @"^[a-zA-Z]+$"))
        //    {
        //        throw new FormatException("not letters only");
        //    }

        //    return i_Input;
        //}

        ////internal static eVehicleType checkVehicleType()
        ////{
        ////    eVehicleType vehicleType = eVehicleType.Car;
        ////    string input = Console.ReadLine();
        ////    switch (input)
        ////    {
        ////        case "1":
        ////            vehicleType = eVehicleType.Car;
        ////            break;
        ////        case "2":
        ////            vehicleType = eVehicleType.MotorCycle;
        ////            break;
        ////        case "3":
        ////            vehicleType = eVehicleType.Truck;
        ////            break;
        ////        default:
        ////            throw new FormatException(input);
        ////    }

        ////    return vehicleType;
        ////}

        ////internal static eEnergyType checkEnergyType(bool i_allowElectric)
        ////{
        ////    eEnergyType energyType = eEnergyType.Octan95;
        ////    string input = Console.ReadLine();
        ////    switch (input)
        ////    {
        ////        case "1":
        ////            energyType = eEnergyType.Soler;
        ////            break;
        ////        case "2":
        ////            energyType = eEnergyType.Octan95;
        ////            break;
        ////        case "3":
        ////            energyType = eEnergyType.Octan96;
        ////            break;
        ////        case "4":
        ////            energyType = eEnergyType.Octan98;
        ////            break;
        ////        case "5":
        ////            if (i_allowElectric)
        ////            {
        ////                energyType = eEnergyType.Electric;
        ////                break;
        ////            }
        ////            else
        ////            {
        ////                throw new FormatException(input);
        ////            }
        ////        default:
        ////            throw new FormatException(input);
        ////    }

        ////    return energyType;
        ////}

        //internal static float checkFloat(string i_Input, float i_MinValue)
        //{
        //    if (!float.TryParse(i_Input, out float parsed) || parsed < i_MinValue)
        //    {
        //        throw new FormatException(i_Input);
        //    }

        //    return parsed;
        //}
    }
}