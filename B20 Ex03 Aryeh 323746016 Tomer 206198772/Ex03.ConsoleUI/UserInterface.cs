using Ex03.GarageLogic;
using Ex02.ConsoleUtils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

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
                    string input = Console.ReadLine();
                    modePicked = checkModePicker(input);
                    tryAgain = false;
                }
                catch (FormatException e)
                {
                    Console.WriteLine($"Your input was '{e.Message}' but mode must be a digit between 0 - 7. Try again");
                }
            }
            return modePicked;
        }

        static string buildMenuFromEnum(Type i_enumType, Enum i_valueToIgnore=null)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string enumValue in Enum.GetNames(i_enumType))
            {
                if (i_valueToIgnore == null || !enumValue.Equals(i_valueToIgnore.ToString()))
                {
                    sb.Append($"{enumValue}");
                    sb.Append(Environment.NewLine);
                }
            }

            return sb.ToString();
        }

        // mode 1
        public static void AddVehicle()
        {
            string licenseNumber = "";
            string getLicenseNumberMsg = @"
In order to add a new vehicle to the system, please enter its license number:";
            Console.WriteLine(getLicenseNumberMsg);
            licenseNumber = getLicenseNumberInput(true, out bool islicenseNumberRegistered);
            if (islicenseNumberRegistered)
            {
                Console.WriteLine($"You changed vehicle number {licenseNumber} to 'inRepair' status");
                s_Garage.ChangeStatusOfVehicle(licenseNumber, eStatus.InRepair);
            }
            else
            {
                eVehicleType vehicleType = eVehicleType.Car;
                string model = "";
                string nameOfOwner = "";
                string phoneNumOfOwner = "";

                bool isElectric = false;
                float currentEnergyLevel = 0.0f;
                float currentAirPreasure = 0.0f;
                string wheelManufactor = "";
                Object[] optionalParams = null;

                string getVehicleTypeMsg = @"
Please pick a vehicle type:
{0}";
                getVehicleTypeMsg = string.Format(getVehicleTypeMsg, buildMenuFromEnum(typeof(eVehicleType)));
                string getModel = @"
Please enter the vehicle's model:";
                string getNameOfOwnerMsg = @"
Please enter the vehicle's owner name (letters only):";
                string getPhoneNumOfOwnerMsg = @"
Please enter the owner's phone number (digits only):";



                string getIsElectricMsg = @"
Is the vehicle electric? (True / False)";
                string getCurrentEnergyLevelMsg = @"
Please enter the current amount of {0}:";
                string getCurrentAirPresureMsg = @"
Please enter the current air presure:";
                
                string getWheelManufactorMsg = @"
Please enter the wheels manufactor:";



                Console.WriteLine(getVehicleTypeMsg);
                vehicleType = getAndCheckVehicleType();
                Console.WriteLine(getModel);
                model = getValidString(false, false);
                Console.WriteLine(getNameOfOwnerMsg);
                nameOfOwner = getValidString(false, true);
                Console.WriteLine(getPhoneNumOfOwnerMsg);
                phoneNumOfOwner = getValidString(true, false);

                Vehicle newVehicle = s_Garage.AddVehicle(vehicleType, model, licenseNumber, nameOfOwner, phoneNumOfOwner);
                if (newVehicle.CanBeElectric())
                {
                    Console.WriteLine(getEnergyTypeMsg);
                    energyType = getAndCheckEnergyTypeInput(true);
                    if (energyType == eEnergyType.Electric)
                    {
                        getCurrentEnergyLevelMsg = string.Format(getCurrentEnergyLevelMsg, "battery");
                    }
                    else
                    {
                        getCurrentEnergyLevelMsg = string.Format(getCurrentEnergyLevelMsg, "gas");
                    }
                }
                Console.WriteLine(getCurrentEnergyLevelMsg);
                currentEnergyLevel = getFloat(0.0f);
                Console.WriteLine(getCurrentAirPresureMsg);
                currentAirPreasure = getFloat(0.0f);               
                Console.WriteLine(getWheelManufactorMsg);
                wheelManufactor = getValidString(false, false);

                optionalParams = new object[] { eColour.Black, 4 };
                //newVehicle.GetSpecificFeatureDescription();
                //optionalParams = newVehicle.ParseSpecificFeatures();

                newVehicle.SetParamaters(energyType, wheelManufactor, currentAirPreasure, currentEnergyLevel, optionalParams);
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
            getLicensePlatesMsg = string.Format(getLicensePlatesMsg, buildMenuFromEnum(typeof(eStatus)));
            Console.WriteLine(getLicensePlatesMsg);
            sortBy = getAndCheckVehicleStatusInput(false);
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
            getStatusMsg = string.Format(getStatusMsg, licenseNumber, buildMenuFromEnum(typeof(eStatus), eStatus.None));
            Console.WriteLine(getStatusMsg);
            eStatus statusToSet = getAndCheckVehicleStatusInput(false);
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
            string licenseNumber = "";
            eEnergyType energyType = eEnergyType.Electric;
            string getLicenseNumberMsg = @"
In order to {0} the vehicle, please enter its license number:";
            string getEnergyAmountMsg = @"
Please enter the desired amount of {0} to fill ({1}):";

            if (i_IsElectric)
            {
                getLicenseNumberMsg = string.Format(getLicenseNumberMsg, "charge");
            }
            else
            {
                getLicenseNumberMsg = string.Format(getLicenseNumberMsg, "refuel");
            }

            Console.WriteLine(getLicenseNumberMsg);
            licenseNumber = getLicenseNumberInput(false, out _);
            energyType = s_Garage.GetEnergyType(licenseNumber);

            if (i_IsElectric && energyType != eEnergyType.Electric)
            {
                Console.WriteLine($"vehicle no. {licenseNumber} can not be charged (is not electric)");
            }

            else if (!i_IsElectric && energyType == eEnergyType.Electric)
            {
                Console.WriteLine($"vehicle no. {licenseNumber} can not be refueled (is electric)");
            }

            else
            {
                if (i_IsElectric)
                {
                    getEnergyAmountMsg = string.Format(getEnergyAmountMsg, energyType, "minutes for charging");
                }
                else
                {
                    getEnergyAmountMsg = string.Format(getEnergyAmountMsg, energyType, "litres of gas");
                }
                Console.WriteLine(getEnergyAmountMsg);
                getEnergyAmountInputAndFill(licenseNumber, energyType);
            }
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
                    string input = Console.ReadLine();
                    licenseNumber = checkValidString(input, false, false);
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

        private static eStatus getAndCheckVehicleStatusInput(bool i_IgnoreNone)
        {
            string input = Console.ReadLine();
            eStatus vehicleStatus;
            while (int.TryParse(input, out _) || !Enum.TryParse(input, true, out vehicleStatus) || (i_IgnoreNone && vehicleStatus == eStatus.None))
            {
                Console.WriteLine($"Please enter only one of the values from above");
                input = Console.ReadLine();
            }

            return vehicleStatus;
        }

        private static eVehicleType getAndCheckVehicleType()
        {
            string input = Console.ReadLine();
            eVehicleType vehicleType;
            while (int.TryParse(input, out _) || !Enum.TryParse(input, true, out vehicleType))
            {
                Console.WriteLine($"Please enter only one of the values from above");
                input = Console.ReadLine();
            }

            return vehicleType;
        }

        private static eEnergyType getAndCheckEnergyTypeInput(bool i_IgnoreElectric)
        {
            string input = Console.ReadLine();
            eEnergyType energyType;
            while (int.TryParse(input, out _) || !Enum.TryParse(input, true, out energyType) || i_IgnoreElectric && energyType == eEnergyType.Electric)
            {
                Console.WriteLine($"Please enter only one of the values from above");
                input = Console.ReadLine();
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
                    string input = Console.ReadLine();
                    energyAmount = checkPositiveFloat(input, 0.0f);
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
                    string input = Console.ReadLine();
                    validString = checkValidString(input, i_DigitsOnly, i_LettersOnly);
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
                    string input = Console.ReadLine();
                    validFloat = checkPositiveFloat(input, i_MinValue);
                    tryAgain = false;
                }
                catch (FormatException e)
                {
                    Console.WriteLine($"Your input was '{e.Message}' but the amount must be a positive float. Try again");
                }
            }

            return validFloat;
        }

        // CHECKERS
        internal static int checkModePicker(string i_Input)
        {
            if (i_Input == "" || i_Input.Length > 1 || !char.IsDigit(i_Input[0]) || int.Parse(i_Input) > 7)
            {
                throw new FormatException(i_Input);
            }

            return int.Parse(i_Input);
        }

        internal static string checkValidString(string i_Input, bool i_DigitsOnly, bool i_LettersOnly)
        {
            if (string.IsNullOrEmpty(i_Input))
            {
                throw new FormatException("empty");
            }
            if (i_DigitsOnly && !Regex.IsMatch(i_Input, @"^[0-9]+$"))
            {
                throw new FormatException("not digits only");
            }
            if (i_LettersOnly && !Regex.IsMatch(i_Input, @"^[a-zA-Z]+$"))
            {
                throw new FormatException("not letters only");
            }

            return i_Input;
        }

        internal static float checkPositiveFloat(string i_Input, float i_MinValue)
        {
            if (!float.TryParse(i_Input, out float parsed) || parsed < i_MinValue)
            {
                throw new FormatException(i_Input);
            }

            return parsed;
        }
    }

}