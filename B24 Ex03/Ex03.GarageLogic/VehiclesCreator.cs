using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class VehiclesCreator
    {
        internal static List<string> GetListOfVehiclesType()
        {
            List<string> vehiclesTypeList = new List<string>();

            foreach (eSystemVehiclesType option in Enum.GetValues(typeof(eSystemVehiclesType)))
            {
                vehiclesTypeList.Add(option.ToString());
            }

            return vehiclesTypeList;
        }
        internal static Vehicle CreateNewVehicleAccordingToType(int i_VehicleType, string i_LicenseNumber)
        {
            Vehicle newVehicle;
            EnergyVehicle newVehicleEnergy;

            switch ((eSystemVehiclesType)i_VehicleType)
            {
                case eSystemVehiclesType.FuelCar:
                    newVehicleEnergy = new FuelEnergy(Car.k_MaxLiterFuel, Car.k_FuelType);
                    newVehicle = new Car(i_LicenseNumber, newVehicleEnergy);
                    break;
                case eSystemVehiclesType.ElectricCar:
                    newVehicleEnergy = new ElectricEnergy(Car.k_MaxButtery);
                    newVehicle = new Car(i_LicenseNumber, newVehicleEnergy);
                    break;
                case eSystemVehiclesType.FuelMotorcycle:
                    newVehicleEnergy = new FuelEnergy(Motorcycle.k_MaxLiterFuel, Motorcycle.k_FuelType);
                    newVehicle = new Motorcycle(i_LicenseNumber, newVehicleEnergy);
                    break;
                case eSystemVehiclesType.ElectricMotorcycle:
                    newVehicleEnergy = new ElectricEnergy(Motorcycle.k_MaxButtery);
                    newVehicle = new Motorcycle(i_LicenseNumber, newVehicleEnergy);
                    break;
                case eSystemVehiclesType.Truck:
                    newVehicleEnergy = new FuelEnergy(Truck.k_MaxLiterFuel, Truck.k_FuelType);
                    newVehicle = new Truck(i_LicenseNumber, newVehicleEnergy);
                    break;
                default:
                    throw new ArgumentException("InValid vehicle type");         
            }

            return newVehicle;
        }
    }
}