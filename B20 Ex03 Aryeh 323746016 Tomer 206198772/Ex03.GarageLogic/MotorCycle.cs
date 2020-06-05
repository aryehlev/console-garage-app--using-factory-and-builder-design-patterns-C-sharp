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

        internal MotorCycle(eLicenseType i_TypeOfLicense, int i_Cc, string i_Model, string i_LicenseNumber, Energy i_Energy, string i_NameOfOwner, string i_PhoneNumOfOwner, eStatus i_StatusOfvehicle = eStatus.InRepair)
            : base(i_Model, i_LicenseNumber, i_Energy, i_NameOfOwner, i_PhoneNumOfOwner, i_StatusOfvehicle)
        {
            m_TypeOfLicense = i_TypeOfLicense;
            m_cc = i_Cc;
        }

        public override string ToString()
        {
            return string.Format("{0}\n, type of license: {1},\n volume of engine: {2}\n", base.ToString(), m_TypeOfLicense, m_cc);
        }
    }
}
