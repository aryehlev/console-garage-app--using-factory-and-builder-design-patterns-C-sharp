using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal class Car : Vehicle
    {
        private const float k_MaxAirPressure = 32;
        private const byte k_NumOfWheels = 4;
        private const float k_MaxElectric = 2.1f;
        private const float k_MaxGas = 60;
        private const bool k_CanBeElectric = true;
        private const int k_NumberOfUniquefeatures = 2;
        private eColour m_Colour;
        private byte m_NumOfDoors;

        public Car(
            string i_Model,
            string i_LicenseNumber,
            string i_NameOfOwner,
            string i_PhoneNumOfOwner,
            eStatus i_StatusOfvehicle = eStatus.InRepair)
            : base(i_Model, i_LicenseNumber, i_NameOfOwner, i_PhoneNumOfOwner)
        {
            m_CanBeElectric = k_CanBeElectric;
        }

        public override void SetUniqueParamaters(params object[] i_UniqueFeatures)
        {
            m_Colour = (eColour)i_UniqueFeatures[0];
            m_NumOfDoors = (byte)i_UniqueFeatures[1];
        }

        public override void SetWheels(string i_WheelManufactor, float i_CurrentAirPressure)
        {
            InitWheels(k_NumOfWheels, i_WheelManufactor, i_CurrentAirPressure, k_MaxAirPressure);
        }

        public override void SetEnergy(bool i_IsElectric, float i_CurrentEnergyLevel)
        {
            float maxEnergyCapacity = i_IsElectric ? k_MaxElectric : k_MaxGas;
            eEnergyType energyType = !i_IsElectric ? eEnergyType.Octan96 : eEnergyType.Electric;

            InitEnergy(i_CurrentEnergyLevel, maxEnergyCapacity, energyType);
        }

        public override Tuple<string, string[]>[] GetUniqueFeatureDescription()
        {
            Tuple<string, string[]>[] definitionAndValues = new Tuple<string, string[]>[k_NumberOfUniquefeatures];
            definitionAndValues[0] = new Tuple<string, string[]>("Colour", Enum.GetNames(typeof(eColour)));
            definitionAndValues[1] = new Tuple<string, string[]>("Number of doors", new[] { "2", "3", "4", "5" });
            return definitionAndValues;
        }

        public override object ParseUniqueFeature(string i_UniqueFeature, string i_FeatureKey)
        {
            object parsedUniqueFeature = null;
            switch(i_FeatureKey)
            {
                case "Colour":
                    if (Enum.TryParse(i_UniqueFeature, true, out eColour colour))
                    {
                        parsedUniqueFeature = colour;
                        break;
                    }
                    else
                    {
                        throw new FormatException("needs a colour of White, Black, Silver or Red");
                    }
                case "Number of doors":
                    if (byte.TryParse(i_UniqueFeature, out byte numOfDoors) && (numOfDoors >= 2 && numOfDoors <= 5))
                    {
                        parsedUniqueFeature = numOfDoors;
                        break;
                    }
                    else
                    {
                        throw new FormatException("needs a door 2,3,4 or 5");
                    }
                default:
                    throw new ArgumentException("The Feature Index is out of bounds");
            }

            return parsedUniqueFeature;
        }

        public override string ToString()
        {
            string strToReturn = @"
{0}
# Colour of car: {1}
# Number of doors in car: {2}";
            return string.Format(strToReturn, base.ToString(), m_Colour, m_NumOfDoors);
        }
    }
}
