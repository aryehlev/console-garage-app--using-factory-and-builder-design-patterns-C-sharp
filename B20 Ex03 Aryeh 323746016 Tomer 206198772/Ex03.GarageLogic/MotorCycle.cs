using System;

namespace Ex03.GarageLogic
{
    internal class MotorCycle : Vehicle
    {
        private const float k_MaxAirPressure = 30;
        private const byte k_NumOfWheels = 2;
        private const float k_MaxElectric = 1.2f;
        private const float k_MaxSolar = 7;
        private const int k_NumberOfUniqueFeatures = 2;
        private const bool k_CanBeElectric = true;
        private eLicenseType m_TypeOfLicense;
        private int m_Cc;

        public MotorCycle(
            string i_Model,
            string i_LicenseNumber,
            string i_NameOfOwner,
            string i_PhoneNumOfOwner)
            : base(i_Model, i_LicenseNumber, i_NameOfOwner, i_PhoneNumOfOwner)
        {
            m_CanBeElectric = k_CanBeElectric;
        }
        
        public override void SetUniqueFeatures(params object[] i_UniqueFeatures)
        {
            m_TypeOfLicense = (eLicenseType)i_UniqueFeatures[0];
            m_Cc = (int)i_UniqueFeatures[1];
        }

        public override void SetWheels(string i_WheelManufacturer, float i_CurrentAirPressure)
        {
            InitWheels(k_NumOfWheels, i_WheelManufacturer, i_CurrentAirPressure, k_MaxAirPressure);
        }

        public override void SetEnergy(bool i_IsElectric, float i_CurrentEnergyLevel)
        {
            float maxEnergyCapacity = i_IsElectric ? k_MaxElectric : k_MaxSolar;
            eEnergyType energyType = !i_IsElectric ? eEnergyType.Octan96 : eEnergyType.Electric;

            InitEnergy(i_CurrentEnergyLevel, maxEnergyCapacity, energyType);
        }

        public override Tuple<string, string[]>[] GetUniqueFeatureDescription()
        {
            Tuple<string, string[]>[] definitionAndValues = new Tuple<string, string[]>[k_NumberOfUniqueFeatures];
            definitionAndValues[0] = new Tuple<string, string[]>("License type", Enum.GetNames(typeof(eLicenseType)));
            definitionAndValues[1] = new Tuple<string, string[]>("Volume of engine(cc)", new[] { "a positive number" });
            return definitionAndValues;
        }

        public override object ParseUniqueFeature(string i_UniqueFeature, string i_FeatureKey)
        {
            object parsedUniqueFeature = null;
            switch(i_FeatureKey)
            {
                case "License type":
                    if(!int.TryParse(i_UniqueFeature, out _) && Enum.TryParse(
                           i_UniqueFeature,
                           true,
                           out eLicenseType licenseType))
                    {
                        parsedUniqueFeature = licenseType;
                        break;
                    }
                    else
                    {
                        throw new FormatException("needs a license type of A, A1, AA or B");
                    }

                case "Volume of engine(cc)":
                    if(int.TryParse(i_UniqueFeature, out int cc) && cc > 0)
                    {
                        parsedUniqueFeature = cc;
                        break;
                    }
                    else
                    {
                        throw new FormatException("needs a valid volume (cc) - a positive number");
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
# Type of license: {1}
# Volume of engine: {2}";
            return string.Format(strToReturn, base.ToString(), m_TypeOfLicense, m_Cc);
        }
    }
}
