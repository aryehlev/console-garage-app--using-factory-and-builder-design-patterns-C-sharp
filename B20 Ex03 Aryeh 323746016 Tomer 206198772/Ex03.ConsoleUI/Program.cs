using System;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    class Program
    {
        public static void Main()
        {
            Vehicle newCar = UserInterface.s_Garage.AddVehicle(eVehicleType.Car, "FORD", "123", "TOMER", "050");
            newCar.SetParamaters(eEnergyType.Octan95, "MANUFACTOR", 20, 10, eColour.Red, 4);
            while (true)
            {
                UserInterface.WelcomeMsg();
                switch (UserInterface.ModePicker())
                {
                    case 1:
                        UserInterface.AddVehicle();
                        break;
                    case 2:
                        UserInterface.GetAllLicenseNumbers();
                        break;
                    case 3:
                        UserInterface.ChangeStatusOfVehicle();
                        break;
                    case 4:
                        UserInterface.FillTiresToMax();
                        break;
                    case 5:
                        UserInterface.FillEnergy(false);
                        break;
                    case 6:
                        UserInterface.FillEnergy(true);
                        break;
                    case 7:
                        UserInterface.GetVehicleData();
                        break;
                    case 0:
                        UserInterface.GoodbyeMsg();
                        Environment.Exit(0);
                        break;
                }
                UserInterface.BackToModePickerMsg();
            }
        }
    }
}