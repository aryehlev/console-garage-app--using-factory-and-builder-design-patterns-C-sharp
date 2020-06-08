using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal class Car : Vehicle
    {
        private const float k_MaxAirPressure = 32;
        private const byte k_NumOfWheels = 4;
        private const float k_MaxElectric = 2.1f;
        private const float k_MaxSolar = 60;
        private const int k_NumOfFeatures = 2;
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
            m_Energy = null;

        }
        
        public override void SetParamaters(eEnergyType i_EnergyType, string i_WheelManufactor, float i_CurrentAirPressure, float i_CurrentEnergyLevel, float i_MaxAirPressure = k_MaxAirPressure, float i_NumOfWheels = k_NumOfWheels, float i_MaxEnergyCapacity = 0, object[] i_SpecificFeatures = null)
        {
            i_MaxEnergyCapacity = i_EnergyType == eEnergyType.Electric ? k_MaxElectric : k_MaxSolar;
            base.SetParamaters(i_EnergyType, i_WheelManufactor, i_CurrentAirPressure, i_CurrentEnergyLevel, i_MaxAirPressure, i_NumOfWheels, i_MaxEnergyCapacity, i_SpecificFeatures);
            m_Colour = (eColour)i_SpecificFeatures[0];
            m_NumOfDoors = (byte)i_SpecificFeatures[1];
        }

        public override Dictionary<string, string[]> GetSpecificFeatureDescription()
        {
            Dictionary<string, string[]> definitionAndValues = new Dictionary<string, string[]>();
            definitionAndValues.Add("Colour", Enum.GetNames(typeof(eColour)));
            definitionAndValues.Add("number of doors", new[] { "byte" });
            return definitionAndValues;
        }

        public override object[] ParseSpecificFeatures(string[] i_SpecificFeatures)
        {
            string firstFeature = i_SpecificFeatures[0];
            string secondFeature = i_SpecificFeatures[1];
            object[] specificFeatures = new object[k_NumOfFeatures];
            eColour colour;
            if (Enum.TryParse(firstFeature, true, out colour))
            {
                specificFeatures[0] = colour;
            }
            else
            {
                throw new FormatException("needs a colour of White, Black, Silver or Red");
            }

            byte numOfDoors;
            if (byte.TryParse(secondFeature, out numOfDoors) && (numOfDoors == 2 || numOfDoors == 3 || numOfDoors == 4 || numOfDoors == 5))
            {

                specificFeatures[1] = numOfDoors;
            }
            else
            {
                throw new FormatException("needs a door 2,3,4 or 5");
            }

            return specificFeatures;
        }

        public override string AdvancesToStringAfterFeaturesWhereSet()
        {
            return string.Format("{0}\n, colour of car: {1},\n number of doors in car: {2}\n", base.AdvancesToStringAfterFeaturesWhereSet(), m_Colour, m_NumOfDoors);
        }
    }
}
