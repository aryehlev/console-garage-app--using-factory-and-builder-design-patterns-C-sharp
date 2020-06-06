using System;

namespace Ex03.GarageLogic
{
    public class Energy
    {
        private float m_CurrentFilled;
        private float m_MaxCapacity;
        eEnergyType m_EnergyType;

        internal Energy(float i_CurrentFilled, float i_MaxCapacity, eEnergyType i_EnergyType)
        {
            m_CurrentFilled = i_CurrentFilled;
            m_EnergyType = i_EnergyType;
            m_MaxCapacity = i_MaxCapacity;
        } 
        
        internal void FillEnergy(float i_AmounOfEnergyToFill, eEnergyType energyType)
        {
            float newAmount = i_AmounOfEnergyToFill + m_CurrentFilled;
            if (newAmount > m_MaxCapacity)
            {
                throw new ValueOutOfRangeException(0, m_MaxCapacity - m_CurrentFilled); //fix
            }

            if(m_EnergyType != energyType)
            {
                throw new ArgumentException("wrong energy type for the car");
            }

            m_CurrentFilled = newAmount;
        }

        internal eEnergyType EnergyType
        {
            get
            {
                return m_EnergyType;
            }
        }

        internal float GetEnergyPercentage()
        {
            return (m_CurrentFilled / m_MaxCapacity) * 100;
        }
    }
}
