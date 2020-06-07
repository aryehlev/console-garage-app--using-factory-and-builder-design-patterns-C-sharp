using System;
using System.Reflection;

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
        public override void SetParamaters(eEnergyType i_EnergyType, string i_WheelManufactor, float i_CurrentAirPressure, float i_CurrentEnergyLevel, object[] i_SpecificFeatures = null)
        { 
            if (i_CurrentEnergyLevel > k_MaxEnergyCapacity)
            {
                throw new ValueOutOfRangeException(0, k_MaxEnergyCapacity);
            }
           
            m_Energy = new Energy(i_CurrentEnergyLevel, k_MaxEnergyCapacity, i_EnergyType);
            
            if (i_CurrentAirPressure > k_MaxAirPressure)
            {
                throw new ValueOutOfRangeException(0, k_MaxAirPressure);
            }
            
            for (int i = 0; i < k_NumOfWheels; i++)
            {
                m_Wheels.Add(new Wheel(i_WheelManufactor, k_MaxAirPressure, i_CurrentAirPressure));
            }

            m_HasHazardasCargo = (bool)i_SpecificFeatures[0];
            m_VolumeOfCargo = (float)i_SpecificFeatures[1];
        }

        public override string[] GetSpecificFeatureDescription()
        {
            return new[] {"has hazardoes cargo?", "volume of cargo"};
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
