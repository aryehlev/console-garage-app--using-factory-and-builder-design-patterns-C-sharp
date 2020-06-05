using System;

namespace Ex03.GarageLogic
{
    class ValueOutOfRangeException : Exception
    {
        private float m_MaxValue;
        private float m_MinValue;

        public float MaxValue
        {
            get
            {
                return m_MaxValue;
            }
        }

        public float MinValue
        {
            get
            {
                return m_MinValue;
            }
        }

        public ValueOutOfRangeException(Exception i_InnerException, float i_MinValue, float i_MaxValue)
            : base("aaahhhhhhhh bagigiiiiiiiii")
        {
            m_MaxValue = i_MaxValue;
            m_MinValue = i_MinValue;
        }
        



    }
}
