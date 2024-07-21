using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal abstract class EnergyVehicle
    {
        private float m_CurrentAmountEnergy;
        private float m_MaxAmountEnergy;
        private float m_PercentEnergyLeft;
        protected EnergyVehicle(float i_MaxAmountEnergy)
        {
            this.m_MaxAmountEnergy = i_MaxAmountEnergy;
        }
        private float PercentEnergyLeft
        {
            set
            {
                if (value >= 0 && value <= 100) // Check if the input is between 0 and 100
                {
                    m_PercentEnergyLeft = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Percent energy left must be between 0 and 100");
                }
            }
        }
        internal float CurrentAmountEnergy
        {
            set
            {
                bool isInRange = value >= 0 && value <= this.m_MaxAmountEnergy;
                if (!isInRange)
                {
                    throw new ValueOutOfRangeException(0, this.m_MaxAmountEnergy, "Current Amount Energy");
                }

                this.m_CurrentAmountEnergy = value;
                calcPercentEnergyLeft();
            }
        }
        private void calcPercentEnergyLeft()
        {
            if(this.m_MaxAmountEnergy == 0)
            {
                throw new DivideByZeroException("Max energy cannot be zero");
            }

            this.PercentEnergyLeft = (this.m_CurrentAmountEnergy / this.m_MaxAmountEnergy) * 100;
        }
        internal void AddEnergy(float i_EnergyToAdd)
        {
            float newEnergy;

            newEnergy = this.m_CurrentAmountEnergy + i_EnergyToAdd;
            this.CurrentAmountEnergy = newEnergy;
        }
        public override string ToString()
        {
            return string.Format(@"-----Vehicle details-----
Current Amount Energy: {0}
Max Amount Energy: {1}
Percent Energy Left: {2} %", this.m_CurrentAmountEnergy, this.m_MaxAmountEnergy, this.m_PercentEnergyLeft);
        }
    }
}

