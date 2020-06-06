
using System;

namespace Ex03.ConsoleUI
{
    class Program
    {
        public static void Main()
        {
            UserInterface.WelcomeMsg();

            while (true)
            {
                switch (UserInterface.ModePicker())
                {
                    case 1:
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