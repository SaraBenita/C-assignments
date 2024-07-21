using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Car : Vehicle
    {
        internal const eFuelType k_FuelType = eFuelType.Octan95;
        internal const float k_MaxLiterFuel = 45;
        internal const float k_MaxButtery = 3.5f;
        internal const int k_WheelsNumber = 5;
        internal const float k_MaxWheelAirPressure = 31;
        private eColorType m_ColorCar;
        private eNumberDoorsPossible m_NumberDoors;

        internal Car(string i_LicenseNumber, EnergyVehicle i_EnergyVehicle)
            : base(i_LicenseNumber,i_EnergyVehicle) { }
        private eColorType ColorCar
        {
            set
            {
                if (!Enum.IsDefined(typeof(eColorType), value))
                {
                    throw new ArgumentException("Invalid car color");
                }

                this.m_ColorCar = value;
            }
        }
        private eNumberDoorsPossible NumberDoors
        {
            set
            {
                if (!Enum.IsDefined(typeof(eNumberDoorsPossible), value))
                {
                    throw new ArgumentException("Invalid number of doors in car");
                }

                this.m_NumberDoors = value;
            }
        }
        protected override int WheelsNumber
        {
            get
            {
                return k_WheelsNumber;
            }
        }
        internal override eFuelType FuelType
        {
            get
            {
                return k_FuelType;
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
            InputDataDefinition numDoorsDataDefinition, colorDataDefinition;
            Dictionary<string, InputDataDefinition> uniqInputToDescription =
                               new Dictionary<string, InputDataDefinition>();
            
            msg = getOptionsListVehicleColors(out max_Range);
            colorDataDefinition = new InputDataDefinition(msg, typeof(int));
            colorDataDefinition.IsInputSelectedFromList = true;
            colorDataDefinition.MaxRange = max_Range;
            uniqInputToDescription.Add("ColorCar", colorDataDefinition);
            msg = getOptionsListVehicleNumberDoors(out max_Range);
            numDoorsDataDefinition = new InputDataDefinition(msg, typeof(int));
            numDoorsDataDefinition.IsInputSelectedFromList = true;
            numDoorsDataDefinition.MaxRange = max_Range;
            uniqInputToDescription.Add("NumDoors", numDoorsDataDefinition);

            return uniqInputToDescription;
        }
        private string getOptionsListVehicleColors(out int o_MaxRange)
        {
            StringBuilder output = new StringBuilder();
            int countOptions = 1;

            foreach (eColorType type in Enum.GetValues(typeof(eColorType)))
            {
                output.AppendLine($"{countOptions} - {type.ToString()}");
                countOptions++;
            }

            o_MaxRange = countOptions - 1;
            output.Append("Enter the car color: ");

            return output.ToString();
        }
        private string getOptionsListVehicleNumberDoors(out int o_MaxRange)
        {
            StringBuilder output = new StringBuilder();
            int countOptions = 1;

            foreach (eNumberDoorsPossible type in Enum.GetValues(typeof(eNumberDoorsPossible)))
            {
                output.AppendLine($"{countOptions} - {type.ToString()}");
                countOptions++;
            }

            o_MaxRange = countOptions - 1;
            output.Append("Enter number of doors in car: ");

            return output.ToString();
        }
        internal override void SetUniqInputInfoForNewVehicle(
            Dictionary<string, object> i_UniqInputsToObjectValue)
        {
            this.ColorCar = (eColorType)i_UniqInputsToObjectValue["ColorCar"];
            this.NumberDoors = (eNumberDoorsPossible)i_UniqInputsToObjectValue["NumDoors"] + 1;
        }
        public override string ToString()
        {
            return string.Format(@"{0}
-----Car details-----
Color Car: {1}
Number Of Doors: {2}", base.ToString(), this.m_ColorCar.ToString(),this.m_NumberDoors.ToString());
        }
    }
}
