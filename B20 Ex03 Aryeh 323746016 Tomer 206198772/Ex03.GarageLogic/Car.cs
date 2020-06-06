using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class Car : Vehicle
    {
        private const float c_MaxAirPressure = 32;
        private const byte c_NumOfWheels = 4;
        private readonly float maxEnergyCapacity;
        private readonly eColour m_Colour;
        readonly byte m_numOfDoors;

        public Car(eColour i_Colour, byte i_NumOfDoors, string i_Model, string i_LicenseNumber, eEnergyType i_EnergyType, string i_NameOfOwner, string i_PhoneNumOfOwner, eStatus i_StatusOfvehicle = eStatus.InRepair)
            : base(i_Model, i_LicenseNumber, i_EnergyType, i_NameOfOwner, i_PhoneNumOfOwner, i_StatusOfvehicle)
        {
            m_Colour = i_Colour;
            m_numOfDoors = i_NumOfDoors;
            maxEnergyCapacity = i_EnergyType == eEnergyType.Electric ? 2.1f : 60;
            base.m_Energy = new Energy(0, maxEnergyCapacity, i_EnergyType);
            for(int i = 0; i < c_NumOfWheels; i++)
            {
                base.m_Wheels.Add(new Wheel(c_MaxAirPressure, 0));
            }
        }

        public override string ToString()
        {
            return string.Format("{0}\n, colour of car: {1},\n number of doors in car: {2}\n", base.ToString(), m_Colour, m_numOfDoors);
        }
    }
}
