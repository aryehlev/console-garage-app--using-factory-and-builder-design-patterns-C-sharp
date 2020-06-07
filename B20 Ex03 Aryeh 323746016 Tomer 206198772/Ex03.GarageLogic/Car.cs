using System;

namespace Ex03.GarageLogic
{
    internal class Car : Vehicle
    {
        private const float k_MaxAirPressure = 32;
        private const byte k_NumOfWheels = 4;
        private const float k_MaxElectric = 2.1f;
        private const float k_MaxSolar = 60;
        private const int k_NumOfFeatures = 2;
        private eColour m_Colour;
        private byte m_NumOfDoors;

        public Car(
            string i_Model,
            string i_LicenseNumber,
            string i_NameOfOwner,
            string i_PhoneNumOfOwner,
            eStatus i_StatusOfvehicle = eStatus.InRepair)
            : base(i_Model, i_LicenseNumber, i_NameOfOwner, i_PhoneNumOfOwner)
        {

        }
        
        public override void SetParamaters(eEnergyType i_EnergyType, string i_WheelManufactor, float i_CurrentAirPressure, float i_CurrentEnergyLevel, object[] i_SpecificFeatures = null)
        {

            float maxEnergyCapacity = i_EnergyType == eEnergyType.Electric ? k_MaxElectric : k_MaxSolar;

            if (i_CurrentEnergyLevel > maxEnergyCapacity)
            {
                throw new ValueOutOfRangeException(0, maxEnergyCapacity);
            }

            m_Energy = new Energy(i_CurrentEnergyLevel, maxEnergyCapacity, i_EnergyType);

            if (i_CurrentAirPressure > k_MaxAirPressure)
            {
                throw new ValueOutOfRangeException(0, k_MaxAirPressure);
            }

            for (int i = 0; i < k_NumOfWheels; i++)
            {
                m_Wheels.Add(new Wheel(i_WheelManufactor, k_MaxAirPressure, i_CurrentAirPressure));
            }

            m_Colour = (eColour)i_SpecificFeatures[0];
            m_NumOfDoors = (byte)i_SpecificFeatures[1];
        }

        public override string[] GetSpecificFeatureDescription()
        {
            return new[] { "Colour", "number of doors" };
        }

        public override object[] ParseSpecificFeatures(string[] i_SpecificFeatures)
        {
            string firstFeature = i_SpecificFeatures[0];
            string secondFeature = i_SpecificFeatures[1];
            object[] specificFeatures = new object[k_NumOfFeatures];
            eColour colour;
            if (Enum.TryParse(firstFeature, true, out colour))
            {
                specificFeatures[0] = colour;
            }
            else
            {
                throw new FormatException("needs a colour of White, Black, Silver or Red");
            }

            byte numOfDoors;
            if (byte.TryParse(secondFeature, out numOfDoors) && (numOfDoors == 2 || numOfDoors == 3 || numOfDoors == 4 || numOfDoors == 5))
            {

                specificFeatures[1] = numOfDoors;
            }
            else
            {
                throw new FormatException("needs a door 2,3,4 or 5");
            }

            return specificFeatures;
        }

        public override string ToString()
        {
            return string.Format("{0}\n, colour of car: {1},\n number of doors in car: {2}\n", base.ToString(), m_Colour, m_NumOfDoors);
        }
    }
}
