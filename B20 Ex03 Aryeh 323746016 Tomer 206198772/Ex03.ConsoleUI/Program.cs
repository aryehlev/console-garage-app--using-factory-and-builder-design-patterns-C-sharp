using System;
using Ex02.ConsoleUtils;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class Program
    {
        public static void Main()
        {
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