using System;

namespace Ex03.GarageLogic
{
    internal class MotorCycle : Vehicle
    {
        private const float k_MaxAirPressure = 30;
        private const float k_NumOfWheels = 2;
        private const int k_NumOfFeatures = 2;
        private eLicenseType m_TypeOfLicense;
        private byte m_Cc;

        public MotorCycle(
            string i_Model,
            string i_LicenseNumber,
            string i_NameOfOwner,
            string i_PhoneNumOfOwner)
            : base(i_Model, i_LicenseNumber, i_NameOfOwner, i_PhoneNumOfOwner)
        {
        }

        public override void SetParamaters(eEnergyType i_EnergyType, string i_WheelManufactor, float i_CurrentAirPressure, float i_CurrentEnergyLevel, object[] i_SpecificFeatures = null)
        {
            float maxEnergyCapacity = i_EnergyType == eEnergyType.Electric ? 1.2f : 7;
            
            if (i_CurrentEnergyLevel > maxEnergyCapacity)
            {
                throw new ValueOutOfRangeException(0, maxEnergyCapacity);
            }
            
            m_Energy = new Energy(i_CurrentEnergyLevel, maxEnergyCapacity, i_EnergyType);
            
            if (i_CurrentAirPressure > k_MaxAirPressure)
            {
                throw new ValueOutOfRangeException(0, k_MaxAirPressure);
            }
           
            for (int i = 0; i < k_NumOfWheels; i++)
            {
                m_Wheels.Add(new Wheel(i_WheelManufactor, k_MaxAirPressure, i_CurrentAirPressure));
            }

            m_TypeOfLicense = (eLicenseType)i_SpecificFeatures[0];
            m_Cc = (byte)i_SpecificFeatures[1];
        }

        public override string[] GetSpecificFeatureDescription()
        {
            return new[] { "license type", "volume of engine(cc)" };
        }

        public override object[] ParseSpecificFeatures(string[] i_SpecificFeatures)
        {
            string firstFeature = i_SpecificFeatures[0];
            string secondFeature = i_SpecificFeatures[1];
            object[] specificFeatures = new object[k_NumOfFeatures];
            eLicenseType licenseType;
            if (Enum.TryParse(firstFeature, true, out licenseType))
            {
                specificFeatures[0] = licenseType;
            }
            else
            {
                throw new FormatException("needs a license type of A, A1, AA or B");
            }

            byte cc;
            if (byte.TryParse(secondFeature, out cc))
            {
                specificFeatures[1] = cc;
            }
            else
            {
                throw new FormatException("needs a volume(cc)");
            }

            return specificFeatures;
        }
        
        public override string ToString()
        {
            return string.Format("{0}\n, type of license: {1},\n volume of engine: {2}\n", base.ToString(), m_TypeOfLicense, m_Cc);
        }
    }
}
