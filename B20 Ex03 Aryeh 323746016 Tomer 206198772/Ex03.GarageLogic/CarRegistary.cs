namespace Ex03.GarageLogic
{
    internal class CarRegistary
    { 
        internal static Vehicle RegisterCar(
            eVehicleType i_VehicleType,
            string i_Model,
            string i_LicenseNumber,
            string i_NameOfOwner,
            string i_PhoneNumOfOwner)
        {
            Vehicle vehicleWanted = null;
            switch(i_VehicleType)
            {
                case eVehicleType.Car:
                    vehicleWanted = new Car(i_Model, i_LicenseNumber,  i_NameOfOwner, i_PhoneNumOfOwner);
                    break;
                case eVehicleType.Truck:
                    vehicleWanted = new Truck(i_Model, i_LicenseNumber, i_NameOfOwner, i_PhoneNumOfOwner);
                    break;
                case eVehicleType.MotorCycle:
                    vehicleWanted = new MotorCycle(i_Model, i_LicenseNumber, i_NameOfOwner, i_PhoneNumOfOwner);
                    break;
            }

            return vehicleWanted;
        }
    }
}
