using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ManagerGarageLogic
    {
        private Dictionary<string, VehicleInfoInGarage> m_LicenseToVehicleInGarage;
        public ManagerGarageLogic()
        {
            this.m_LicenseToVehicleInGarage = new Dictionary<string, VehicleInfoInGarage>();
        }
        public bool CheckIfNewVehicleLicenseInGarageAndChangeState(string i_LicenseNumberStr)
        {
            bool isVehicleLicenseInGarage;

            isVehicleLicenseInGarage = this.m_LicenseToVehicleInGarage.ContainsKey(i_LicenseNumberStr);
            if (isVehicleLicenseInGarage)
            {
                this.m_LicenseToVehicleInGarage[i_LicenseNumberStr]
                    .VehicleStateInGarage = eVehicleStateInGarage.InRepare;
            }

            return isVehicleLicenseInGarage;
        }
        public void CheckIfVehicleLicenseInGarage(string i_LicenseNumberStr)
        {
            if (!this.m_LicenseToVehicleInGarage.ContainsKey(i_LicenseNumberStr))
            {
                throw new ArgumentException("Vehicle license number not in garage");
            }          
        }
        public Vehicle CreateNewVehicle(int i_VehicleType, string i_LicenseNumber)
        {
            return VehiclesCreator.CreateNewVehicleAccordingToType(i_VehicleType, i_LicenseNumber);
        }
        public List<string> GetListOfVehiclesInSystem()
        {
            return VehiclesCreator.GetListOfVehiclesType();
        }
        public void SetAndAddVehicleInfoToGarage(Dictionary<string, object> i_CommonInputsToObjectValue,
            Dictionary<string, object> i_UniqInputsToObjectValue, Vehicle i_NewVehicle,
            string i_OwnerName, string i_OwnerPhoneNumber)
        {
            VehicleInfoInGarage newVehicleInfoInGarage = new VehicleInfoInGarage();

            newVehicleInfoInGarage.OwnerName = i_OwnerName;
            newVehicleInfoInGarage.OwnerPhoneNumber = i_OwnerPhoneNumber;
            i_NewVehicle.SetCommonInputInfoForNewVehicle(i_CommonInputsToObjectValue);
            i_NewVehicle.SetUniqInputInfoForNewVehicle(i_UniqInputsToObjectValue);
            newVehicleInfoInGarage.Vehicle = i_NewVehicle;
            this.m_LicenseToVehicleInGarage[i_NewVehicle.LicenseNumber] = newVehicleInfoInGarage;
        }
        public StringBuilder GetOptionsListVehicleStateInGarage(out int o_MaxRange)
        {
            StringBuilder output = new StringBuilder();
            int countOptions = 1;

            foreach (eVehicleStateInGarage type in Enum.GetValues(typeof(eVehicleStateInGarage)))
            {
                output.AppendLine($"{countOptions} - {type.ToString()}");
                countOptions++;
            }

            o_MaxRange = countOptions - 1;

            return output;
        }
        public string GetOptionsListFuelTypeInVehicle(out int o_MaxRange)
        {
            StringBuilder output = new StringBuilder();
            int countOptions = 1, totalTypes;
            
            totalTypes = Enum.GetValues(typeof(eFuelType)).Length;
            foreach (eFuelType type in Enum.GetValues(typeof(eFuelType)))
            {
                output.Append($"{countOptions} - {type.ToString()}");
                if (countOptions < totalTypes)
                {
                    output.AppendLine();
                }

                countOptions++;
            }

            o_MaxRange = countOptions - 1;

            return output.ToString();
        }
        public void IsVehicleFuelEnergy(string i_LicenseNumber)
        {
            if(!(this.m_LicenseToVehicleInGarage[i_LicenseNumber].Vehicle.EnergyVehicle is FuelEnergy))
            {
                throw new ArgumentException("Vehicle is not driven by fuel");
            }
        }
        public void IsVehicleElectricEnergy(string i_LicenseNumber)
        {
            if (!(this.m_LicenseToVehicleInGarage[i_LicenseNumber].Vehicle.EnergyVehicle is ElectricEnergy))
            {
                throw new ArgumentException("Vehicle is not driven by electricity");
            }
        }
        public void IsVehicleEnergyFuelTypeIsMatch(int i_FuelType, string i_LicenseNumber)
        {
            if (this.m_LicenseToVehicleInGarage[i_LicenseNumber].Vehicle.FuelType != (eFuelType)i_FuelType)
            {
                throw new ArgumentException("This type of fuel cannot be filled in this vehicle");
            }
        }
        public void AddEnergyToVehicle(float i_AmountFuelToAdd, string i_LicenseNumber)
        {
            this.m_LicenseToVehicleInGarage[i_LicenseNumber].Vehicle.EnergyVehicle.AddEnergy(i_AmountFuelToAdd);
        }
        public List<string> GetLicenseNumbersInGarageAccordingToFilter(int i_FilterChoice)
        {
            List<string> licenseNumbersByFilter = new List<string>();

            if (Enum.IsDefined(typeof(eVehicleStateInGarage), i_FilterChoice))
            {
                foreach (KeyValuePair<string, VehicleInfoInGarage> entry in this.m_LicenseToVehicleInGarage)
                {
                    if (entry.Value.VehicleStateInGarage == (eVehicleStateInGarage)i_FilterChoice)
                    {
                        licenseNumbersByFilter.Add(entry.Key);
                    }
                }
            }
            else
            {
                foreach (KeyValuePair<string, VehicleInfoInGarage> entry in this.m_LicenseToVehicleInGarage)
                {
                    licenseNumbersByFilter.Add(entry.Key);
                }
            }

            return licenseNumbersByFilter;
        }
        public void ChangeVehicleStateInGarage(string i_LicenseNumber,int i_NewVehicleState)
        {
            this.m_LicenseToVehicleInGarage[i_LicenseNumber]
                    .VehicleStateInGarage = (eVehicleStateInGarage)i_NewVehicleState;
        }
        public void ChangeWheelAirPressureToMaximum(string i_LicenseNumber)
        {
            this.m_LicenseToVehicleInGarage[i_LicenseNumber]
                   .Vehicle.ChangeWheelsListAirPressureToMaximum();
        }
        public string GetFullInfoOfVehicleInGarage(string i_LicenseNumber)
        {
            return this.m_LicenseToVehicleInGarage[i_LicenseNumber].ToString();      
        }
        internal static bool IsAllDigits(string i_Value)
        {
            bool isAllDigits = true;

            foreach (char c in i_Value)
            {
                if (!char.IsDigit(c))
                {
                    isAllDigits = false;
                }
            }

            return isAllDigits;
        }
        internal static bool IsAllLetters(string i_Value)
        {
            bool isAllLetters = true;

            foreach (char c in i_Value)
            {
                if (!char.IsLetter(c))
                {
                    isAllLetters = false;
                }
            }

            return isAllLetters;
        }
    }
}
