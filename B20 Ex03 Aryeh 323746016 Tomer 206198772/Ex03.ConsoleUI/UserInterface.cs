using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    class UserInterface
    {
        public static void WelcomeScreen()
        {
            Console.WriteLine("Hello and Welcome to LLG garage! 🚗");
        }

        public static int ModePicker()
        {
            int modePicked = 0;
            string modePickerMsg = @"
please pick an action from the folowing:
1 - Register a new vehicle to the garage       🚕
2 - Show all license plate numbers (sortable)  🆔
3 - Change a vehicle status                    📄
4 - Fill the tires of a registered vehicle     🚐
5 - Fuel a motor vehicle                       ⛽
6 - charge an electric vehicle                 ⚡
7 - Show the details of a registered vehicle   🕵️‍
0 - Exit the system                            ❌";
            Console.WriteLine(modePickerMsg);
            bool tryAgain = true;
            while (tryAgain)
            {
                try
                {
                    modePicked = ParsingValidation.checkModePicker();
                    tryAgain = false;
                }
                catch (FormatException fe)
                {
                    Console.WriteLine("Mode must be a digit between 0 - 7");
                }
            }
            return 0;
        }

    }
}