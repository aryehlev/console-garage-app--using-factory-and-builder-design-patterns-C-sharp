using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private readonly Dictionary<string, Vehicle> r_VehiclesDatabase; 
        
        public Garage()
        {
            r_VehiclesDatabase = new Dictionary<string, Vehicle>();
        }

        public Vehicle AddVehicle(
            eVehicleType i_VehicleType,
            string i_Model,
            string i_LicenseNumber,
            string i_NameOfOwner,
            string i_PhoneNumOfOwner)
        {
            Vehicle newVehicle = CarRegistary.RegisterCar(i_VehicleType, i_Model, i_LicenseNumber, i_NameOfOwner, i_PhoneNumOfOwner);
            r_VehiclesDatabase.Add(i_LicenseNumber, newVehicle);
            return newVehicle;
        }

        private Vehicle getVehicle(string i_LicenseNumber)
        {
            r_VehiclesDatabase.TryGetValue(i_LicenseNumber, out Vehicle vehicleToReturn);
            return vehicleToReturn;
        }
        
        public bool IsVehicleRegistered(string i_LicenseNumber)
        {
            return r_VehiclesDatabase.ContainsKey(i_LicenseNumber);
        }

        public void ChangeStatusOfVehicle(string i_LicenseNumber, eStatus i_NewStatus)
        {
            getVehicle(i_LicenseNumber).StatusOfVehicle = i_NewStatus;
        }

        public eEnergyType GetEnergyType(string i_LicenseNumber)
        {
            return getVehicle(i_LicenseNumber).GetEnergyType();
        }

        public List<string> GetAllLicenseNumbers(eStatus i_WantedStatus = eStatus.None)
        {
            List<string> listToReturn = new List<string>();

            foreach (KeyValuePair<string, Vehicle> keyValuePair in r_VehiclesDatabase)
            {
                if(i_WantedStatus == eStatus.None)
                {
                    listToReturn.Add(keyValuePair.Key);
                }
                else if(i_WantedStatus == keyValuePair.Value.StatusOfVehicle)
                {
                    listToReturn.Add(keyValuePair.Key);
                }
            }

            return listToReturn;
        }

        public void FillTiresToMax(string i_LicenseNumber)
        {
            getVehicle(i_LicenseNumber).FillTires(true);
        }

        public void FllEnergy(string i_LicenseNumber, float i_Energy, eEnergyType i_EnergyType)
        {
            getVehicle(i_LicenseNumber).FillEnergy(i_Energy, i_EnergyType);
        }

        public string GetVehicleData(string i_LicenseNumber)
        {
            return getVehicle(i_LicenseNumber).AdvancesToStringAfterFeaturesWhereSet();
        }

        public float GetMaxEnergyLeftToFill(string i_LicenseNumber)
        {
            return getVehicle(i_LicenseNumber).GetMaxEnergyAmountThatCanFill();
        }
    }
}
