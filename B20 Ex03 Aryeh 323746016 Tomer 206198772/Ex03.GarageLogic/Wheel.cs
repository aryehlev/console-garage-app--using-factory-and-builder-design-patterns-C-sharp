using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class Wheel
    {
        private string m_Manufactor;
        private float m_MaxPressure;
        private float m_CurrentPressure;

        void FillTire(bool i_fillAll, float i_AirToFill = 0)
        {
            if(!i_fillAll)
            {
                float airToFill = i_AirToFill + m_CurrentPressure;
                if(airToFill > m_MaxPressure)
                {
                    throw new ValueOutOfRangeException(0, m_MaxPressure - m_CurrentPressure);
                }

                m_CurrentPressure = airToFill;
            }

            m_CurrentPressure = m_MaxPressure - m_CurrentPressure;  
        }
    }
}
