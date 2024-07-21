using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private string m_ModelName;
        private string m_LicenseNumber;
        private List<Wheel> m_WheelsList;
        private EnergyVehicle m_EnergyVehicle;
        internal Vehicle(string i_LicenseNumber, EnergyVehicle i_EnergyVehicle)
        {
            this.LicenseNumber = i_LicenseNumber;
            this.m_EnergyVehicle = i_EnergyVehicle;
            initWheelsList();
        }
        internal EnergyVehicle EnergyVehicle
        {
            get
            {
                return m_EnergyVehicle;
            }
        }
        private string ModelName
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Model name cannot be empty.");
                }

                if (!ManagerGarageLogic.IsAllLetters(value))
                {
                    throw new ArgumentException("Model name must contain only letters.");
                }

                m_ModelName = value;
            }
        }
        internal string LicenseNumber
        {
            get
            {
                return m_LicenseNumber;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("License Number cannot be empty.");
                }

                if (!ManagerGarageLogic.IsAllDigits(value))
                {
                    throw new ArgumentException("License Number must contain only digits.");
                }

                m_LicenseNumber = value;
            }
        }
        internal abstract eFuelType FuelType { get; }
        protected abstract int WheelsNumber { get; }
        protected abstract float MaxWheelAirPressure { get; }
        public abstract Dictionary<string, InputDataDefinition> SendDescriptionInputsOfUniqInfoForNewVehicle();
        internal abstract void SetUniqInputInfoForNewVehicle(Dictionary<string, object> i_UniqInputsToObjectValue);
        private void initWheelsList()
        {
            int numWheels;
            float maxWheelAirPressure;

            numWheels = this.WheelsNumber;
            maxWheelAirPressure = this.MaxWheelAirPressure;
            this.m_WheelsList = new List<Wheel>();
            for (int i=0;i< numWheels; i++)
            {
                this.m_WheelsList.Add(new Wheel(maxWheelAirPressure));
            }
        }
        public Dictionary<string, InputDataDefinition> SendDescriptionInputsOfCommonInfoForNewVehicle()
        {
            Dictionary<string, InputDataDefinition> commonInputToDescription =
                               new Dictionary<string, InputDataDefinition>();

            commonInputToDescription.Add("ModelName",
                new InputDataDefinition("Enter model vehicle name: ", typeof(string)));
            commonInputToDescription.Add("CurrntEnergy",
                 new InputDataDefinition("Enter current energy in vehicle: ", typeof(float)));
            commonInputToDescription.Add("ManufacturerWheels",
                new InputDataDefinition("Enter manufacturer wheels name: ", typeof(string)));
            commonInputToDescription.Add("CurrntWheelAirPressure",
                new InputDataDefinition("Enter currnt wheel air pressure: ", typeof(float)));

            return commonInputToDescription;
        }
        internal void SetCommonInputInfoForNewVehicle(Dictionary<string, object> i_CommonInputsToObjectValue)
        {
            this.ModelName = (string)i_CommonInputsToObjectValue["ModelName"];
            this.m_EnergyVehicle.CurrentAmountEnergy = (float)i_CommonInputsToObjectValue["CurrntEnergy"];       
            setInfoWheelsList((string)i_CommonInputsToObjectValue["ManufacturerWheels"],
                (float)i_CommonInputsToObjectValue["CurrntWheelAirPressure"]);
        }
        private void setInfoWheelsList(string i_ManufacturerName, float i_CurrentAirPressure)
        {
            foreach(Wheel wheel in this.m_WheelsList)
            {
                wheel.ManufacturerName = i_ManufacturerName;
                wheel.CurrentAirPressure = i_CurrentAirPressure;
            }
        }
        internal void ChangeWheelsListAirPressureToMaximum()
        {
            foreach(Wheel wheel in this.m_WheelsList)
            {
                wheel.CurrentAirPressure = this.MaxWheelAirPressure;
            }
        }
        public override string ToString()
        {
            return string.Format(@"-----Vehicle details-----
Model Name: {0}
License Number: {1}
Number Of Wheels: {2}
{3}
{4}", this.m_ModelName, this.m_LicenseNumber,this.m_WheelsList.Count,
this.m_WheelsList[0].ToString(), this.EnergyVehicle.ToString());
        }
    }
}
