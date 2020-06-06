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

        public void AddVehicle(
            eVehicleType i_VehicleType,
            string i_Model,
            string i_LicenseNumber,
            eEnergyType i_Energy,
            string i_NameOfOwner,
            string i_PhoneNumOfOwner,
            string i_WheelManufactor,
            float i_CurrentAirPresure,
            float i_CurrentEnergyLevel
            )
        {
            r_VehiclesDatabase.Add(i_LicenseNumber, CarRegistary.RegisterCar(i_VehicleType, i_Model, i_LicenseNumber, i_Energy, i_NameOfOwner, i_PhoneNumOfOwner, i_WheelManufactor, i_CurrentAirPresure, i_CurrentEnergyLevel));
            getVehicle(i_LicenseNumber).GetSpecificFeatureDescription();
        }

        private Vehicle getVehicle(string i_LicenseNumber)
        {
            Vehicle vehicleToReturn;
            r_VehiclesDatabase.TryGetValue(i_LicenseNumber, out vehicleToReturn);
            return vehicleToReturn;
        }

        public string[] GetSpecificFeatureDescription(string i_LicenseNumber)
        {
            string[] arrayOfFeatureDescriptions = getVehicle(i_LicenseNumber).GetSpecificFeatureDescription();
            return arrayOfFeatureDescriptions;
        }

        public void ParseAndSetSpecialFeatures(string i_LicenseNumber, string[] i_SpecificFeatures)
        {
            getVehicle(i_LicenseNumber).ParseAndSetSpecificFeatures(i_SpecificFeatures);
        }

        public bool IsVehicleRegistered(string i_LicenseNumber)
        {
            return r_VehiclesDatabase.ContainsKey(i_LicenseNumber);
        }

        public void ChangeStatusOfVehicle(string i_LicenseNumber, eStatus i_NewStatus)
        {

            getVehicle(i_LicenseNumber).StatusOfVehicle = i_NewStatus;
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
            Vehicle vehicleToFill;
            r_VehiclesDatabase.TryGetValue(i_LicenseNumber, out vehicleToFill);
            vehicleToFill.FillTires(true);
        }

        public void FllEnergy(string i_LicenseNumber, float i_Energy, eEnergyType i_EnergyType)
        {
            getVehicle(i_LicenseNumber).FillEnergy(i_Energy, i_EnergyType);
        }

        public string GetVehicleData(string i_LicenseNumber)
        {
            return getVehicle(i_LicenseNumber).ToString();
        }

        
    }
}
