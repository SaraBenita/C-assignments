using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Motorcycle : Vehicle
    {
        internal const eFuelType k_FuelType = eFuelType.Octan98;
        internal const float k_MaxLiterFuel = 5.5f;
        internal const float k_MaxButtery = 2.5f;
        internal const int k_WheelsNumber = 2;
        internal const float k_MaxWheelAirPressure = 33;
        private eLicenseType m_LicenseType;
        private int m_EngineVolume;
        internal Motorcycle(string i_LicenseNumber, EnergyVehicle i_EnergyVehicle)
         : base(i_LicenseNumber, i_EnergyVehicle) {}
        internal override eFuelType FuelType
        {
            get
            {
                return k_FuelType;
            }
        }
        private eLicenseType LicenseType
        {
            set
            {
                if (!Enum.IsDefined(typeof(eLicenseType), value))
                {
                    throw new ArgumentException("Invalid motorcycle license type");
                }

                this.m_LicenseType = value;
            }
        }
        private int EngineVolume
        {
            set
            {
                if(value < 0)
                {
                    throw new ArgumentOutOfRangeException("The engine volume must be positive number");
                }

                this.m_EngineVolume = value;
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
        public override Dictionary<string, InputDataDefinition> SendDescriptionInputsOfUniqInfoForNewVehicle()
        {
            int max_Range;
            string msg;
            InputDataDefinition licenseTypeDataDefinition, numDoorsDataDefinition;
            Dictionary<string, InputDataDefinition> uniqInputToDescription =
                              new Dictionary<string, InputDataDefinition>();
           
            msg = getOptionsListMotorcycleLicenseType(out max_Range);
            licenseTypeDataDefinition = new InputDataDefinition(msg, typeof(int));
            licenseTypeDataDefinition.IsInputSelectedFromList = true;
            licenseTypeDataDefinition.MaxRange = max_Range;
            uniqInputToDescription.Add("LicenseType", licenseTypeDataDefinition);
            numDoorsDataDefinition = new InputDataDefinition("Enter engine volume:", typeof(int));
            uniqInputToDescription.Add("EngineVolume", numDoorsDataDefinition);

            return uniqInputToDescription;
        }
        private string getOptionsListMotorcycleLicenseType(out int o_MaxRange)
        {
            StringBuilder output = new StringBuilder();
            int countOptions = 1;

            foreach (eLicenseType type in Enum.GetValues(typeof(eLicenseType)))
            {
                output.AppendLine($"{countOptions} - {type.ToString()}");
                countOptions++;
            }

            o_MaxRange = countOptions - 1;
            output.Append("Enter type of license in motorcycle: ");

            return output.ToString();
        }
        internal override void SetUniqInputInfoForNewVehicle(
            Dictionary<string, object> i_UniqInputsToObjectValue)
        {
            this.LicenseType = (eLicenseType)i_UniqInputsToObjectValue["LicenseType"];
            this.EngineVolume = (int)i_UniqInputsToObjectValue["EngineVolume"];
        }
        public override string ToString()
        {
            return string.Format(@"{0}
-----Motorcycle details-----
License Type: {1}
Engine Volume: {2}", base.ToString(), this.m_LicenseType.ToString(), this.m_EngineVolume.ToString());
        }
    }
}
