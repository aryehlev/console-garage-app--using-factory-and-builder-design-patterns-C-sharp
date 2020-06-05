namespace Ex03.GarageLogic
{
    internal class Truck : Vehicle
    {
        private const float c_MaxAirPressure = 28;
        private const byte c_NumOfWheels = 16;
        private readonly bool m_HasHazardasCargo;
        private readonly float m_VolumeOfCargo;

        internal Truck(bool i_HasHazardasCargo, float i_VolumeOfCargo, string i_Model, string i_LicenseNumber, Energy i_Energy, string i_NameOfOwner, string i_PhoneNumOfOwner, eStatus i_StatusOfvehicle = eStatus.InRepair)
            : base(i_Model, i_LicenseNumber, i_Energy, i_NameOfOwner, i_PhoneNumOfOwner, i_StatusOfvehicle)
        {
            m_HasHazardasCargo = i_HasHazardasCargo;
            m_VolumeOfCargo = i_VolumeOfCargo;
        }

        public override string ToString()
        {
            return string.Format("{0}\n, has hazardoes cargo: {1},\n volume of cargo: {2}\n", base.ToString(), m_HasHazardasCargo, m_VolumeOfCargo);
        }
    }

}
