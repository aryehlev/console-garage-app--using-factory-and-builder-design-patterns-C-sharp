using System;

namespace Ex03.GarageLogic
{
    internal class MotorCycle : Vehicle
    {
        private const float k_MaxAirPressure = 30;
        private const float k_NumOfWheels = 2;
        private eLicenseType m_TypeOfLicense;
        private byte m_Cc;
        
        public MotorCycle(
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
            float maxEnergyCapacity = i_EnergyType == eEnergyType.Electric ? 1.2f : 7;
            
            if (i_CurrentEnergyLevel > maxEnergyCapacity)
            {
                throw new ValueOutOfRangeException(0, maxEnergyCapacity);
            }
            
            m_Energy = new Energy(i_CurrentEnergyLevel, maxEnergyCapacity, i_EnergyType);
            
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
            return new[] { "license type", "volume of engine(cc)" };
        }

        internal override void ParseAndSetSpecificFeatures(string[] i_SpecificFeatures)
        {
            string firstFeature = i_SpecificFeatures[0];
            string secondFeature = i_SpecificFeatures[1];
            eLicenseType licenseType;
            if (Enum.TryParse(firstFeature, true, out licenseType))
            {
                m_TypeOfLicense = licenseType;
            }
            else
            {
                throw new FormatException("needs a license type of A, A1, AA or B");
            }

            byte cc;
            if (byte.TryParse(secondFeature, out cc))
            {
                m_Cc = cc;
            }
            else
            {
                throw new FormatException("needs a volume(cc)");
            }
        }
        
        public override string ToString()
        {
            return string.Format("{0}\n, type of license: {1},\n volume of engine: {2}\n", base.ToString(), m_TypeOfLicense, m_Cc);
        }
    }
}
