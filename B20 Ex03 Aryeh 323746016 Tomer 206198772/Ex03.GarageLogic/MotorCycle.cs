namespace Ex03.GarageLogic
{
    internal class MotorCycle : Vehicle
    {
        private const float k_MaxAirPressure = 30;
        private const float k_NumOfWheels = 2;
        private readonly eLicenseType r_TypeOfLicense;
        private readonly int r_Cc;
        
        public MotorCycle(
            eLicenseType i_TypeOfLicense, 
            int i_Cc, 
            string i_Model, 
            string i_LicenseNumber, 
            eEnergyType i_EnergyType, 
            string i_NameOfOwner, 
            string i_PhoneNumOfOwner,
            string i_WheelManufactor, 
            float i_CurrentAirPresure, 
            float i_CurrentEnergyLevel, 
            eStatus i_StatusOfvehicle = eStatus.InRepair)
            : base(i_Model, i_LicenseNumber, i_EnergyType, i_NameOfOwner, i_PhoneNumOfOwner, i_WheelManufactor, i_CurrentAirPresure, i_CurrentEnergyLevel, i_StatusOfvehicle)
        {
            r_TypeOfLicense = i_TypeOfLicense;
            r_Cc = i_Cc;
            float maxEnergyCapacity = i_EnergyType == eEnergyType.Electric ? 1.2f : 7;
            m_Energy = new Energy(i_CurrentEnergyLevel, maxEnergyCapacity, i_EnergyType);
            for (int i = 0; i < k_NumOfWheels; i++)
            {
                m_Wheels.Add(new Wheel(i_WheelManufactor, k_MaxAirPressure, i_CurrentAirPresure));
            }
        }

        public override string ToString()
        {
            return string.Format("{0}\n, type of license: {1},\n volume of engine: {2}\n", base.ToString(), r_TypeOfLicense, r_Cc);
        }
    }
}
