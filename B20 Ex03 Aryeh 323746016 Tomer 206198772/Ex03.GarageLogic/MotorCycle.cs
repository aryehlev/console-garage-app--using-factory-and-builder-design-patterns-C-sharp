using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class MotorCycle
    {
        private const float k_MaxAirPressure = 30;
        private const float k_NumOfWheels = 2;
        private eLicenseType m_TypeOfLicense;
        private int m_cc;

        public MotorCycle(eLicenseType i_TypeOfLicense, int i_Cc)
        {
            m_TypeOfLicense = i_TypeOfLicense;
            m_cc = i_Cc;
        }
    }
}
