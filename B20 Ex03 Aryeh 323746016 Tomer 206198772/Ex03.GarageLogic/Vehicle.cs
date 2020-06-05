using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal abstract class Vehicle
    {
        string m_Model;
        string m_LicenseNumber;
        List<Wheel> m_Wheels;
        Energy m_Energy;
        string m_NameOfOwner;
        string m_PhoneNumOfOwner;
        private eStatus m_StatusOfVehicle;

        internal Vehicle(
            string i_Model,
            string i_LicenseNumber,
            Energy i_Energy,
            string i_NameOfOwner,
            string i_PhoneNumOfOwner,
            eStatus i_StatusOfvehicle = eStatus.InRepair)
        {
            m_Energy = i_Energy;
            m_LicenseNumber = i_LicenseNumber;
            m_Model = i_Model;
            m_NameOfOwner = i_NameOfOwner;
            m_PhoneNumOfOwner = i_PhoneNumOfOwner;
            m_StatusOfVehicle = i_StatusOfvehicle;
        }

        internal void FillTires(bool i_fillAll, float i_AirToFill)
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
            //+ToString()
        //+HashCode()
    }

}
