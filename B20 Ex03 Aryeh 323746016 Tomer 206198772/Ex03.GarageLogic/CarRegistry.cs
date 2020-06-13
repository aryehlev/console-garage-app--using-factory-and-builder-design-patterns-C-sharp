namespace Ex03.GarageLogic
{
    internal class CarRegistry
    { 
        internal static VehicleBuilder RegisterVehicle(
            eVehicleType i_VehicleType,
            string i_Model,
            string i_LicenseNumber,
            string i_NameOfOwner,
            string i_PhoneNumOfOwner)
        {
            VehicleBuilder vehicleBuilder = null;
            switch(i_VehicleType)
            {
                case eVehicleType.Car:
                    vehicleBuilder = new VehicleBuilder(new Car(i_Model, i_LicenseNumber,  i_NameOfOwner, i_PhoneNumOfOwner));
                    break;
                case eVehicleType.Truck:
                    vehicleBuilder = new VehicleBuilder(new Truck(i_Model, i_LicenseNumber, i_NameOfOwner, i_PhoneNumOfOwner));
                    break;
                case eVehicleType.MotorCycle:
                    vehicleBuilder = new VehicleBuilder(new MotorCycle(i_Model, i_LicenseNumber, i_NameOfOwner, i_PhoneNumOfOwner));
                    break;
            }

            return vehicleBuilder;
        }
    }
}
