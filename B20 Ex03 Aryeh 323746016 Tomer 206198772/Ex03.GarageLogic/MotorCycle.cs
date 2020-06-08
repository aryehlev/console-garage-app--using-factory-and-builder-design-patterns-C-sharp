using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal class MotorCycle : Vehicle
    {
        private const float k_MaxAirPressure = 30;
        private const float k_NumOfWheels = 2;
        private const float k_MaxElectric = 1.2f;
        private const float k_MaxSolar = 7;
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

        public override void SetParamaters(eEnergyType i_EnergyType, string i_WheelManufactor, float i_CurrentAirPressure, float i_CurrentEnergyLevel, float i_MaxAirPressure = k_MaxAirPressure, float i_NumOfWheels = k_NumOfWheels, float i_MaxEnergyCapacity = 0, object[] i_SpecificFeatures = null)
        {
            i_MaxEnergyCapacity = i_EnergyType == eEnergyType.Electric ? k_MaxElectric : k_MaxSolar;
            base.SetParamaters(i_EnergyType, i_WheelManufactor, i_CurrentAirPressure, i_CurrentEnergyLevel, i_MaxAirPressure, i_NumOfWheels, i_MaxEnergyCapacity, i_SpecificFeatures);        
            m_TypeOfLicense = (eLicenseType)i_SpecificFeatures[0];
            m_Cc = (byte)i_SpecificFeatures[1];
        }

        public override Dictionary<string, string[]> GetSpecificFeatureDescription()
        {
            Dictionary<string, string[]> definitionAndValues = new Dictionary<string, string[]>();
            definitionAndValues.Add("license type", Enum.GetNames(typeof(eLicenseType)));
            definitionAndValues.Add("volume of engine(cc)", new[] { "float" });
            return definitionAndValues;
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
