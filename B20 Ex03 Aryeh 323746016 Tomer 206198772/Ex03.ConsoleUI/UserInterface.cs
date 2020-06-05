using Ex03.GarageLogic;
using System;

namespace Ex03.ConsoleUI
{
    class UserInterface
    {
        protected static Garage s_Garage = new Garage();
        public static void WelcomeScreen()
        {
            Console.WriteLine("Hello and Welcome to LLG garage!");
        }

        public static void BackToModePickerMsg()
        {
            Console.WriteLine("Hit enter to go back to the main Menu");
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
                    Console.WriteLine($"Your input was '{fe.Message}' but mode must be a digit between 0 - 7. Try again");
                }
            }
            return 0;
        }


        // mode 2
        public static void GetAllLicenseNumbers()
        {
            bool sortVehicleStatus = true;
            eStatus sortBy = eStatus.Fixed;
            string getLicensePlatesMsg = @"
please pick a status mode to sort the license plate numbers by:
1 - Paid
2 - Fixed,
3 - In repair
4 - No sorting";

            Console.WriteLine(getLicensePlatesMsg);
            bool tryAgain = true;
            while (tryAgain)
            {
                try
                {
                    sortBy = ParsingValidation.checkVehicleStatus(out sortVehicleStatus);
                    tryAgain = false;
                }
                catch (FormatException fe)
                {
                    Console.WriteLine($"Your input was '{fe.Message}' but the status must be a digit between 1 - 4. Try again");
                }
            }

            string allLicenseNumbers = sortVehicleStatus ? s_Garage.GetAllLicenseNumbers(sortBy) : s_Garage.GetAllLicenseNumbers(false);
            Console.WriteLine(allLicenseNumbers);
        }

        // mode 3
        public static void ChangeStatusOfVehicle()
        {
            string licenseNumber = "";
            string getLicenseNumberMsg = 
@"In order to change the status of a vehicle, please enter its license number";
            string getStatusMsg = @"
please pick a status mode to set for license number {0}:
1 - Paid
2 - Fixed,
3 - In repair";

            Console.WriteLine(getLicenseNumberMsg);
            licenseNumber = getLicenseNumber();
            string.Format(getStatusMsg, licenseNumber);
            Console.WriteLine(getStatusMsg);
            eStatus statusToSet = eStatus.Fixed;
            bool tryAgain = true;
            while (tryAgain)
            {
                try
                {
                    statusToSet = ParsingValidation.checkVehicleStatus();
                    tryAgain = false;
                }
                catch (FormatException fe)
                {
                    Console.WriteLine($"Your input was '{fe.Message}' but the status must be a digit between 1 - 3. Try again");
                }
            }

            s_Garage.ChangeStatusOfVehicle(licenseNumber, statusToSet);
        }

        // mode 4
        public static void FillTiresToMax()
        {
            string licenseNumber = "";
            string fillTiresToMaxMsg =
@"In order to fill the vehicle's tires to max, please enter its license number";

            Console.WriteLine(fillTiresToMaxMsg);
            licenseNumber = getLicenseNumber();
            s_Garage.FillTiresToMax(licenseNumber);
        }

        // mode 5 and 6
        public static void FillEnergy(bool i_IsElectric)
        {
            string licenseNumber = "";
            eEnergyType energyType = eEnergyType.Electric;
            string getLicenseNumberMsg =
@"In order to {0} the vehicle, please enter its license number";
            string getFuelTypeMsg = @"
please pick a fuel type to refuel vehicle number {0}:
1 - Soler
2 - Octan95,
3 - Octan96
4 - Octan98";
            if (i_IsElectric)
            {
                string.Format(getLicenseNumberMsg, "charge");
            }
            else
            {
                string.Format(getLicenseNumberMsg, "refuel");
            }
            Console.WriteLine(getLicenseNumberMsg);
            licenseNumber = getLicenseNumber();
            if (!i_IsElectric)
            {
                Console.WriteLine(getFuelTypeMsg);
                bool tryAgain = true;
                while (tryAgain)
                {
                    try
                    {
                        energyType = ParsingValidation.checkEnergyType();
                        tryAgain = false;
                    }
                    catch (FormatException fe)
                    {
                        Console.WriteLine($"Your input was '{fe.Message}' but the fuel type must be a digit between 1 - 4. Try again");
                    }
                }
            }


        }

        public static string getLicenseNumber()
        {
            string licenseNumber = "";
            bool tryAgain = true;
            while (tryAgain)
            {
                try
                {
                    licenseNumber = ParsingValidation.checkLicenseNumber();
                    if (s_Garage.IsVehicleRegistered(licenseNumber))
                    {
                        tryAgain = false;
                    }
                    else
                    {
                        Console.WriteLine($"This license number is not registered. Try again");
                    }
                }
                catch (FormatException fe)
                {
                    Console.WriteLine($"Your input was empty. Try again");
                }
            }

            return licenseNumber;
        }
    }
}