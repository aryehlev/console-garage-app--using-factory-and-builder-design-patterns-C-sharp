using Ex03.GarageLogic;
using Ex02.ConsoleUtils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.ConsoleUI
{
    class UserInterface
    {
        internal static Garage s_Garage = new Garage();  // PROBLEMATIC???
        public static void WelcomeMsg()
        {
            Console.WriteLine("Hello and Welcome to LLG garage!");
        }

        public static void GoodbyeMsg()
        {
            Console.WriteLine("It was a pleasure! hit enter to exit.");
            Console.ReadLine();
        }

        public static void BackToModePickerMsg()
        {
            Console.WriteLine("Hit enter to go back to the main menu...");
            Console.ReadLine();
            Screen.Clear();
        }

        public static int ModePicker()
        {
            int modePicked = 0;
            string modePickerMsg = @"
please pick an action from the folowing:
1 - Register a new vehicle to the garage
2 - Show all license plate numbers (sortable)
3 - Change a vehicle status
4 - Fill the tires of a registered vehicle
5 - Fuel a motor vehicle
6 - charge an electric vehicle
7 - Show the details of a registered vehicle
0 - Exit the system";

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


        // mode 1
        public static void AddVehicle()
        {
            string licenseNumber = "";
            string getLicenseNumberMsg = @"
In order to change the status of a vehicle, please enter its license number:";
            Console.WriteLine(getLicenseNumberMsg);
            licenseNumber = getLicenseNumberInput(true, out bool islicenseNumberRegistered);
            if (islicenseNumberRegistered)
            {
                s_Garage.ChangeStatusOfVehicle(licenseNumber, eStatus.InRepair);
            }
            else
            {
                eVehicleType vehicleType = eVehicleType.Car;
                eEnergyType energyType = eEnergyType.Electric;
                float currentEnergyLevel = 0.0f;
                string nameOfOwner = "";
                string phoneNumOfOwner = "";
                string wheelManufactor = "";
                float currentAirPresure = 0.0f;
                string model = "";

                string getVehicleTypeMsg = @"
please pick a status mode to sort the license plate numbers by:
1 - Car
2 - MotorCycle,
3 - Truck";
                string getEnergyTypeMsg = @"
please pick the fuel type of your vehicle:
1 - Soler
2 - Octan95,
3 - Octan96
4 - Octan98";
                string isCarElectricMsg = @"
is your car has an electric?
1 - Soler
2 - Octan95,
3 - Octan96
4 - Octan98"
                string getCurrentAirPresure = @"
Please enter the current air presure:";
                string getNameOfOwnerMsg = @"
Please enter the vehicle's owner name:";
                string getPhoneNumOfOwnerMsg = @"
Please enter the owner's phone number:";
                string getWheelManufactorMsg = @"
Please enter the wheels manufactor:";
                string getCurrentEnergyLevelMsg = @"
Please enter the current amount of {0}:";
                string getModel = @"
Please enter the vehicle's model:";

                Console.WriteLine(getVehicleTypeMsg);
                vehicleType = getVehicleType();
                Console.WriteLine(getEnergyTypeMsg);
                energyType = getEnergyTypeInput();



            }
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
            sortBy = getVehicleStatusInput(true);
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
            string getLicenseNumberMsg = @"
In order to change the status of a vehicle, please enter its license number:";
            string getStatusMsg = @"
please pick a status mode to set for license number {0}:
1 - Paid
2 - Fixed,
3 - In repair";

            Console.WriteLine(getLicenseNumberMsg);
            licenseNumber = getLicenseNumberInput(false, out _);
            string.Format(getStatusMsg, licenseNumber);
            Console.WriteLine(getStatusMsg);
            eStatus statusToSet = getVehicleStatusInput(false);
            s_Garage.ChangeStatusOfVehicle(licenseNumber, statusToSet);
        }

        // mode 4
        public static void FillTiresToMax()
        {
            string licenseNumber;
            string fillTiresToMaxMsg = @"
In order to fill the vehicle's tires to max, please enter its license number:";

            Console.WriteLine(fillTiresToMaxMsg);
            licenseNumber = getLicenseNumberInput(false, out _);
            s_Garage.FillTiresToMax(licenseNumber);
        }

        // modes 5 and 6
        public static void FillEnergy(bool i_IsElectric)
        {
            string licenseNumber;
            eEnergyType energyType = eEnergyType.Electric;
            string getLicenseNumberMsg = @"
In order to {0} the vehicle, please enter its license number:";
            string getFuelTypeMsg = @"
please pick a fuel type to refuel the vehicle:
1 - Soler
2 - Octan95,
3 - Octan96
4 - Octan98";
            string getEnergyAmountMsg = @"
Please enter the desired amount to fill ({0}):";

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
            licenseNumber = getLicenseNumberInput(false, out _);
            if (!i_IsElectric)
            {
                Console.WriteLine(getFuelTypeMsg);
                energyType = getEnergyTypeInput();
            }

            Console.WriteLine(getEnergyAmountMsg);
            getEnergyAmountInputAndFill(licenseNumber, energyType);
        }

        // mode 7
        public static void GetVehicleData()
        {
            string licenseNumber = "";
            string getVehicleDataMsg = @"
In order to get the vehicle's data, please enter its license number:";

            Console.WriteLine(getVehicleDataMsg);
            licenseNumber = getLicenseNumberInput(false, out _);
            Console.WriteLine(s_Garage.GetVehicleData(licenseNumber));
        }

        private static string getLicenseNumberInput(bool i_AllowNonRegistered, out bool o_IslicenseNumberRegistered)
        {
            o_IslicenseNumberRegistered = false;
            string licenseNumber = "";
            bool tryAgain = true;
            while (tryAgain)
            {
                try
                {
                    licenseNumber = ParsingValidation.checkLicenseNumber();
                    if (s_Garage.IsVehicleRegistered(licenseNumber))
                    {
                        o_IslicenseNumberRegistered = true;
                        tryAgain = false;
                    }
                    else
                    {
                        if (i_AllowNonRegistered)
                        {
                            tryAgain = false;
                        }
                        else
                        {
                            Console.WriteLine($"This license number is not registered. Try again");
                        }
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine($"Your input was empty. Try again");
                }
            }

            return licenseNumber;
        }

        private static eStatus getVehicleStatusInput(bool i_AllowNone)
        {
            eStatus vehicleStatus = eStatus.None;
            bool tryAgain = true;
            while (tryAgain)
            {
                try
                {
                    vehicleStatus = ParsingValidation.checkVehicleStatus(i_AllowNone);
                    tryAgain = false;
                }
                catch (FormatException e)
                {
                    int enum_length = Enum.GetNames(typeof(eStatus)).Length;
                    int maxDigit = i_AllowNone ? enum_length : enum_length - 1;
                    Console.WriteLine($"Your input was '{e.Message}' but the status must be a digit between 1 - {maxDigit}. Try again");
                }
            }

            return vehicleStatus;
        }

        private static eVehicleType getVehicleType()
        {
            eVehicleType vehicleType = eVehicleType.Car;
            bool tryAgain = true;
            while (tryAgain)
            {
                try
                {
                    vehicleType = ParsingValidation.checkVehicleType();
                    tryAgain = false;
                }
                catch (FormatException e)
                {
                    int enum_length = Enum.GetNames(typeof(eVehicleType)).Length;
                    Console.WriteLine($"Your input was '{e.Message}' but the vehicle type must be a digit between 1 - {enum_length}. Try again");
                }
            }

            return vehicleType;
        }

        private static eEnergyType getEnergyTypeInput()
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
                    int enum_length = Enum.GetNames(typeof(eEnergyType)).Length;
                    Console.WriteLine($"Your input was '{e.Message}' but the fuel type must be a digit between 1 - {enum_length}. Try again");
                }
            }

            return energyType;
        }

        private static void getEnergyAmountInputAndFill(string i_licenseNumber, eEnergyType i_energyType)
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