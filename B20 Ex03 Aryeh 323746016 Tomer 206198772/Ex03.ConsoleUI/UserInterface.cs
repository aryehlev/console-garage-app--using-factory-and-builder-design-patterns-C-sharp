using Ex03.GarageLogic;
using Ex02.ConsoleUtils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.ConsoleUI
{
    class UserInterface
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
please pick an action from the folowing:
1 - Register a new vehicle to the garage
2 - Show all license plates (sortable)
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
        internal static void AddVehicle()
        {
            string licensePlate = "";
            string getLicensePlateMsg = @"
In order to add a new vehicle to the system, please enter its license plate:";
            Console.WriteLine(getLicensePlateMsg);
            licensePlate = GetInput.GetLicensePlate(true, out bool islicenseNumberRegistered);
            if (islicenseNumberRegistered)
            {
                Console.WriteLine($"You changed vehicle  {licensePlate} to 'inRepair' status");
                s_Garage.ChangeStatusOfVehicle(licensePlate, eStatus.InRepair);
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
                string getCurrentAirPresureMsg = @"
Please enter the current air presure:";
                
                string getWheelManufactorMsg = @"
Please enter the wheels manufactor:";
                string uniqueFeatureMsg = @"
Please enter {0}, possible values are:
{1}";
                string successMsg = @"
Registration complete!";

                string failMsg = @"
Could not register vehicle, missing data";

                Console.WriteLine(getVehicleTypeMsg);
                vehicleType = GetInput.GetVehicleType();
                Console.WriteLine(getModel);
                model = GetInput.GetValidString(false, false);
                Console.WriteLine(getNameOfOwnerMsg);
                nameOfOwner = GetInput.GetValidString(false, true);
                Console.WriteLine(getPhoneNumOfOwnerMsg);
                phoneNumOfOwner = GetInput.GetValidString(true, false);
                VehicleBuilder newVehicle = s_Garage.BuildVehicle(vehicleType, model, licensePlate, nameOfOwner, phoneNumOfOwner);
                
                if (newVehicle.CanBeElectric())
                {
                    Console.WriteLine(getIsElectricMsg);
                    isElectric = GetInput.GetIsElectricOrNot();
                }
                
                getCurrentEnergyLevelMsg = string.Format(getCurrentEnergyLevelMsg, isElectric ? "battery" : "gas");
                Console.WriteLine(getCurrentEnergyLevelMsg);
                currentEnergyLevel = GetInput.GetValidFloat();
                setEnergyUI(newVehicle, isElectric, currentEnergyLevel);

                Console.WriteLine(getWheelManufactorMsg);
                wheelManufactor = GetInput.GetValidString(false, false);
                Console.WriteLine(getCurrentAirPresureMsg);
                currentAirPreasure = GetInput.GetValidFloat();               
                setWheelsUI(newVehicle, wheelManufactor, currentAirPreasure);

                uniqueFeatures = GetInput.GetUniqueFeatures(uniqueFeatureMsg, newVehicle);

                newVehicle.SetUniqueFeatures(uniqueFeatures);

                if(s_Garage.TryAddVehicle(newVehicle, licensePlate))
                {
                    Console.WriteLine(successMsg);
                }
                else
                {
                    Console.WriteLine(failMsg);
                }
            }
        }
        
        private static void setWheelsUI(VehicleBuilder i_VehicleBeingBuilt, string i_WheelManufactor, float i_CurrentAirPreasure)
        {

            bool tryAgain = true;
            while (tryAgain)
            {
                try
                {
                    i_VehicleBeingBuilt.SetWheels(i_WheelManufactor, i_CurrentAirPreasure);
                    tryAgain = false;
                }
                catch (ValueOutOfRangeException e)
                {
                    Console.WriteLine($"{e.Message}. The amount must be between {e.MinValue} to {e.MaxValue}. Try again"); ;
                    i_CurrentAirPreasure = GetInput.GetValidFloat(e.MinValue, e.MaxValue);
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
            StringBuilder licensePlatesStr = new StringBuilder();
            string getLicensePlatesMsg = @"
please pick a status mode to sort the license plates by:
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
            foreach (string licensePlate in licenseNumbersList)
            {
                licensePlatesStr.Append(licensePlate);
                licensePlatesStr.Append(Environment.NewLine);
            }
            successMsg = string.Format(successMsg, licensePlatesStr.ToString());
            Console.WriteLine(licensePlatesStr.Length > 0 ? successMsg : failMsg);
        }

        // mode 3
        internal static void ChangeStatusOfVehicleMode()
        {
            string licensePlate = "";
            string getLicensePlateMsg = @"
In order to change the status of a vehicle, please enter its license plate:";
            string getStatusMsg = @"
please pick a status mode to set for license plate {0}:
{1}";
            string successMsg = @"
vehicle {0} is now on {1} status";
            Console.WriteLine(getLicensePlateMsg);
            licensePlate = GetInput.GetLicensePlate(false, out _);
            getStatusMsg = string.Format(getStatusMsg, licensePlate, buildMenuFromEnum(typeof(eStatus), eStatus.None));
            Console.WriteLine(getStatusMsg);
            eStatus statusToSet = GetInput.GetVehicleStatus(false);
            s_Garage.ChangeStatusOfVehicle(licensePlate, statusToSet);
            successMsg = string.Format(successMsg, licensePlate, statusToSet);
            Console.WriteLine(successMsg);
        }

        // mode 4
        public static void FillTiresToMax()
        {
            string licensePlate;
            string fillTiresToMaxMsg = @"
In order to fill the vehicle's tires to max, please enter its license plate:";
            string successMsg = @"
The tires of vehicle number {0} is now full";

            Console.WriteLine(fillTiresToMaxMsg);
            licensePlate = GetInput.GetLicensePlate(false, out _);
            s_Garage.FillTiresToMax(licensePlate);
            successMsg = string.Format(successMsg, licensePlate);
            Console.WriteLine(successMsg);
        }

        // modes 5 and 6
        public static void FillEnergy(bool i_IsElectric)
        {
            string licensePlate = "";
            eEnergyType energyType = eEnergyType.Electric;
            float energyToFill = 0.0f;
            string getLicensePlateMsg = @"
In order to {0} the vehicle, please enter its license plate:";
            string getEnergyAmountMsg = @"
Please enter the desired amount of {0} to fill ({1}):";
            string successMsg = @"
{0} vehicle number {1} is complete";

            if (i_IsElectric)
            {
                getLicensePlateMsg = string.Format(getLicensePlateMsg, "charge");
            }
            else
            {
                getLicensePlateMsg = string.Format(getLicensePlateMsg, "refuel");
            }

            Console.WriteLine(getLicensePlateMsg);
            licensePlate = GetInput.GetLicensePlate(false, out _);
            energyType = s_Garage.GetEnergyType(licensePlate);

            if (i_IsElectric && energyType != eEnergyType.Electric)
            {
                Console.WriteLine($"vehicle no. {licensePlate} can not be charged (is not electric)");
            }

            else if (!i_IsElectric && energyType == eEnergyType.Electric)
            {
                Console.WriteLine($"vehicle no. {licensePlate} can not be refueled (is electric)");
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
                energyToFill = GetInput.GetValidFloat();
                fillEnergyUI(licensePlate, energyToFill, energyType);
                successMsg = string.Format(successMsg, energyType == eEnergyType.Electric ? "charging" : "refueling" ,licensePlate);
                Console.WriteLine(successMsg);
            }
        }

        private static void fillEnergyUI(string licensePlate,  float i_AmountToFill, eEnergyType i_EnergyType)
        {

            bool tryAgain = true;
            while (tryAgain)
            {
                try
                {
                    s_Garage.FllEnergy(licensePlate, i_AmountToFill, i_EnergyType);
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
            string licensePlate = "";
            string getVehicleDataMsg = @"
In order to get the vehicle's data, please enter its license number:";

            Console.WriteLine(getVehicleDataMsg);
            licensePlate = GetInput.GetLicensePlate(false, out _);
            Console.WriteLine(s_Garage.GetVehicleData(licensePlate));
        }
    }
}