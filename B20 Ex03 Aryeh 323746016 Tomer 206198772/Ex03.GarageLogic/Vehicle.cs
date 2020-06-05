using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    abstract class Vehicle
    {
        string m_Model;
        string m_LicenseNumber;
        List<Wheel> m_Wheels;
        Energy m_Energy;
        string m_NameOfOwner;
        string m_PhoneNumOfOwner;
        private eStatus m_StatusOfCar;

    }
}
