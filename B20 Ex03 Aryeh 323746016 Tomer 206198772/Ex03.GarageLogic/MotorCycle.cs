﻿using System;
using System.Collections.Generic;

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
        private byte m_Cc;

        public MotorCycle(
            string i_Model,
            string i_LicenseNumber,
            string i_NameOfOwner,
            string i_PhoneNumOfOwner)
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
            float maxEnergyCapacity = i_IsElectric ? k_MaxElectric : k_MaxSolar;
            eEnergyType energyType = !i_IsElectric ? eEnergyType.Octan95 : eEnergyType.Electric;
            InitWheels(k_NumOfWheels, i_WheelManufactor, i_CurrentAirPressure, k_MaxAirPressure);
            InitEnergy(i_CurrentEnergyLevel, maxEnergyCapacity, energyType);

            m_TypeOfLicense = (eLicenseType)i_SpecificFeatures[0];
            m_Cc = (byte)i_SpecificFeatures[1];
        }

        public override Tuple<string, string[]>[] GetSpecificFeatureDescription()
        {
            Tuple<string, string[]>[] definitionAndValues = new Tuple<string, string[]>[k_NumberOfUniqueFeatures];
            definitionAndValues[0] = new Tuple<string, string[]>("License type", Enum.GetNames(typeof(eLicenseType)));
            definitionAndValues[1] = new Tuple<string, string[]>("Volume of engine(cc)", new[] { "float" });
            return definitionAndValues;
        }

        //public override object[] ParseSpecificFeatures(string[] i_SpecificFeatures)
        //{
        //    string firstFeature = i_SpecificFeatures[0];
        //    string secondFeature = i_SpecificFeatures[1];
        //    object[] specificFeatures = new object[k_NumOfFeatures];
        //    eLicenseType licenseType;
        //    if (Enum.TryParse(firstFeature, true, out licenseType))
        //    {
        //        specificFeatures[0] = licenseType;
        //    }
        //    else
        //    {
        //        throw new FormatException("needs a license type of A, A1, AA or B");
        //    }

        //    byte cc;
        //    if (byte.TryParse(secondFeature, out cc))
        //    {
        //        specificFeatures[1] = cc;
        //    }
        //    else
        //    {
        //        throw new FormatException("needs a volume(cc)");
        //    }

        //    return specificFeatures;
        //}

        public override object ParseSpecificFeature(string i_SpecificFeature, string i_FeatureKey)
        {
            object parsedSpecificFeature = null;
            switch(i_FeatureKey)
            {
                case "License type":
                    if(!int.TryParse(i_SpecificFeature, out _) && Enum.TryParse(
                           i_SpecificFeature,
                           true,
                           out eLicenseType licenseType))
                    {
                        parsedSpecificFeature = licenseType;
                        break;
                    }
                    else
                    {
                        throw new FormatException("needs a license type of A, A1, AA or B");
                    }
                case "Volume of engine(cc)":
                    if(byte.TryParse(i_SpecificFeature, out byte cc))
                    {
                        parsedSpecificFeature = cc;
                        break;
                    }
                    else
                    {
                        throw new FormatException("needs a volume(cc)");
                    }
                default:
                    throw new ArgumentException("The Feature Index is out of bounds");
            }

            return parsedSpecificFeature;
        }


        public override string AdvancesToStringAfterFeaturesWhereSet()
        {
            return string.Format("{0}\n, type of license: {1},\n volume of engine: {2}\n", base.AdvancesToStringAfterFeaturesWhereSet(), m_TypeOfLicense, m_Cc);
        }
    }
}
