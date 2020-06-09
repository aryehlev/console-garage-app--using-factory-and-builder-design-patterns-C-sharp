using System;
using System.Text.RegularExpressions;

namespace Ex03.ConsoleUI
{
    class CheckInput
    {
        // CHECKERS
        internal static int CheckModePicker(string i_Input)
        {
            if (i_Input == "" || i_Input.Length > 1 || !char.IsDigit(i_Input[0]) || int.Parse(i_Input) > 7)
            {
                throw new FormatException(i_Input);
            }

            return int.Parse(i_Input);
        }

        internal static string CheckIfValidString(string i_Input, bool i_DigitsOnly, bool i_LettersOnly)
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

        internal static float CheckIfValidFloat(string i_Input, float i_MinValue = 0, float i_MaxValue = float.MaxValue)
        {
            if (!float.TryParse(i_Input, out float parsed) || parsed < i_MinValue || parsed > i_MaxValue)
            {
                throw new FormatException(i_Input);
            }

            return parsed;
        }
    }
}
