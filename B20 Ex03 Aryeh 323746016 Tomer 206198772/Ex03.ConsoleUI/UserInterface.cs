using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;
using Ex02.ConsoleUtils;

namespace Ex03.ConsoleUI
{
    internal class UserInterface
    {
        internal static Garage s_Garage = new Garage();

        internal static void WelcomeMsg()
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

        internal static void GoodbyeMsg()
        {
            Console.WriteLine(@"
It was a pleasure! hit enter to exit.

 ________  ________  ________  ________  ________      ___    ___ _______      
|\   ____\|\   __  \|\   __  \|\   ___ \|\   __  \    |\  \  /  /|\  ___ \     
\ \  \___|\ \  \|\  \ \  \|\  \ \  \_|\ \ \  \|\ /_   \ \  \/  / | \   __/|    
 \ \  \  __\ \  \\\  \ \  \\\  \ \  \ \\ \ \   __  \   \ \    / / \ \  \_|/__  
  \ \  \|\  \ \  \\\  \ \  \\\  \ \  \_\\ \ \  \|\  \   \/  /  /   \ \  \_|\ \ 
   \ \_______\ \_______\ \_______\ \_______\ \_______\__/  / /      \ \_______\
    \|_______|\|_______|\|_______|\|_______|\|_______|\___/ /        \|_______|
                                                     \|___|/                   ");
            Console.ReadLine();
        }

        internal static void BackToModePickerMsg()
        {
            Console.WriteLine("\nHit enter to go back to the main menu...");
            Console.ReadLine();
            Screen.Clear();
        }

        internal static int ModePicker()
        {
            int modePicked = 0;
            string modePickerMsg = @"
please pick an action from the following:
1 - Register a new vehicle to the garage
2 - Show all license plate numbers (sortable)
3 - Change a vehicle status
4 - Fill the tires of a registered vehicle
5 - Fuel a motor vehicle
6 - charge an electric vehicle
7 - Show the details of a registered vehicle
0 - Exit the system

========================================================
You can type 'EXIT' at any time to go back to the menu
========================================================";

            Console.WriteLine(modePickerMsg);
            bool tryAgain = true;
            while (tryAgain)
            {
                try
                {
                    string input = Console.ReadLine();
                    modePicked = CheckInput.CheckModePicker(input);
                    tryAgain = false;
                }
                catch (FormatException e)
                {
                    Console.WriteLine($"Your input was '{e.Message}' but mode must be a digit between 0 - 7. Try again");
                }
            }

            Console.Clear();
            return modePicked;
        }

        private static string buildMenuFromEnum(Type i_EnumType, Enum i_ValueToIgnore = null)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string enumValue in Enum.GetNames(i_EnumType))
            {
                if (i_ValueToIgnore == null || !enumValue.Equals(i_ValueToIgnore.ToString()))
                {
                    sb.Append($"{enumValue}");
                    sb.Append(Environment.NewLine);
                }
            }

            return sb.ToString();
        }

