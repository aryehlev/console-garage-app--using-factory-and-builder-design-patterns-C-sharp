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

        public override bool CanBeElectric()
        {
            return k_CanBeElectric;
        }

        public override void SetParamaters(
            bool i_IsElectric,
            string i_WheelManufactor,
            float i_CurrentAirPressure,
            float i_CurrentEnergyLevel,
            params object[] i_SpecificFeatures)
        {
            if(i_IsElectric)
            {
                throw new ArgumentException("a truck cannot be electric(yet?)");
            }
            InitWheels(k_NumOfWheels, i_WheelManufactor, i_CurrentAirPressure, k_MaxAirPressure);
            InitEnergy(i_CurrentEnergyLevel, k_MaxEnergyCapacity, eEnergyType.Soler);

            m_HasHazardasCargo = (bool)i_SpecificFeatures[0];
            m_VolumeOfCargo = (float)i_SpecificFeatures[1];
        }

        public override Tuple<string, string[]>[] GetSpecificFeatureDescription()
        {
            Tuple<string, string[]>[] definitionAndValues = new Tuple<string, string[]>[k_NumberOfUniquefeatures];
            definitionAndValues[0] = new Tuple<string, string[]>("Has hazardas cargo", new[] { "true", "false" });
            definitionAndValues[1] = new Tuple<string, string[]>("Volume of cargo", new[] { "byte" });
            return definitionAndValues;
        }

        //public override object[] ParseSpecificFeatures(string[] i_SpecificFeatures)
        //{
        //    string firstFeature = i_SpecificFeatures[0];
        //    string secondFeature = i_SpecificFeatures[1];
        //    object[] specificFeatures = new object[k_NumOfFeatures];
        //    bool hasHazardousCargo;

        //    if (bool.TryParse(firstFeature, out hasHazardousCargo))
        //    {
        //        specificFeatures[0] = hasHazardousCargo;
        //    }
        //    else
        //    {
        //        throw new FormatException("needs a colour of White, Black, Silver or Red");
        //    }

        //    float volumeOfCargo;
        //    if (float.TryParse(secondFeature, out volumeOfCargo))
        //    {
        //        specificFeatures[1] = volumeOfCargo;
        //    }
        //    else
        //    {
        //        throw new FormatException("needs a normal volume in number");
        //    }

        //    return specificFeatures;
        //}

        public override object ParseSpecificFeature(string i_SpecificFeature, string i_FeatureKey)
        {
            object parsedSpecificFeature = null;
            switch(i_FeatureKey)
            {
                case "Has hazardas cargo":
                    if(bool.TryParse(i_SpecificFeature, out bool hasHazardoesCargo))
                    {
                        parsedSpecificFeature = hasHazardoesCargo;
                        break;
                    }
                    else
                    {
                        throw new FormatException("needs a true or false value");
                    }
                case "Volume of cargo":
                    if (float.TryParse(i_SpecificFeature, out float volumeOfCargo) || volumeOfCargo >= 0)
                    {
                        parsedSpecificFeature = volumeOfCargo;
                        break;
                    }
                    else
                    {
                        throw new FormatException("needs a non-negative amount of cargo");
                    }
                default:
                    throw new ArgumentException("The Feature Index is out of bounds");
            }

            return parsedSpecificFeature;
        }

        public override string AdvancesToStringAfterFeaturesWhereSet()
        {
            return string.Format("{0}\n, has hazardoes cargo: {1},\n volume of cargo: {2}\n", base.AdvancesToStringAfterFeaturesWhereSet(), m_HasHazardasCargo, m_VolumeOfCargo);
        }
    }
}
