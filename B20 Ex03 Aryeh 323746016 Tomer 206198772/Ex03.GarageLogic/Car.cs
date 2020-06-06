using System;

namespace Ex03.GarageLogic
{
    internal class Car : Vehicle
    {
        private const float k_MaxAirPressure = 32;
        private const byte k_NumOfWheels = 4;
        private eColour m_Colour;
        private byte m_NumOfDoors;

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
            : base(
                i_Model,
                i_LicenseNumber,
                i_EnergyType,
                i_NameOfOwner,
                i_PhoneNumOfOwner,
                i_WheelManufactor,
                i_CurrentAirPresure,
                i_CurrentEnergyLevel,
                i_StatusOfvehicle)
        {
            float maxEnergyCapacity = i_EnergyType == eEnergyType.Electric ? 2.1f : 60;

            if(i_CurrentEnergyLevel > maxEnergyCapacity)
            {
                throw new ValueOutOfRangeException(0, maxEnergyCapacity);
            }

            m_Energy = new Energy(i_CurrentEnergyLevel, maxEnergyCapacity, i_EnergyType);

            if(i_CurrentAirPresure > k_MaxAirPressure)
            {
                throw new ValueOutOfRangeException(0, k_MaxAirPressure);
            }

            for(int i = 0; i < k_NumOfWheels; i++)
            {
                m_Wheels.Add(new Wheel(i_WheelManufactor, k_MaxAirPressure, i_CurrentAirPresure));
            }
        }

        internal override string[] GetSpecificFeatureDescription()
        {
            return new[] {"Colour",  "number of doors"};
        }
        
        internal override void ParseAndSetSpecificFeatures(string[] i_SpecificFeatures)
        {
            string firstFeature = i_SpecificFeatures[0];
            string secondFeature = i_SpecificFeatures[1];
            eColour colour;
            if(Enum.TryParse(firstFeature, true, out colour))
            {
                m_Colour = colour;
            }
            else
            {
                throw new FormatException("needs a colour of White, Black, Silver or Red");
            }

            byte numOfDoors;
            if(byte.TryParse(secondFeature, out numOfDoors) && (numOfDoors == 2 || numOfDoors == 3 || numOfDoors == 4 || numOfDoors ==  5))
            {

                m_NumOfDoors = numOfDoors;
            }
            else
            {
                throw new FormatException("needs a door 2,3,4 or 5");
            }
        }

        public override string ToString()
        {
            return string.Format("{0}\n, colour of car: {1},\n number of doors in car: {2}\n", base.ToString(), m_Colour, m_NumOfDoors);
        }
    }
}