        // mode 1
        internal static void AddVehicle()
        {
            string licenseNumber = string.Empty;
            string getLicenseNumberMsg = @"
In order to add a new vehicle to the system, please enter its license number:";
            Console.WriteLine(getLicenseNumberMsg);
            licenseNumber = GetInput.GetLicenseNumber(true, out bool isLicenseNumberRegistered);
            if (isLicenseNumberRegistered)
            {
                Console.WriteLine($"You changed vehicle number {licenseNumber} to 'inRepair' status");
                s_Garage.ChangeStatusOfVehicle(licenseNumber, eStatus.InRepair);
            }
            else
            {
                eVehicleType vehicleType = eVehicleType.Car;
                string model = string.Empty;
                string nameOfOwner = string.Empty;
                string phoneNumOfOwner = string.Empty;

                bool isElectric = false;
                float currentEnergyLevel = 0.0f;
                float currentAirPressure = 0.0f;
                string wheelManufacturer = string.Empty;
                object[] uniqueFeatures = null;

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
Is the vehicle electric? (yes / no)";
                string getCurrentEnergyLevelMsg = @"
Please enter the current amount of {0}:";
                string getCurrentAirPressureMsg = @"
Please enter the current air pressure:";
                
                string getWheelManufacturerMsg = @"
Please enter the wheels manufacturer:";
                string uniqueFeatureMsg = @"
Please enter {0}, possible values are:
{1}";
                string successMsg = @"
Registration complete!";

                string failsMsg = @"
Registration could not be completed missing data";

                Console.WriteLine(getVehicleTypeMsg);
                vehicleType = GetInput.GetVehicleType();
                Console.WriteLine(getModel);
                model = GetInput.GetValidString(false, false);
                Console.WriteLine(getNameOfOwnerMsg);
                nameOfOwner = GetInput.GetValidString(false, true);
                Console.WriteLine(getPhoneNumOfOwnerMsg);
                phoneNumOfOwner = GetInput.GetValidString(true, false);
                VehicleBuilder newVehicle = s_Garage.BuildVehicle(vehicleType, model, licenseNumber, nameOfOwner, phoneNumOfOwner);
                
                if (newVehicle.CanBeElectric())
                {
                    Console.WriteLine(getIsElectricMsg);
                    isElectric = GetInput.GetIsElectricOrNot();
                }
                
                getCurrentEnergyLevelMsg = string.Format(getCurrentEnergyLevelMsg, isElectric ? "battery" : "gas");
                Console.WriteLine(getCurrentEnergyLevelMsg);
                currentEnergyLevel = GetInput.GetValidFloat();
                setEnergyUI(newVehicle, isElectric, currentEnergyLevel);

                Console.WriteLine(getWheelManufacturerMsg);
                wheelManufacturer = GetInput.GetValidString(false, false);
                Console.WriteLine(getCurrentAirPressureMsg);
                currentAirPressure = GetInput.GetValidFloat();               
                setWheelsUI(newVehicle, wheelManufacturer, currentAirPressure);

                uniqueFeatures = GetInput.GetUniqueFeatures(uniqueFeatureMsg, newVehicle);
                
                newVehicle.SetUniqueFeatures(uniqueFeatures);

                if(s_Garage.TryAddVehicle(newVehicle, licenseNumber))
                {
                    Console.WriteLine(successMsg);
                }
                else
                {
                    Console.Out.WriteLine(failsMsg);
                }
            }
        }
        
        private static void setWheelsUI(VehicleBuilder i_VehicleBeingBuilt, string i_WheelManufacturer, float i_CurrentAirPressure)
        {
            bool tryAgain = true;
            while (tryAgain)
            {
                try
                {
                    i_VehicleBeingBuilt.SetWheels(i_WheelManufacturer, i_CurrentAirPressure);
                    tryAgain = false;
                }
                catch (ValueOutOfRangeException e)
                {
                    Console.WriteLine($"{e.Message}. The amount must be between {e.MinValue} to {e.MaxValue}. Try again");
                    i_CurrentAirPressure = GetInput.GetValidFloat(e.MinValue, e.MaxValue);
                }
            }
        }

        private static void setEnergyUI(VehicleBuilder i_VehicleBeingBuilt, bool i_IsElectric, float i_CurrentEnergyLevel)
        {
            bool tryAgain = true;
            while (tryAgain)
            {
                try
                {
                    i_VehicleBeingBuilt.SetEnergy(i_IsElectric, i_CurrentEnergyLevel);
                    tryAgain = false;
                }
                catch (ValueOutOfRangeException e)
                {
                    Console.WriteLine($"{e.Message}. The amount must be between {e.MinValue} to {e.MaxValue}. Try again");
                    i_CurrentEnergyLevel = GetInput.GetValidFloat(e.MinValue, e.MaxValue);
                }
            }
        }

        // mode 2
        internal static void AllLicensePlateMode()
        {
            eStatus sortBy = eStatus.None;
            StringBuilder licenseNumbersStr = new StringBuilder();
            string getLicensePlatesMsg = @"
please pick a status mode to sort the license plate numbers by:
{0}";
            string successMsg = @"
The license numbers requested are:
{0}";
            string failMsg = @"
No license numbers found";
            getLicensePlatesMsg = string.Format(getLicensePlatesMsg, buildMenuFromEnum(typeof(eStatus)));
            Console.WriteLine(getLicensePlatesMsg);
            sortBy = GetInput.GetVehicleStatus(false);
            List<string> licenseNumbersList = s_Garage.GetAllLicensePlates(sortBy);
            foreach (string licenseNumber in licenseNumbersList)
            {
                licenseNumbersStr.Append(licenseNumber);
                licenseNumbersStr.Append(Environment.NewLine);
            }

            successMsg = string.Format(successMsg, licenseNumbersStr);
            Console.WriteLine(licenseNumbersStr.Length > 0 ? successMsg : failMsg);
        }

