using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal class Truck : Vehicle
    {
        private const float k_MaxEnergyCapacity = 120;
        private const float k_MaxAirPressure = 28;
        private const byte k_NumOfWheels = 16;
        private const int k_NumberOfUniquefeatures = 2;
        private const bool k_CanBeElectric = false;
        private bool m_HasHazardousCargo;
        private byte m_VolumeOfCargo;

        public Truck(
            string i_Model,
            string i_LicenseNumber,
            string i_NameOfOwner,
            string i_PhoneNumOfOwner,
            eStatus i_StatusOfvehicle = eStatus.InRepair)
            : base(i_Model, i_LicenseNumber, i_NameOfOwner, i_PhoneNumOfOwner)
        {
            m_CanBeElectric = k_CanBeElectric;
        }

        public override void SetUniqueFeatures(params object[] i_UniqueFeatures)
        {
            m_HasHazardousCargo = (bool)i_UniqueFeatures[0];
            m_VolumeOfCargo = (byte)i_UniqueFeatures[1];
        }
       
        public override void SetWheels(string i_WheelManufactor, float i_CurrentAirPressure)
        {
            InitWheels(k_NumOfWheels, i_WheelManufactor, i_CurrentAirPressure, k_MaxAirPressure);
        }

        public override void SetEnergy(bool i_IsElectric, float i_CurrentEnergyLevel)
        {

            if (i_IsElectric)
            {
                throw new ArgumentException("a truck cannot be electric(yet?)");
            }
            
            eEnergyType energyType = !i_IsElectric ? eEnergyType.Soler : eEnergyType.Electric;

            InitEnergy(i_CurrentEnergyLevel, k_MaxEnergyCapacity, energyType);
        }

        public override Tuple<string, string[]>[] GetUniqueFeatureDescription()
        {
            Tuple<string, string[]>[] definitionAndValues = new Tuple<string, string[]>[k_NumberOfUniquefeatures];
            definitionAndValues[0] = new Tuple<string, string[]>("Has hazardous cargo", new[] { "true", "false" });
            definitionAndValues[1] = new Tuple<string, string[]>("Volume of cargo", new[] { "a non-negative integer" });
            return definitionAndValues;
        }

        public override object ParseUniqueFeature(string i_UniqueFeature, string i_FeatureKey)
        {
            object parsedUniqueFeature = null;
            switch(i_FeatureKey)
            {
                case "Has hazardous cargo":
                    if(bool.TryParse(i_UniqueFeature, out bool hasHazardoesCargo))
                    {
                        parsedUniqueFeature = hasHazardoesCargo;
                        break;
                    }
                    else
                    {
                        throw new FormatException("needs a true or false value");
                    }
                case "Volume of cargo":
                    if (byte.TryParse(i_UniqueFeature, out byte volumeOfCargo) && volumeOfCargo >= 0)
                    {
                        parsedUniqueFeature = volumeOfCargo;
                        break;
                    }
                    else
                    {
                        throw new FormatException("needs a non-negative amount of cargo");
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
# Has hazardoes cargo: {1}
# Volume of cargo: {2}";
            return string.Format(strToReturn, base.ToString(), m_HasHazardousCargo, m_VolumeOfCargo);
        }
    }
}
