using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Truck : Vehicle
    {
        internal const eFuelType k_FuelType = eFuelType.Soler;
        internal const float k_MaxLiterFuel = 120f;
        internal const int k_WheelsNumber = 12;
        internal const float k_MaxWheelAirPressure = 28;
        private bool m_IsTransportsHazardousMaterials;
        private float m_CargoVolume;
        internal Truck(string i_LicenseNumber, EnergyVehicle i_EnergyVehicle)
           : base(i_LicenseNumber, i_EnergyVehicle) {}
        private bool IsTransportsHazardousMaterials
        {
            set
            {
                this.m_IsTransportsHazardousMaterials = value;
            }
        }
        private float CargoVolume
        {
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The cargo volume must be positive number");
                }

                this.m_CargoVolume = value;
            }
        }
        protected override int WheelsNumber
        {
            get
            {
                return k_WheelsNumber;
            }
        }
        protected override float MaxWheelAirPressure
        {
            get
            {
                return k_MaxWheelAirPressure;
            }
        }
        internal override eFuelType FuelType
        {
            get
            {
                return k_FuelType;
            }
        }
        public override Dictionary<string, InputDataDefinition> SendDescriptionInputsOfUniqInfoForNewVehicle()
        {
            InputDataDefinition isTransportsHazardousMaterialsDataDefinition, cargoVolume;
            Dictionary<string, InputDataDefinition> uniqInputToDescription =
                              new Dictionary<string, InputDataDefinition>();

            isTransportsHazardousMaterialsDataDefinition = new InputDataDefinition(
                "Enter Y/N if truck transports hazardous materials: ", typeof(bool));
            uniqInputToDescription.Add("IsTransportsHazardousMaterials",
                isTransportsHazardousMaterialsDataDefinition);
            cargoVolume = new InputDataDefinition("Enter truck cargo volume: ", typeof(float));
            uniqInputToDescription.Add("CargoVolume",cargoVolume);

            return uniqInputToDescription;
        }
        internal override void SetUniqInputInfoForNewVehicle(Dictionary<string, object> i_UniqInputsToObjectValue)
        {
            this.IsTransportsHazardousMaterials = (bool)i_UniqInputsToObjectValue["IsTransportsHazardousMaterials"];
            this.CargoVolume = (float)i_UniqInputsToObjectValue["CargoVolume"];
        }
        public override string ToString()
        {
            return string.Format(@"{0}
-----Truck details-----
Is Transports Hazardous Materials: {1}
Engine Volume: {2}", base.ToString(), this.m_IsTransportsHazardousMaterials, this.m_CargoVolume);
        }
    }
}
