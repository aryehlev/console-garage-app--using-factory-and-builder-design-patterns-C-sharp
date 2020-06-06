using System;


namespace Ex03.GarageLogic
{
     public class CarRegistary
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
            string i_WheelManufactor,
            float i_CurrentAirPresure,
            float i_CurrentEnergyLevel, 
            params Object[] i_OptionalParams)
        {
            Vehicle vehicleWanted;
            switch(i_VehicleType)
            {
                case eVehicleType.Car:
                    vehicleWanted = new Car((eColour)i_OptionalParams[0], (byte)i_OptionalParams[1], i_Model, i_LicenseNumber, i_Energy, i_NameOfOwner, i_PhoneNumOfOwner, i_WheelManufactor, i_CurrentAirPresure, i_CurrentEnergyLevel);
                    break;
                case eVehicleType.Truck:
                    vehicleWanted = new Truck(eColour)i_OptionalParams[0], (byte)i_OptionalParams[1], i_Model, i_LicenseNumber, i_Energy, i_NameOfOwner, i_PhoneNumOfOwner, i_WheelManufactor, i_CurrentAirPresure, i_CurrentEnergyLevel);
                    break;
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }
        }

}
}
