using System;
using Ex02.ConsoleUtils;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    class Program
    {
        public static void Main()
        {
            //Vehicle newCar = UserInterface.s_Garage.AddVehicle(eVehicleType.Car, "FORD", "123", "TOMER", "050");
            //newCar.SetEnergy(false, 10);
            //newCar.SetWheels("MANUFACTOR", 20);
            //newCar.SetUniqueFeatures(eColour.Red, (byte)4);
            while (true)
            {
                try
                {
                    UserInterface.WelcomeMsg();
                    switch (UserInterface.ModePicker())
                    {
                        case 1:
                            UserInterface.AddVehicle();
                            break;
                        case 2:
                            UserInterface.AllLicensePlateMode();
                            break;
                        case 3:
                            UserInterface.ChangeStatusOfVehicleMode();
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
                            UserInterface.VehicleDataMode();
                            break;
                        case 0:
                            UserInterface.GoodbyeMsg();
                            Environment.Exit(0);
                            break;
                    }
                    UserInterface.BackToModePickerMsg();
                } 
                catch(ModeInterruptException)
                {
                    Screen.Clear();
                }
            }
        }
    }
}