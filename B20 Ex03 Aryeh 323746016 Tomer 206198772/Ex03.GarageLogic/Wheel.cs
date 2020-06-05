namespace Ex03.GarageLogic
{
    internal class Wheel
    {
        private string m_Manufactor;
        private float m_MaxPressure;
        private float m_CurrentPressure;

        internal Wheel(string i_Manufactor,  float i_MaxPressure, float i_CurrentPressure)
        {
            m_Manufactor = i_Manufactor;
            m_MaxPressure = i_MaxPressure;
            m_CurrentPressure = i_CurrentPressure;
        }

        internal void FillTire(bool i_fillAll, float i_AirToFill = 0)
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

        public override string ToString()
        {
            return string.Format("manufactor of wheel: {0}, pressure of wheel: {1}", m_Manufactor, m_CurrentPressure);
        }
    }
}
