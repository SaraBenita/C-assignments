using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class FuelEnergy : EnergyVehicle
    {
        private eFuelType m_FuelType;
        internal FuelEnergy(float i_MaxAmountEnergy, eFuelType i_FuelType)
            : base(i_MaxAmountEnergy)
        {
            this.m_FuelType = i_FuelType;
        }
        public override string ToString()
        {
            return string.Format(@"{0}
Fuel Type: {1}", base.ToString(), this.m_FuelType.ToString());
        }
    }
}
