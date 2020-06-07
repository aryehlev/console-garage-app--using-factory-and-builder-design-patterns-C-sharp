using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.ConsoleUI
{
    class EnumMenu
    {
        private List<string> m_MenuOptions;
        private Type m_EnumType;

        public EnumMenu(Type i_EnumType, Enum i_ValueToIgnore = null)
        {
            this.m_MenuOptions = new List<string>();
            this.m_EnumType = i_EnumType;
            foreach (string enumValue in Enum.GetNames(i_EnumType))
            {
                if (i_ValueToIgnore == null || !enumValue.Equals(i_ValueToIgnore.ToString()))
                {
                    this.m_MenuOptions.Add(enumValue);
                }
            }
        }

        public Enum GetEnumFromNum(int i_OptionNumber)
        {
            if (i_OptionNumber <= 0 || i_OptionNumber > this.m_MenuOptions.Count)
            {
                throw new FormatException(i_OptionNumber.ToString());
            }

            StatusEnum MyStatus = (StatusEnum)Enum.Parse(typeof(StatusEnum), "Active", true);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            int modesCounter = 1;
            foreach (string menuOption in this.m_MenuOptions)
            {
                sb.Append($"{modesCounter} - {menuOption}");
                sb.Append(Environment.NewLine);
                modesCounter++;
            }

            return sb.ToString();
        }
    }
}
