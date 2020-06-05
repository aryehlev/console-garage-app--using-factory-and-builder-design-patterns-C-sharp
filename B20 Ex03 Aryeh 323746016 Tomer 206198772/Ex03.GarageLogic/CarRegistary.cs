using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
     class CarRegistary
    {
        public enum eVehicleType
        {
            Car, 
            Truck, 
            MotorCycle
        }

        public void RegisterCar(
            eVehicleType i_VehicleType,
            string i_Model,
            string i_LicenseNumber,
            eEnergyType i_Energy,
            string i_NameOfOwner,
            string i_PhoneNumOfOwner,
            eStatus i_StatusOfCar,
            params Object[] i_OptionalParams)
        {
            switch(i_VehicleType)
            {
                
            }
        }

    }
}
