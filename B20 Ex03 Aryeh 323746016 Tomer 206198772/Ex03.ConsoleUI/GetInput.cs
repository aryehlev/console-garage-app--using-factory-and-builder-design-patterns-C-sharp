using System;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    class GetInput
    {
        internal static string GetLicenseNumber(bool i_AllowNonRegistered, out bool o_IslicenseNumberRegistered)
        {
            o_IslicenseNumberRegistered = false;
            string licenseNumber = "";
            bool tryAgain = true;
            while (tryAgain)
            {
                try
                {
                    string input = Console.ReadLine();
                    licenseNumber = CheckInput.CheckIfValidString(input, false, false);
                    if (UserInterface.s_Garage.IsVehicleRegistered(licenseNumber))
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

        internal static eStatus GetVehicleStatus(bool i_IgnoreNone)
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

        internal static eVehicleType GetVehicleType()
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

        internal static bool GetIsElectricOrNot()
        {
            string input = Console.ReadLine();
            bool isElectric;
            while (input == null || input.ToLower() != "yes" || input.ToLower() != "no")
            {
                Console.WriteLine($"Please enter Yes or No");
                input = Console.ReadLine();
            }

            isElectric = input.ToLower() == "yes";

            return isElectric;
        }

        //internal static void GetEnergyAmount(string i_licenseNumber, eEnergyType i_energyType)
        //{
        //    float energyAmount = 0.0f;
        //    bool tryAgain = true;
        //    while (tryAgain)
        //    {
        //        try
        //        {
        //            string input = Console.ReadLine();
        //            energyAmount = CheckInput.CheckIfValidFloat(input);
        //            UserInterface.s_Garage.FllEnergy(i_licenseNumber, energyAmount, i_energyType);
        //            tryAgain = false;
        //        }
        //        catch (ValueOutOfRangeException e)
        //        {
        //            Console.WriteLine($"The amount should be between {e.MinValue} - {e.MaxValue} (and you entered {energyAmount}). Try again");
        //        }
        //    }
        //}

        internal static string GetValidString(bool i_DigitsOnly, bool i_LettersOnly)
        {
            string validString = "";
            bool tryAgain = true;
            while (tryAgain)
            {
                try
                {
                    string input = Console.ReadLine();
                    validString = CheckInput.CheckIfValidString(input, i_DigitsOnly, i_LettersOnly);
                    tryAgain = false;
                }
                catch (FormatException e)
                {
                    Console.WriteLine($"Your input is {e.Message}. Try again");
                }
            }

            return validString;
        }

        internal static object[] GetSpecialFeatures(string i_SpecialFeatureMsg, Vehicle i_Vehicle)
        {
            Object[] SpecificFeatures = null;
            Tuple<string, string[]>[] specificFeatureDescriptions = i_Vehicle.GetSpecificFeatureDescription();
            if (specificFeatureDescriptions != null)
            {
                SpecificFeatures = new object[specificFeatureDescriptions.Length];
                int objectIndex = 0;
                foreach (Tuple<string, string[]> specificFeatureDescription in specificFeatureDescriptions)
                {
                    string descriptionOfValues = getPossibleFeaturesToString(specificFeatureDescription.Item2);
                    Console.Out.WriteLine(specificFeatureDescription.Item1);
                    string currentSpecialFeatureMsg = string.Format(
                        i_SpecialFeatureMsg,
                        specificFeatureDescription.Item1,
                        descriptionOfValues);
                    Console.WriteLine(currentSpecialFeatureMsg);
                    SpecificFeatures[objectIndex] = getSpecialFeature(specificFeatureDescription.Item1, i_Vehicle);
                    objectIndex++;
                }
            }

            return SpecificFeatures;
        }

        private static string getPossibleFeaturesToString(string[] i_PossibleFeatures)
        {
            StringBuilder sb = new StringBuilder(); 
            foreach (string possibleFeature in i_PossibleFeatures)
            {
                sb.Append(possibleFeature);
                sb.Append(Environment.NewLine);
            }

            return sb.ToString();
        }
        private static object getSpecialFeature(string i_FeatureKey, Vehicle i_Vehicle)
        {
            object specialFeature = null;
            bool tryAgain = true;
            while (tryAgain)
            {
                try
                {
                    string input = Console.ReadLine();
                    specialFeature = i_Vehicle.ParseSpecificFeature(input, i_FeatureKey);
                    tryAgain = false;
                }
                catch (FormatException e)
                {
                    Console.WriteLine($"{e.Message}. Try again");
                }
            }

            return specialFeature;
        }

        internal static float GetValidFloat(float i_MinValue = 0, float i_MaxValue = float.MaxValue)
        {
            float validFloat = 0.0f;
            bool tryAgain = true;
            while (tryAgain)
            {
                try
                {
                    string input = Console.ReadLine();
                    validFloat = CheckInput.CheckIfValidFloat(input, i_MinValue, i_MaxValue);
                    tryAgain = false;
                }
                catch (FormatException e)
                {
                    Console.WriteLine($"Your input was '{e.Message}' but the amount must be between {i_MinValue} to {i_MaxValue}. Try again");
                }
            }

            return validFloat;
        }
    }
}
