using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class ElectricEnergy : EnergyVehicle
    {
        internal ElectricEnergy(float i_MaxAmountEnergy)
            : base(i_MaxAmountEnergy) {}
        public override string ToString()
        {
            return string.Format(@"{0}", base.ToString());
        }
    }
}