        // mode 3
        internal static void ChangeStatusOfVehicleMode()
        {
            string licenseNumber = string.Empty;
            string getLicenseNumberMsg = @"
In order to change the status of a vehicle, please enter its license number:";
            string getStatusMsg = @"
please pick a status mode to set for license number {0}:
{1}";
            string successMsg = @"
vehicle number {0} is now on {1} status";
            Console.WriteLine(getLicenseNumberMsg);
            licenseNumber = GetInput.GetLicenseNumber(false, out _);
            getStatusMsg = string.Format(getStatusMsg, licenseNumber, buildMenuFromEnum(typeof(eStatus), eStatus.None));
            Console.WriteLine(getStatusMsg);
            eStatus statusToSet = GetInput.GetVehicleStatus(false);
            s_Garage.ChangeStatusOfVehicle(licenseNumber, statusToSet);
            successMsg = string.Format(successMsg, licenseNumber, statusToSet);
            Console.WriteLine(successMsg);
        }

        // mode 4
        public static void FillTiresToMax()
        {
            string licenseNumber = string.Empty;
            string fillTiresToMaxMsg = @"
In order to fill the vehicle's tires to max, please enter its license number:";
            string successMsg = @"
The tires of vehicle number {0} is now full";

            Console.WriteLine(fillTiresToMaxMsg);
            licenseNumber = GetInput.GetLicenseNumber(false, out _);
            s_Garage.FillTiresToMax(licenseNumber);
            successMsg = string.Format(successMsg, licenseNumber);
            Console.WriteLine(successMsg);
        }

        // modes 5 and 6
        public static void FillEnergy(bool i_IsElectric)
        {
            string licenseNumber = string.Empty;
            eEnergyType energyType = eEnergyType.Electric;
            float energyToFill = 0.0f;
            string getLicenseNumberMsg = @"
In order to {0} the vehicle, please enter its license number:";
            string getEnergyAmountMsg = @"
Please enter the desired amount of {0} to fill ({1}):";
            string successMsg = @"
{0} vehicle number {1} is complete";

            getLicenseNumberMsg = i_IsElectric
                                      ? string.Format(getLicenseNumberMsg, "charge")
                                      : string.Format(getLicenseNumberMsg, "refuel");

            Console.WriteLine(getLicenseNumberMsg);
            licenseNumber = GetInput.GetLicenseNumber(false, out _);
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
                getEnergyAmountMsg = i_IsElectric
                                         ? string.Format(getEnergyAmountMsg, energyType, "minutes for charging")
                                         : string.Format(getEnergyAmountMsg, energyType, "liters of gas");
                Console.WriteLine(getEnergyAmountMsg);
                energyToFill = GetInput.GetValidFloat();
                fillEnergyUI(licenseNumber, energyToFill, energyType);
                successMsg = string.Format(successMsg, energyType == eEnergyType.Electric ? "charging" : "refueling", licenseNumber);
                Console.WriteLine(successMsg);
            }
        }

        private static void fillEnergyUI(string i_LicenseNumber,  float i_AmountToFill, eEnergyType i_EnergyType)
        {
            bool tryAgain = true;
            while (tryAgain)
            {
                try
                {
                    s_Garage.FllEnergy(i_LicenseNumber, i_AmountToFill, i_EnergyType);
                    tryAgain = false;
                }
                catch (ValueOutOfRangeException e)
                {
                    Console.WriteLine($"{e.Message}, must be between {e.MinValue} - {e.MaxValue}");
                    i_AmountToFill = GetInput.GetValidFloat();
                }
            }
        }

        // mode 7
        public static void VehicleDataMode()
        {
            string licenseNumber = string.Empty;
            string getVehicleDataMsg = @"
In order to get the vehicle's data, please enter its license number:";

            Console.WriteLine(getVehicleDataMsg);
            licenseNumber = GetInput.GetLicenseNumber(false, out _);
            Console.WriteLine(s_Garage.GetVehicleData(licenseNumber));
        }
    }
}