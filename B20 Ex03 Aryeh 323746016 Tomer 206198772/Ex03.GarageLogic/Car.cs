namespace Ex03.GarageLogic
{
    internal class Car : Vehicle
    {
        private const float k_MaxAirPressure = 32;
        private const byte k_NumOfWheels = 4;
        private readonly eColour r_Colour;
        private readonly byte r_NumOfDoors; 
        
        public Car(
            eColour i_Colour, 
            byte i_NumOfDoors, 
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
            r_Colour = i_Colour;
            r_NumOfDoors = i_NumOfDoors;
            float maxEnergyCapacity = i_EnergyType == eEnergyType.Electric ? 2.1f : 60;
            m_Energy = new Energy(i_CurrentEnergyLevel, maxEnergyCapacity, i_EnergyType);
            for(int i = 0; i < k_NumOfWheels; i++)
            {
               m_Wheels.Add(new Wheel(i_WheelManufactor, k_MaxAirPressure, i_CurrentAirPresure));
            }
        }

        public override string ToString()
        {
            return string.Format("{0}\n, colour of car: {1},\n number of doors in car: {2}\n", base.ToString(), r_Colour, r_NumOfDoors);
        }
    }
}
