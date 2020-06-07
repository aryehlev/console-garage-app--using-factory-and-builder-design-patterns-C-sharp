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
            string welcomeLogo = @"

░██╗░░░░░░░██╗███████╗██╗░░░░░░█████╗░░█████╗░███╗░░░███╗███████╗  ████████╗░█████╗░  ██╗░░░░░██╗░░░░░░██████╗░
░██║░░██╗░░██║██╔════╝██║░░░░░██╔══██╗██╔══██╗████╗░████║██╔════╝  ╚══██╔══╝██╔══██╗  ██║░░░░░██║░░░░░██╔════╝░
░╚██╗████╗██╔╝█████╗░░██║░░░░░██║░░╚═╝██║░░██║██╔████╔██║█████╗░░  ░░░██║░░░██║░░██║  ██║░░░░░██║░░░░░██║░░██╗░
░░████╔═████║░██╔══╝░░██║░░░░░██║░░██╗██║░░██║██║╚██╔╝██║██╔══╝░░  ░░░██║░░░██║░░██║  ██║░░░░░██║░░░░░██║░░╚██╗
░░╚██╔╝░╚██╔╝░███████╗███████╗╚█████╔╝╚█████╔╝██║░╚═╝░██║███████╗  ░░░██║░░░╚█████╔╝  ███████╗███████╗╚██████╔╝
░░░╚═╝░░░╚═╝░░╚══════╝╚══════╝░╚════╝░░╚════╝░╚═╝░░░░░╚═╝╚══════╝  ░░░╚═╝░░░░╚════╝░  ╚══════╝╚══════╝░╚═════╝░

