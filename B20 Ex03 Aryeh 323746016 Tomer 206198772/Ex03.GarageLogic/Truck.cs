using System;
using System.Reflection;

namespace Ex03.GarageLogic
{
    internal class Truck : Vehicle
    {
        private const float k_MaxEnergyCapacity = 120;
        private const float k_MaxAirPressure = 28;
        private const byte k_NumOfWheels = 16;
        private bool m_HasHazardasCargo;
        private float m_VolumeOfCargo;
        
        public Truck(
            string i_Model, 
            string i_LicenseNumber, 
            eEnergyType i_EnergyType, 
            string i_NameOfOwner, 
            string i_PhoneNumOfOwner,
            string i_WheelManufactor, 
            float i_CurrentAirPresure, 
            float i_CurrentEnergyLevel, 
            eStatus i_StatusOfvehicle = eStatus.InRepair)
            : base(i_Model, i_LicenseNumber, i_EnergyType, i_NameOfOwner, i_PhoneNumOfOwner, i_WheelManufactor, i_CurrentAirPresure, i_CurrentEnergyLevel, i_StatusOfvehicle)
        {
            if (i_CurrentEnergyLevel > k_MaxEnergyCapacity)
            {
                throw new ValueOutOfRangeException(0, k_MaxEnergyCapacity);
            }
           
            m_Energy = new Energy(i_CurrentEnergyLevel, k_MaxEnergyCapacity, i_EnergyType);
            
            if (i_CurrentAirPresure > k_MaxAirPressure)
            {
                throw new ValueOutOfRangeException(0, k_MaxAirPressure);
            }
            
            for (int i = 0; i < k_NumOfWheels; i++)
            {
                m_Wheels.Add(new Wheel(i_WheelManufactor, k_MaxAirPressure, i_CurrentAirPresure));
            }
        }

        internal override string[] GetSpecificFeatureDescription()
        {
            return new[] {"has hazardoes cargo?", "volume of cargo"};
        }

        internal override void ParseAndSetSpecificFeatures(string[] i_SpecificFeatures)
        {
            string firstFeature = i_SpecificFeatures[0];
            string secondFeature = i_SpecificFeatures[1];
            bool hasHazardousCargo;
            
            if (bool.TryParse(firstFeature, out hasHazardousCargo))
            {
                m_HasHazardasCargo = hasHazardousCargo;
            }
            else
            {
                throw new FormatException("needs a colour of White, Black, Silver or Red");
            }

            float volumeOfCargo;
            if (float.TryParse(secondFeature, out volumeOfCargo))
            {
                m_VolumeOfCargo = volumeOfCargo;
            }
            else
            {
                throw new FormatException("needs a normal volume in number");
            }
        }

        public override string ToString()
        {
            return string.Format("{0}\n, has hazardoes cargo: {1},\n volume of cargo: {2}\n", base.ToString(), m_HasHazardasCargo, m_VolumeOfCargo);
        }
    }
}
