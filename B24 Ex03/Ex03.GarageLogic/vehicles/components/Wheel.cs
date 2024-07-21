using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Wheel
    {
        private string m_ManufacturerName;
        private float m_CurrentAirPressure;
        private float m_MaxAirPressureByManufacturer;
        internal Wheel(float i_MaxAirPressureByManufacturer)
        {
            this.m_MaxAirPressureByManufacturer = i_MaxAirPressureByManufacturer;
        }
        internal string ManufacturerName
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Manufacturer name cannot be empty.");
                }
           
                if (!ManagerGarageLogic.IsAllLetters(value))
                {
                    throw new ArgumentException("Manufacturer name must contain only letters.");
                }

                m_ManufacturerName = value;
            }
        }
        internal float CurrentAirPressure
        {
            set
            {
                bool isInRange = value >= 0 && value <= this.m_MaxAirPressureByManufacturer;
                if (!isInRange)
                {
                    throw new ValueOutOfRangeException(0, this.m_MaxAirPressureByManufacturer, "Current Air Pressure");
                }

                this.m_CurrentAirPressure = value;
            }
        }
        private void inflatingWheel(float i_AirPressureToAdd)
        {
            float newAirPressure;

            newAirPressure = this.m_CurrentAirPressure + i_AirPressureToAdd;
            this.CurrentAirPressure = newAirPressure;
        }
        public override string ToString()
        {
            return string.Format(@"-----Wheel details-----
Manufacturer Name: {0}
Current Air Pressure: {1}
Max Air Pressure By Manufacturer: {2}",
this.m_ManufacturerName, this.m_CurrentAirPressure, this.m_MaxAirPressureByManufacturer);
        }
    }
}
