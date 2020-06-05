using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    class ParsingValidation
    {
        internal static int checkModePicker()
        {
            string input = Console.ReadLine();
            if (input.Length > 1 || !Char.IsDigit(input[0]) || input[0] > 7)
            {
                throw new FormatException();
            }

            return int.Parse(input);
        }
        //internal static float checkLicsenseNumber()
        //{

        //}

        //static eEnergyType checkEnergyType()
        //{

        //}

        //static eStatus checkVehicleStatus()
        //{

        //}
    }
}