namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private readonly string r_Manufactor;
        private readonly float r_MaxPressure;
        private float m_CurrentPressure;

        internal Wheel(string i_Manufactor,  float i_MaxPressure, float i_CurrentPressure)
        {
            r_Manufactor = i_Manufactor;
            r_MaxPressure = i_MaxPressure;
            m_CurrentPressure = i_CurrentPressure;
        }

        internal void FillTire(bool i_FillAll, float i_AirToFill = 0)
        {
            if(!i_FillAll)
            {
                float airToFill = i_AirToFill + m_CurrentPressure;
                if(airToFill > r_MaxPressure)
                {
                    throw new ValueOutOfRangeException(0, r_MaxPressure - m_CurrentPressure);
                }

                m_CurrentPressure = airToFill;
            }

            m_CurrentPressure = r_MaxPressure - m_CurrentPressure;  
        }

        public override string ToString()
        {
            return string.Format("manufactor of wheel: {0}, pressure of wheel: {1}", r_Manufactor, m_CurrentPressure);
        }
    }
}
