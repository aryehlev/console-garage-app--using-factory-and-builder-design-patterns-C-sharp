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
        private const int k_NumOfFeatures = 2;
        private const bool k_CanBeElecric = true;
        private eColour m_Colour;
        private int m_NumOfDoors;

        public Car(
            string i_Model,
            string i_LicenseNumber,
            string i_NameOfOwner,
            string i_PhoneNumOfOwner,
            eStatus i_StatusOfvehicle = eStatus.InRepair)
            : base(i_Model, i_LicenseNumber, i_NameOfOwner, i_PhoneNumOfOwner)
        {
            
        }
        
        public override void SetParamaters(
            bool i_IsElectric,
            string i_WheelManufactor,
            float i_CurrentAirPressure,
            float i_CurrentEnergyLevel,
            params object[] i_SpecificFeatures)
        {
            float maxEnergyCapacity = i_IsElectric ? k_MaxElectric : k_MaxGas;
            eEnergyType energyType = !i_IsElectric ? eEnergyType.Octan96 : eEnergyType.Electric;
            InitWheels(k_NumOfWheels, i_WheelManufactor, i_CurrentAirPressure, k_MaxAirPressure);
            InitEnergy(i_CurrentEnergyLevel, maxEnergyCapacity, energyType);
            
            m_Colour = (eColour)i_SpecificFeatures[0];
            m_NumOfDoors = (int)i_SpecificFeatures[1];
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
