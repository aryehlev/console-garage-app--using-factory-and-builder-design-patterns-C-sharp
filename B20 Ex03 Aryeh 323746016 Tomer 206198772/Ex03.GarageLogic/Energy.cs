using System;

namespace Ex03.GarageLogic
{
    public class Energy
    {
        private readonly float r_MaxCapacity;
        private readonly eEnergyType r_EnergyType;
        private float m_CurrentFilled;
        
        internal Energy(float i_CurrentFilled, float i_MaxCapacity, eEnergyType i_EnergyType)
        {
            m_CurrentFilled = i_CurrentFilled;
            r_EnergyType = i_EnergyType;
            r_MaxCapacity = i_MaxCapacity;
        } 
        
        internal void FillEnergy(float i_AmounOfEnergyToFill, eEnergyType i_EnergyType)
        {
            float newAmount = i_AmounOfEnergyToFill + m_CurrentFilled;
            if (newAmount > r_MaxCapacity)
            {
                throw new ValueOutOfRangeException(0, r_MaxCapacity - m_CurrentFilled);  
            }

            if(r_EnergyType != i_EnergyType)
            {
                throw new ArgumentException("wrong energy type for the car");
            }

            m_CurrentFilled = newAmount;
        }

        internal eEnergyType EnergyType
        {
            get
            {
                return r_EnergyType;
            }
        }

        internal float GetEnergyPercentage()
        {
            return (m_CurrentFilled / r_MaxCapacity) * 100;
        }

        internal float GetMaxAmountThatCanFill()
        {
            return r_MaxCapacity - m_CurrentFilled;
        }
    }
}
