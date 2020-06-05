using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        string m_Model;
        string m_LicenseNumber;
        List<Wheel> m_Wheels;
        Energy m_Energy;
        private eEnergyType m_EnergyType;
        string m_NameOfOwner;
        string m_PhoneNumOfOwner;
        private eStatus m_StatusOfVehicle;

        internal Vehicle(
            string i_Model,
            string i_LicenseNumber,
            eEnergyType i_EnergyType,
            string i_NameOfOwner,
            string i_PhoneNumOfOwner,
            eStatus i_StatusOfvehicle = eStatus.InRepair)
        {
            m_EnergyType = i_EnergyType;
            m_LicenseNumber = i_LicenseNumber;
            m_Model = i_Model;
            m_NameOfOwner = i_NameOfOwner;
            m_PhoneNumOfOwner = i_PhoneNumOfOwner;
            m_StatusOfVehicle = i_StatusOfvehicle;
        }

        internal void FillTires(bool i_fillAll, float i_AirToFill = 0)
        {
            foreach (Wheel wheel in m_Wheels)
            { 
                wheel.FillTire(i_fillAll, i_AirToFill);
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

            }   // get method
            set
            {
                StatusOfVehicle = value;
            }  
        }

        public override string ToString()
        {
            StringBuilder sbForWheels = new StringBuilder();
            int i = 0;
            foreach (Wheel wheel in m_Wheels)
            {
                sbForWheels.Append(string.Format("wheel number {0}: {1}", i ,wheel.ToString()));
                i++;
            }
            return string.Format(
                "Licence Number: {0}\n, Model {1}\n, name of owner: {2}\n, status of vehicle {3}\n, type Of energy car takes: {4}\n, percentage left in car {5}:\n wheel info \n {6}",
                m_LicenseNumber,
                m_Model,
                m_NameOfOwner,
                m_StatusOfVehicle,
                m_Energy.EnergyType,
                m_Energy.GetEnergyPercentage(), sbForWheels);
        }

        public override int GetHashCode()
        {
            return int.Parse(m_LicenseNumber);
        }

    }

}
