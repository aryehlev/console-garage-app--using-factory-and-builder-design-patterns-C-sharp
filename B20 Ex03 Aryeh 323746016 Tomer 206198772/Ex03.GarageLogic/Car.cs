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
        private readonly eColour m_Colour;
        readonly byte m_numOfDoors;

        public Car(eColour i_Colour, byte i_NumOfDoors, string i_Model, string i_LicenseNumber, Energy i_Energy, string i_NameOfOwner, string i_PhoneNumOfOwner, eStatus i_StatusOfvehicle = eStatus.InRepair)
            : base(i_Model, i_LicenseNumber, i_Energy, i_NameOfOwner, i_PhoneNumOfOwner, i_StatusOfvehicle)
        {
            m_Colour = i_Colour;
            m_numOfDoors = i_NumOfDoors;
        }

        public override string ToString()
        {
            return string.Format("{0}", base.ToString());
        }
    }
}
