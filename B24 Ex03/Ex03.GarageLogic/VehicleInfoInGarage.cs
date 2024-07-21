using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class VehicleInfoInGarage
    {
        private string m_OwnerName;
        private string m_OwnerPhoneNumber;
        private eVehicleStateInGarage m_VehicleStateInGarage = eVehicleStateInGarage.InRepare;
        private Vehicle m_Vehicle;
        internal eVehicleStateInGarage VehicleStateInGarage
        {
            get
            {
                return m_VehicleStateInGarage;
            }
            set
            {
                this.m_VehicleStateInGarage = value;
            }
        }
        internal string OwnerName
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Owner name cannot be empty.");
                }

                if (!ManagerGarageLogic.IsAllLetters(value))
                {
                    throw new ArgumentException("Owner name must contain only letters.");
                }

                m_OwnerName = value;
            }
        }
        internal string OwnerPhoneNumber
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Owner phone number cannot be empty.");
                }

                if (!ManagerGarageLogic.IsAllDigits(value))
                {
                    throw new ArgumentException("Owner phone number must contain only digits.");
                }

                m_OwnerPhoneNumber = value;
            }
        }
        internal Vehicle Vehicle
        {
            get
            {
                return m_Vehicle;
            }
            set
            {
                m_Vehicle = value;
            }
        }
        public override string ToString()
        {
            return string.Format(@"Owner Name: {0}
Owner Phone Number: {1}
Vehicle State In Garage: {2}
{3}", this.m_OwnerName, this.m_OwnerPhoneNumber, m_VehicleStateInGarage.ToString(),Vehicle.ToString());
        }
    }
}