░██████╗░░█████╗░██████╗░░█████╗░░██████╗░███████╗██╗
██╔════╝░██╔══██╗██╔══██╗██╔══██╗██╔════╝░██╔════╝██║
██║░░██╗░███████║██████╔╝███████║██║░░██╗░█████╗░░██║
██║░░╚██╗██╔══██║██╔══██╗██╔══██║██║░░╚██╗██╔══╝░░╚═╝
╚██████╔╝██║░░██║██║░░██║██║░░██║╚██████╔╝███████╗██╗
░╚═════╝░╚═╝░░╚═╝╚═╝░░╚═╝╚═╝░░╚═╝░╚═════╝░╚══════╝╚═╝";
            Console.WriteLine(welcomeLogo);
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

        static string buildMenuFromEnum(Type i_enumType, Enum i_valueToIgnore=null)
        {
            StringBuilder sb = new StringBuilder();
            int modesCounter = 1;
            foreach (string enumValue in Enum.GetNames(i_enumType))
            {
                if (i_valueToIgnore == null || !enumValue.Equals(i_valueToIgnore.ToString()))
                {
                    sb.Append($"{modesCounter} - {enumValue}");
                    sb.Append(Environment.NewLine);
                    modesCounter++;
                }
            }

            return sb.ToString();
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
                float currentAirPreasure = 0.0f;
                string nameOfOwner = "";
                string phoneNumOfOwner = "";
                string wheelManufactor = "";
                string model = "";
                Object[] optionalParams;

                string getVehicleTypeMsg = @"
Please pick a status mode to sort the license plate numbers by:
{0}";
                string.Format(getVehicleTypeMsg, buildMenuFromEnum(typeof(eVehicleType)));
                string getEnergyTypeMsg = @"
Please pick the fuel type of your vehicle:
{0}";
                string.Format(getEnergyTypeMsg, buildMenuFromEnum(typeof(eEnergyType)));
                string getCurrentEnergyLevelMsg = @"
Please enter the current amount of {0}:";
                string getCurrentAirPresureMsg = @"
Please enter the current air presure:";
                string getNameOfOwnerMsg = @"
Please enter the vehicle's owner name (letters only):";
                string getPhoneNumOfOwnerMsg = @"
Please enter the owner's phone number (digits only):";
                string getWheelManufactorMsg = @"
Please enter the wheels manufactor:";
                string getModel = @"
Please enter the vehicle's model:";


                Console.WriteLine(getVehicleTypeMsg);
                vehicleType = getVehicleType();
                Console.WriteLine(getEnergyTypeMsg);
                energyType = getEnergyTypeInput(true);
                if (energyType == eEnergyType.Electric)
                {
                    string.Format(getCurrentEnergyLevelMsg, "battery");
                }
                else
                {
                    string.Format(getCurrentEnergyLevelMsg, "gas");
                }
                Console.WriteLine(getCurrentEnergyLevelMsg);
                currentEnergyLevel = getFloat(0);
                Console.WriteLine(getCurrentAirPresureMsg);
                currentAirPreasure = getFloat(0);
                Console.WriteLine(getNameOfOwnerMsg);
                nameOfOwner = getValidString(false, true);
                Console.WriteLine(getPhoneNumOfOwnerMsg);
                phoneNumOfOwner = getValidString(true, false);
                Console.WriteLine(getWheelManufactorMsg);
                wheelManufactor = getValidString(false, false);
                Console.WriteLine(getModel);
                model = getValidString(false, false);

                if (vehicleType == eVehicleType.Car)
                {
                    optionalParams = new object[2];
                    string getColourMsg = @"
Please enter the current amount of {0}:";
                    string getNumOfDoorsMsg = @"
Please enter the current air presure:";

                    Console.WriteLine(getColourMsg);
                    optionalParams[0] = "";
                    Console.WriteLine(getNumOfDoorsMsg);
                    optionalParams[1] = "";
                }
                else if (vehicleType == eVehicleType.MotorCycle)
                {
                    optionalParams = new object[2];
                    string getTypeOfLicenseMsg = @"
Please enter the current amount of {0}:";
                    string getCcMsg = @"
Please enter the motorcycle engine cc:";

                    Console.WriteLine(getTypeOfLicenseMsg);
                    optionalParams[0] = "";
                    Console.WriteLine(getCcMsg);
                    optionalParams[1] = getFloat(1);
                }
                else
                {
                    optionalParams = new object[2];
                    string getHasHazardasCargoMsg = @"
Please enter the current amount of {0}:";
                    string getVolumeOfCargoMsg = @"
Please enter the current air presure:";

                    Console.WriteLine(getHasHazardasCargoMsg);
                    optionalParams[0] = "";
                    Console.WriteLine(getVolumeOfCargoMsg);
                    optionalParams[1] = "";
                }

                bool tryAgain = true;
                while (tryAgain)
                {
                    try
                    {
                        s_Garage.AddVehicle(vehicleType, model, licenseNumber, energyType, nameOfOwner, phoneNumOfOwner,
                            wheelManufactor, currentAirPreasure, currentEnergyLevel, optionalParams);
                    }
                    catch (ValueOutOfRangeException e)
                    {

                    }
                }
            }
        }

        // mode 2
        public static void GetAllLicenseNumbers()
        {
            eStatus sortBy = eStatus.None;
            StringBuilder licenseNumbersStr = new StringBuilder();
            string getLicensePlatesMsg = @"
please pick a status mode to sort the license plate numbers by:
{0}";
            string.Format(getLicensePlatesMsg, buildMenuFromEnum(typeof(eStatus)));
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
{1}";
            Console.WriteLine(getLicenseNumberMsg);
            licenseNumber = getLicenseNumberInput(false, out _);
            string.Format(getStatusMsg, licenseNumber, buildMenuFromEnum(typeof(eStatus), eStatus.None));
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
{0}";
            string.Format(getFuelTypeMsg, buildMenuFromEnum(typeof(eEnergyType), eEnergyType.Electric));
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
                energyType = getEnergyTypeInput(false);
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
                    licenseNumber = ParsingValidation.checkValidString(false, false);
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
                catch (FormatException e)
                {
                    Console.WriteLine($"Your input is {e.Message}. Try again");
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
                    vehicleStatus = (eStatus)ParsingValidation.checkEnum(i_AllowNone, typeof(eStatus));
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
                    vehicleType = (eVehicleType)ParsingValidation.checkEnum(true, typeof(eVehicleType));
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

        private static eEnergyType getEnergyTypeInput(bool i_AllowElectric)
        {
            eEnergyType energyType = eEnergyType.Soler;
            bool tryAgain = true;
            while (tryAgain)
            {
                try
                {
                    energyType = (eEnergyType)ParsingValidation.checkEnum(i_AllowElectric, typeof(eEnergyType));
                    tryAgain = false;
                }
                catch (FormatException e)
                {
                    int enum_length = Enum.GetNames(typeof(eEnergyType)).Length;
                    if (!i_AllowElectric)
                    {
                        enum_length--;
                    }
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
                    energyAmount = ParsingValidation.checkFloat(1.0f);
                    s_Garage.FllEnergy(i_licenseNumber, energyAmount, i_energyType);
                    tryAgain = false;
                }
                catch (FormatException e)
                {
                    Console.WriteLine($"Your input was '{e.Message}' but the amount must be a positive float. Try again");
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

        private static string getValidString(bool i_DigitsOnly, bool i_LettersOnly)
        {
            string validString = "";
            bool tryAgain = true;
            while (tryAgain)
            {
                try
                {
                    validString = ParsingValidation.checkValidString(i_DigitsOnly, i_LettersOnly);
                    tryAgain = false;
                }
                catch (FormatException e)
                {
                    Console.WriteLine($"Your input is {e.Message}. Try again");
                }
            }

            return validString;
        }

        private static float getFloat(float i_MinValue)
        {
            float validFloat = 0.0f;
            bool tryAgain = true;
            while (tryAgain)
            {
                try
                {
                    validFloat = ParsingValidation.checkFloat(i_MinValue);
                    tryAgain = false;
                }
                catch (FormatException e)
                {
                    Console.WriteLine($"Your input was '{e.Message}' but the amount must be a positive float. Try again");
                }
            }

            return validFloat;
        }
    }
}