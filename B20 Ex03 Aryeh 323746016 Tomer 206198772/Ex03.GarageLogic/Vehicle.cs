﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private readonly string r_Model;
        private readonly string r_LicenseNumber;
        private readonly string r_NameOfOwner;
        private readonly string r_PhoneNumOfOwner;
        private eStatus m_StatusOfVehicle;
        protected List<Wheel> m_Wheels;
        protected Energy m_Energy;

        internal Vehicle(
            string i_Model,
            string i_LicenseNumber,
            string i_NameOfOwner,
            string i_PhoneNumOfOwner
            )
        {
            r_LicenseNumber = i_LicenseNumber;
            r_Model = i_Model;
            r_NameOfOwner = i_NameOfOwner;
            r_PhoneNumOfOwner = i_PhoneNumOfOwner;
            m_StatusOfVehicle = eStatus.InRepair;
            m_Wheels = new List<Wheel>();
        }
        
        public abstract string[] GetSpecificFeatureDescription();
        
        public abstract object[] ParseSpecificFeatures(string[] i_SpecificFeatures);
        
        public abstract void SetParamaters(
            eEnergyType i_EnergyType,
            string i_WheelManufactor,
            float i_CurrentAirPressure,
            float i_CurrentEnergyLevel,
            object[] i_SpecificFeatures = null);
        
        internal void FillTires(bool i_FillAll, float i_AirToFill = 0)
        {
            foreach (Wheel wheel in m_Wheels)
            { 
                wheel.FillTire(i_FillAll, i_AirToFill);
            }
        } 
        
        internal void FillEnergy(float i_Energy, eEnergyType i_EnergyType)
        {
            m_Energy.FillEnergy(i_Energy, i_EnergyType);  
        }

        internal float GetEnergyPercentage()
        {
            return m_Energy.GetEnergyPercentage();
        }

        internal eStatus StatusOfVehicle  
        {
            get
            {
                return m_StatusOfVehicle;
            }   
            set
            {
                m_StatusOfVehicle = value;
            }  
        }

        public override string ToString()
        {
            StringBuilder sbForWheels = new StringBuilder();
            int i = 0;
            foreach (Wheel wheel in m_Wheels)
            {
                sbForWheels.Append(string.Format("wheel number {0}: {1}", i, wheel));
                i++;
            }

            return string.Format(
                "Licence Number: {0}\n, Model {1}\n, name of owner: {2}\n, status of vehicle {3}\n, type Of energy car takes: {4}\n, percentage left in car {5}:\n wheel info \n {6}, owner phone number {7}",
                r_LicenseNumber,
                r_Model,
                r_NameOfOwner,
                m_StatusOfVehicle,
                m_Energy.EnergyType,
                m_Energy.GetEnergyPercentage(), 
                sbForWheels,
                r_PhoneNumOfOwner);
        }

        public override int GetHashCode()
        {
            return int.Parse(r_LicenseNumber);
        }
    }
}