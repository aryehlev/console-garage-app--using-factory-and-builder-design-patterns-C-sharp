using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Text;

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
                catch (FormatException e)
                {
                    Console.WriteLine($"Your input was '{e.Message}' but mode must be a digit between 0 - 7. Try again");
                }
            }
            return 0;
        }


        // mode 2
        public static void GetAllLicenseNumbers()
        {
            eStatus sortBy = eStatus.None;
            StringBuilder licenseNumbersStr = new StringBuilder();
            string getLicensePlatesMsg = @"
please pick a status mode to sort the license plate numbers by:
1 - Paid
2 - Fixed,
3 - In repair
4 - No sorting";

            Console.WriteLine(getLicensePlatesMsg);
            sortBy = getVehicleStatus(true);
            List<string> licenseNumbersList = s_Garage.GetAllLicenseNumbers(sortBy);
            foreach (string licenseNumber in licenseNumbersList)
            {
                licenseNumbersStr.Append(licenseNumber);
                licenseNumbersStr.Append(Environment.NewLine);
            }
            Console.WriteLine(licenseNumbersStr.ToString());
        }

        // mode 3
        public static void ChangeStatusOfVehicle()
        {
            string licenseNumber = "";
            string getLicenseNumberMsg = 
@"In order to change the status of a vehicle, please enter its license number:";
            string getStatusMsg = @"
please pick a status mode to set for license number {0}:
1 - Paid
2 - Fixed,
3 - In repair";

            Console.WriteLine(getLicenseNumberMsg);
            licenseNumber = getLicenseNumber();
            string.Format(getStatusMsg, licenseNumber);
            Console.WriteLine(getStatusMsg);
            eStatus statusToSet = getVehicleStatus(false);
            s_Garage.ChangeStatusOfVehicle(licenseNumber, statusToSet);
        }

        // mode 4
        public static void FillTiresToMax()
        {
            string licenseNumber = "";
            string fillTiresToMaxMsg =
@"In order to fill the vehicle's tires to max, please enter its license number:";

            Console.WriteLine(fillTiresToMaxMsg);
            licenseNumber = getLicenseNumber();
            s_Garage.FillTiresToMax(licenseNumber);
        }

        // modes 5 and 6
        public static void FillEnergy(bool i_IsElectric)
        {
            string licenseNumber = "";
            eEnergyType energyType = eEnergyType.Electric;
            float energyAmount = 0;
            string getLicenseNumberMsg =
@"In order to {0} the vehicle, please enter its license number:";
            string getFuelTypeMsg = @"
please pick a fuel type to refuel the vehicle:
1 - Soler
2 - Octan95,
3 - Octan96
4 - Octan98";
            string getEnergyAmountMsg = @"
please enter your amount to fill ({0}):";

            if (i_IsElectric)
            {
                string.Format(getLicenseNumberMsg, "charge");
                string.Format(getEnergyAmountMsg, "minutes for charging");
            }
            else
            {
                string.Format(getLicenseNumberMsg, "refuel");
                string.Format(getEnergyAmountMsg, "litres of gas");
            }

            Console.WriteLine(getLicenseNumberMsg);
            licenseNumber = getLicenseNumber();
            if (!i_IsElectric)
            {
                Console.WriteLine(getFuelTypeMsg);
                energyType = getEnergyType();
            }

            Console.WriteLine(getEnergyAmountMsg);
            getEnergyAmountAndFill(licenseNumber, energyType);
        }

        // mode 7
        public static void GetVehicleData()
        {
            string licenseNumber = "";
            string getVehicleDataMsg =
@"In order to get the vehicle's data, please enter its license number:";

            Console.WriteLine(getVehicleDataMsg);
            licenseNumber = getLicenseNumber();
            Console.WriteLine(s_Garage.GetVehicleData(licenseNumber));
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
                catch (FormatException e)
                {
                    Console.WriteLine($"Your input was empty. Try again");
                }
            }

            return licenseNumber;
        }

        public static eStatus getVehicleStatus(bool i_allowNone)
        {
            eStatus vehicleStatus = eStatus.None;
            bool tryAgain = true;
            while (tryAgain)
            {
                try
                {
                    vehicleStatus = i_allowNone ? ParsingValidation.checkVehicleStatusWithNone() : ParsingValidation.checkVehicleStatus();
                    tryAgain = false;
                }
                catch (FormatException e)
                {
                    int maxDigit = i_allowNone ? 4 : 3;
                    Console.WriteLine($"Your input was '{e.Message}' but the status must be a digit between 1 - {maxDigit}. Try again");
                }
            }

            return vehicleStatus;
        }

        public static eEnergyType getEnergyType()
        {
            eEnergyType energyType = eEnergyType.Soler;
            bool tryAgain = true;
            while (tryAgain)
            {
                try
                {
                    energyType = ParsingValidation.checkEnergyType();
                    tryAgain = false;
                }
                catch (FormatException e)
                {
                    Console.WriteLine($"Your input was '{e.Message}' but the fuel type must be a digit between 1 - 4. Try again");
                }
            }

            return energyType;
        }

        public static void getEnergyAmountAndFill(string i_licenseNumber, eEnergyType i_energyType)
        {
            float energyAmount = 0.0f;
            bool tryAgain = true;
            while (tryAgain)
            {
                try
                {
                    energyAmount = ParsingValidation.checkEnergyAmount();
                    s_Garage.FllEnergy(i_licenseNumber, energyAmount, i_energyType);
                    tryAgain = false;
                }
                catch (FormatException e)
                {
                    Console.WriteLine($"Your input was '{e.Message}' but the amount must be a positive integer. Try again");
                }
                catch (ValueOutOfRangeException e)
                {
                    Console.WriteLine($"The amount should be between {e.MinValue} - {e.MaxValue} (and you entered {energyAmount}). Try again");
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine($"{e.Message}. Try again");
                }
            }
        }
    }
}