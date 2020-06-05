using System;


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

        public static void RegisterCar(
            eVehicleType i_VehicleType,
            string i_Model,
            string i_LicenseNumber,
            eEnergyType i_Energy,
            string i_NameOfOwner,
            string i_PhoneNumOfOwner,
            eStatus i_StatusOfCar,
            params Object[] i_OptionalParams)
        {
            Vehicle vehicleWanted;
            switch(i_VehicleType)
            {
                case eVehicleType.Car:
                    vehicleWanted = new Car((eColour)i_OptionalParams[0], (byte)i_OptionalParams[1], i_Model, i_LicenseNumber, i_Energy, i_NameOfOwner, i_PhoneNumOfOwner);
                    break;
                case eVehicleType.Truck:
                   
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }
        }

}
}
