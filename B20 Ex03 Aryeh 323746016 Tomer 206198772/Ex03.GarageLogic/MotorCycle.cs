using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class MotorCycle : Vehicle
    {
        private const float k_MaxAirPressure = 30;
        private const float k_NumOfWheels = 2;
        private readonly eLicenseType m_TypeOfLicense;
        private readonly int m_cc;
        private readonly float r_MaxEnergyCapacity;

        public MotorCycle(eLicenseType i_TypeOfLicense, int i_Cc, string i_Model, string i_LicenseNumber, eEnergyType i_EnergyType, string i_NameOfOwner, string i_PhoneNumOfOwner,
                          string i_WheelManufactor, float i_CurrentAirPresure, float i_CurrentEnergyLevel, eStatus i_StatusOfvehicle = eStatus.InRepair)
            : base(i_Model, i_LicenseNumber, i_EnergyType, i_NameOfOwner, i_PhoneNumOfOwner, i_WheelManufactor, i_CurrentAirPresure, i_CurrentEnergyLevel, i_StatusOfvehicle)
        {
            m_TypeOfLicense = i_TypeOfLicense;
            m_cc = i_Cc;
            r_MaxEnergyCapacity = i_EnergyType == eEnergyType.Electric ? 1.2f : 7;
            base.m_Energy = new Energy(i_CurrentEnergyLevel, r_MaxEnergyCapacity, i_EnergyType);
            for (int i = 0; i < k_NumOfWheels; i++)
            {
                base.m_Wheels.Add(new Wheel(i_WheelManufactor, k_MaxAirPressure, i_CurrentAirPresure));
            }
        }

        public override string ToString()
        {
            return string.Format("{0}\n, type of license: {1},\n volume of engine: {2}\n", base.ToString(), m_TypeOfLicense, m_cc);
        }
    }
}
