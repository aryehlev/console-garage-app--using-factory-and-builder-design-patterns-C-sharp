using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal class Truck : Vehicle
    {
        private const float k_MaxEnergyCapacity = 120;
        private const float k_MaxAirPressure = 28;
        private const byte k_NumOfWheels = 16;
        private const int k_NumOfFeatures = 2;
        private bool m_HasHazardasCargo;
        private float m_VolumeOfCargo;

        public Truck(
            string i_Model,
            string i_LicenseNumber,
            string i_NameOfOwner,
            string i_PhoneNumOfOwner,
            eStatus i_StatusOfvehicle = eStatus.InRepair)
            : base(i_Model, i_LicenseNumber, i_NameOfOwner, i_PhoneNumOfOwner)
        {
        }
        public override void SetParamaters(eEnergyType i_EnergyType, string i_WheelManufactor, float i_CurrentAirPressure, float i_CurrentEnergyLevel, float i_MaxAirPressure = k_MaxAirPressure, float i_NumOfWheels = k_NumOfWheels, float i_MaxEnergyCapacity = k_MaxEnergyCapacity, object[] i_SpecificFeatures = null)
        {
            base.SetParamaters(i_EnergyType, i_WheelManufactor, i_CurrentAirPressure, i_CurrentEnergyLevel, i_MaxAirPressure, i_NumOfWheels, i_MaxEnergyCapacity, i_SpecificFeatures);            
            m_HasHazardasCargo = (bool)i_SpecificFeatures[0];
            m_VolumeOfCargo = (float)i_SpecificFeatures[1];
        }

        public override Dictionary<string, string[]> GetSpecificFeatureDescription()
        {
            Dictionary<string, string[]> definitionAndValues = new Dictionary<string, string[]>();
            definitionAndValues.Add("has hazardoes cargo?", new[] { "true" , "false"});
            definitionAndValues.Add("volume of cargo", new[] { "byte" });
            return definitionAndValues;
        }

        public override object[] ParseSpecificFeatures(string[] i_SpecificFeatures)
        {
            string firstFeature = i_SpecificFeatures[0];
            string secondFeature = i_SpecificFeatures[1];
            object[] specificFeatures = new object[k_NumOfFeatures];
            bool hasHazardousCargo;
            
            if (bool.TryParse(firstFeature, out hasHazardousCargo))
            {
                specificFeatures[0] = hasHazardousCargo;
            }
            else
            {
                throw new FormatException("needs a colour of White, Black, Silver or Red");
            }

            float volumeOfCargo;
            if (float.TryParse(secondFeature, out volumeOfCargo))
            {
                specificFeatures[1] = volumeOfCargo;
            }
            else
            {
                throw new FormatException("needs a normal volume in number");
            }

            return specificFeatures;
        }

        public override string ToString()
        {
            return string.Format("{0}\n, has hazardoes cargo: {1},\n volume of cargo: {2}\n", base.ToString(), m_HasHazardasCargo, m_VolumeOfCargo);
        }
    }
}
