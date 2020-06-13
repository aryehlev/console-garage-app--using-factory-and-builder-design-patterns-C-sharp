namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private readonly string r_Manufacturer;
        private readonly float r_MaxPressure;
        private float m_CurrentPressure;

        internal Wheel(string i_Manufacturer,  float i_MaxPressure, float i_CurrentPressure)
        {
            r_Manufacturer = i_Manufacturer;
            r_MaxPressure = i_MaxPressure;
            m_CurrentPressure = i_CurrentPressure;
        }

        internal void FillTire(bool i_FillAll, float i_AirToFill = 0)
        {
            if(!i_FillAll)
            {
                float newPressure = i_AirToFill + m_CurrentPressure;
                if(newPressure > r_MaxPressure)
                {
                    throw new ValueOutOfRangeException(0, r_MaxPressure - m_CurrentPressure, "air to fill");
                }

                m_CurrentPressure = newPressure;
            }
            else
            {
                m_CurrentPressure = r_MaxPressure;
            }
        }

        public override string ToString()
        {
            return $"manufacturer of wheel: {r_Manufacturer}, pressure of wheel: {m_CurrentPressure}";
        }
    }
}
