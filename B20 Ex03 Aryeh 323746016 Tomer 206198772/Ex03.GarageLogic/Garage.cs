using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private Dictionary<string, Vehicle> m_VehiclesDatabase;

        public Garage(Dictionary<string, Vehicle> i_VehiclesDatabase)
        {
            m_VehiclesDatabase = i_VehiclesDatabase;
        }

        public bool IsVehicleRegistered(string i_LicenseNumber)
        {
            return m_VehiclesDatabase.ContainsKey(i_LicenseNumber);
        }

        public void ChangeStatusOfVehicle(string i_LicenseNumber, eStatus i_NewStatus)
        {
            Vehicle vehicleToChangeStatus;
            m_VehiclesDatabase.TryGetValue(i_LicenseNumber, out vehicleToChangeStatus))
            vehicleToChangeStatus.StatusOfVehicle = i_NewStatus;
        }

        //public AddVehice();

        public List<string> GetAllLicenseNumbers(eStatus i_WantedStatuses, bool i_WantBySpecificStatus)
        {
            List<string> listToReturn = new List<string>();

            foreach (KeyValuePair<string, Vehicle> keyValuePair in m_VehiclesDatabase)
            {
                if(i_WantBySpecificStatus && keyValuePair.Value.StatusOfVehicle == i_WantedStatuses)
                {
                    listToReturn.Add(keyValuePair.Key);
                }
                else if(!i_WantBySpecificStatus)
                {
                    listToReturn.Add(keyValuePair.Key);
                }
            }

            return listToReturn;
        }

        public void FillTiresToMax(string i_LicenseNumber)
        {
            Vehicle vehicleToFill;
            m_VehiclesDatabase.TryGetValue(i_LicenseNumber, out vehicleToFill))
            vehicleToFill.FillTires(true);
        }

        public void FllEnergy(string i_LicenseNumber, float i_Energy, eEnergyType i_EnergyType)
        {
            Vehicle vehicleToFIll;
            m_VehiclesDatabase.TryGetValue(i_LicenseNumber, out vehicleToFIll))
            vehicleToFIll.FillEnergy(i_Energy, i_EnergyType);
        }

        public string GetVehicleData(string i_LicenseNumber)
        {
            Vehicle vehicleToReturnData;
            m_VehiclesDatabase.TryGetValue(i_LicenseNumber, out vehicleToReturnData))
            return vehicleToReturnData.ToString();
        }
    }
}
