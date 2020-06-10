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
            while (input == null || (input.ToLower() != "yes" && input.ToLower() != "no"))
            {
                Console.WriteLine($"Please enter Yes or No");
                input = Console.ReadLine();
            }

            isElectric = input.ToLower() == "yes";
            return isElectric;
        }

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

        internal static object[] GetUniqueFeatures(string i_UniqueFeatureMsg, Vehicle i_Vehicle)
        {
            Object[] UniqueFeatures = null;
            Tuple<string, string[]>[] uniqueFeatureDescriptions = i_Vehicle.GetUniqueFeatureDescription();
            if (uniqueFeatureDescriptions != null)
            {
                UniqueFeatures = new object[uniqueFeatureDescriptions.Length];
                int objectIndex = 0;
                foreach (Tuple<string, string[]> uniqueFeatureDescription in uniqueFeatureDescriptions)
                {
                    string descriptionOfValues = getPossibleFeaturesToString(uniqueFeatureDescription.Item2);
                    string currentUniqueFeatureMsg = string.Format(
                        i_UniqueFeatureMsg,
                        uniqueFeatureDescription.Item1,
                        descriptionOfValues);
                    Console.WriteLine(currentUniqueFeatureMsg);
                    UniqueFeatures[objectIndex] = getUniqueFeature(uniqueFeatureDescription.Item1, i_Vehicle);
                    objectIndex++;
                }
            }

            return UniqueFeatures;
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
        private static object getUniqueFeature(string i_FeatureKey, Vehicle i_Vehicle)
        {
            object uniqueFeature = null;
            bool tryAgain = true;
            while (tryAgain)
            {
                try
                {
                    string input = Console.ReadLine();
                    uniqueFeature = i_Vehicle.ParseUniqueFeature(input, i_FeatureKey);
                    tryAgain = false;
                }
                catch (FormatException e)
                {
                    Console.WriteLine($"{e.Message}. Try again");
                }
            }

            return uniqueFeature;
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
                    if (i_MaxValue == float.MaxValue)
                    {
                        Console.WriteLine($"Your input was '{e.Message}' but the amount must be bigger than {i_MinValue}. Try again");
                    }
                    else
                    {
                        Console.WriteLine($"Your input was '{e.Message}' but the amount must be between {i_MinValue} to {i_MaxValue}. Try again");
                    }
                }
            }

            return validFloat;
        }
    }
}
