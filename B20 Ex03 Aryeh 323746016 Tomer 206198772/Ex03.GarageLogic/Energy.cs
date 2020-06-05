namespace Ex03.GarageLogic
{
    class Energy
    {
        private float m_CurrentFilled;
        private float m_MaxCapacity;
        eEnergyType m_EnergyType;
        
        void FillEnergy(float i_AmounOfEnergyToFill, eEnergyType energyType)
        {
            float newAmount = i_AmounOfEnergyToFill + m_CurrentFilled;
            if (newAmount > m_MaxCapacity)
            {
                throw new ValueOutOfRangeException(0, m_MaxCapacity - m_CurrentFilled); //fix
            }

            m_CurrentFilled = newAmount;
        }

        float GetEnergyPercentage()
        {
            return (m_CurrentFilled / m_MaxCapacity) * 100;
        }
    }
}
