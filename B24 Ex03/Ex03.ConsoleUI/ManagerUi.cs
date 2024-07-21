using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.ConsoleUI
{
    internal class ManagerUi
    {
        private ConsoleUi m_ConsoleUi;
        private ManagerGarageLogic m_ManagerGarageLogic;
        public ManagerUi()
        {
            this.m_ConsoleUi = new ConsoleUi();
            this.m_ManagerGarageLogic = new ManagerGarageLogic();
        }
        public void StartGarage()
        {
            this.m_ConsoleUi.PrintOpeningGarageLine();
            handleUserChoiceOption();
        }
        private void handleUserChoiceOption()
        {
            int userChoiceFromMenu;

            while (true)
            {
                try
                {
                    userChoiceFromMenu = this.m_ConsoleUi.GetUserChoiceForMenuOption();
                    switch ((eMenuOptions)userChoiceFromMenu)
                    {
                        case eMenuOptions.EnterVehicleToGarage:
                            enterVehicleToGarageOption();
                            break;
                        case eMenuOptions.PresentVehicleLicenseNumbers:
                            presentVehicleLisenceNumberInGarageByFilter();
                            break;
                        case eMenuOptions.UpdateVehicleState:
                            changeVehicleStateInGarage();
                            break;
                        case eMenuOptions.AddWheelAirToMax:
                            changeWheelAirPressureToMaximum();
                            break;
                        case eMenuOptions.RefuelVehicle:
                            refuelFuelVehicle();
                            break;
                        case eMenuOptions.ChargeButteryVehicle:
                            chargeButteryVehicle();
                            break;
                        case eMenuOptions.PresentInfoVehicle:
                            getFullInfoOfVehicleInGarage();
                            break;
                    }
                }
                catch (Exception exception)
                {
                    this.m_ConsoleUi.PrintMsg(exception.Message);                   
                }
            } 
        }
        private void enterVehicleToGarageOption()
        {
            string licenseNumberStr, ownerName, ownerPhone;
            int garageVehicleType;
            bool islicenseNumberExistInGarage;
            Dictionary<string, object> commonInputsToObjectValue, uniqInputsToObjectValue;
            List<string> vehiclesTypeInSystem;
            Vehicle newVehicle;

            licenseNumberStr = this.m_ConsoleUi.
                GetDataInputNumberStrFromUser("Enter the vehicle license Number: ");
            islicenseNumberExistInGarage = this.m_ManagerGarageLogic
                .CheckIfNewVehicleLicenseInGarageAndChangeState(licenseNumberStr);
            if (islicenseNumberExistInGarage)
            {
                this.m_ConsoleUi.PrintMsg("Vehicle already in garage - update vehicle status to repair");
            }
            else
            {
                vehiclesTypeInSystem = this.m_ManagerGarageLogic.GetListOfVehiclesInSystem();
                garageVehicleType = this.m_ConsoleUi.GetDataInputNumberIntFromUser(
                    getStrVehicleTypesInGarage(vehiclesTypeInSystem), true, vehiclesTypeInSystem.Count);
                newVehicle = this.m_ManagerGarageLogic.
                    CreateNewVehicle(garageVehicleType, licenseNumberStr);
                initCommonInfoOfNewVehicleFromUser(out ownerName,out ownerPhone,
                    out commonInputsToObjectValue, newVehicle);
                initUniqInfoOfNewVehicleFromUser(newVehicle, out uniqInputsToObjectValue);
                this.m_ManagerGarageLogic.SetAndAddVehicleInfoToGarage(commonInputsToObjectValue,
                    uniqInputsToObjectValue, newVehicle, ownerName, ownerPhone);
                this.m_ConsoleUi.PrintMsg("Vehicle added successfully");
            }
        }
        private void initCommonInfoOfNewVehicleFromUser(out string o_OwnerName, out string o_OwnerPhone,
             out Dictionary<string, object> o_CommonInputsToObjectValue, Vehicle i_NewVehicle)
        {
            Dictionary<string, InputDataDefinition> commonInputsToDescription;

            o_OwnerName = this.m_ConsoleUi.GetDataInputStringFromUser("Enter vehicle owner name: ");
            o_OwnerPhone = this.m_ConsoleUi.GetDataInputNumberStrFromUser("Enter vehicle owner phone: ");
            commonInputsToDescription = i_NewVehicle.SendDescriptionInputsOfCommonInfoForNewVehicle();
            o_CommonInputsToObjectValue = initDictInputsForVehicle(commonInputsToDescription);
        }
        private void initUniqInfoOfNewVehicleFromUser(Vehicle i_NewVehicle ,
            out Dictionary<string, object> o_CommonInputsToObjectValue)
        {
            Dictionary<string, InputDataDefinition> commonInputsToDescription;

            commonInputsToDescription = i_NewVehicle.SendDescriptionInputsOfUniqInfoForNewVehicle();
            o_CommonInputsToObjectValue = initDictInputsForVehicle(commonInputsToDescription);
        }
        private Dictionary<string, object> initDictInputsForVehicle(
            Dictionary<string,InputDataDefinition> i_DictInputsDescription)
        {
            Dictionary<string, object> inputsToObjectValue = new Dictionary<string, object>();

            foreach (KeyValuePair<string, InputDataDefinition> entry in i_DictInputsDescription)
            {
                if (entry.Value.InputType == typeof(string))
                {
                    inputsToObjectValue[entry.Key] = this.m_ConsoleUi
                        .GetDataInputStringFromUser(entry.Value.MsgForUser);
                }
                else if (entry.Value.InputType == typeof(float))
                {
                    inputsToObjectValue[entry.Key] = this.m_ConsoleUi
                        .GetDataInputNumberFloatFromUser(entry.Value.MsgForUser);
                }
                else if (entry.Value.InputType == typeof(int))
                {
                    inputsToObjectValue[entry.Key] = this.m_ConsoleUi
                        .GetDataInputNumberIntFromUser(entry.Value.MsgForUser,
                        entry.Value.IsInputSelectedFromList,entry.Value.MaxRange);
                }
                else if(entry.Value.InputType == typeof(bool))
                {
                    inputsToObjectValue[entry.Key] = this.m_ConsoleUi
                        .GetDataInputBoolFromUser(entry.Value.MsgForUser); 
                }
            }

            return inputsToObjectValue;
        }
        private void presentVehicleLisenceNumberInGarageByFilter()
        {
            int maxRange, vehicleStatesUserChoice;
            StringBuilder vehicleStatesInGarage;
            List<string> licenseNumberByFilter;

            vehicleStatesInGarage = this.m_ManagerGarageLogic.
                GetOptionsListVehicleStateInGarage(out maxRange);
            vehicleStatesInGarage.AppendLine($"{maxRange + 1} - {"All Vehicles"}");
            vehicleStatesInGarage.Append("Enter vehicle state in garage that you want to filter: ");
            maxRange += 1;
            vehicleStatesUserChoice = this.m_ConsoleUi
             .GetDataInputNumberIntFromUser(vehicleStatesInGarage.ToString(),true, maxRange);
            licenseNumberByFilter = this.m_ManagerGarageLogic.
                GetLicenseNumbersInGarageAccordingToFilter(vehicleStatesUserChoice);
            this.m_ConsoleUi.PrintLicenseNumberByFilter(licenseNumberByFilter);
        }
        private void changeVehicleStateInGarage()
        {
            string licenseNumberStr;
            StringBuilder vehicleStatesInGarage;
            int maxRange, vehicleStatesUserChoice;

            licenseNumberStr = this.m_ConsoleUi.
                GetDataInputNumberStrFromUser("Enter the vehicle license Number: ");
            this.m_ManagerGarageLogic.CheckIfVehicleLicenseInGarage(licenseNumberStr); // will throw if not exist
            vehicleStatesInGarage = this.m_ManagerGarageLogic.
                GetOptionsListVehicleStateInGarage(out maxRange);
            vehicleStatesInGarage.Append("Enter the new vehicle state: ");
            vehicleStatesUserChoice = this.m_ConsoleUi
             .GetDataInputNumberIntFromUser(vehicleStatesInGarage.ToString(), true, maxRange);
            this.m_ManagerGarageLogic.
                ChangeVehicleStateInGarage(licenseNumberStr, vehicleStatesUserChoice);
            this.m_ConsoleUi.PrintMsg("Vehicle state in garage change successfully");
        }
        private void changeWheelAirPressureToMaximum()
        {
            string licenseNumberStr;

            licenseNumberStr = this.m_ConsoleUi.
             GetDataInputNumberStrFromUser("Enter the vehicle license Number: ");
            this.m_ManagerGarageLogic.CheckIfVehicleLicenseInGarage(licenseNumberStr);// will throw if not exist
            this.m_ManagerGarageLogic.ChangeWheelAirPressureToMaximum(licenseNumberStr);
            this.m_ConsoleUi.PrintMsg("Vehicle wheels air pressure change successfully");
        }
        private void refuelFuelVehicle()
        {
            string licenseNumberStr, listFuelType;
            int maxRange, fuelTypeUserChoice;
            float amountFuelToAdd;

            licenseNumberStr = this.m_ConsoleUi.
             GetDataInputNumberStrFromUser("Enter the vehicle license Number: ");
            this.m_ManagerGarageLogic.CheckIfVehicleLicenseInGarage(licenseNumberStr);  // will throw if not exist
            this.m_ManagerGarageLogic.IsVehicleFuelEnergy(licenseNumberStr); // will throw if not fuel
            listFuelType = this.m_ManagerGarageLogic.GetOptionsListFuelTypeInVehicle(out maxRange);
            fuelTypeUserChoice = this.m_ConsoleUi
                .GetDataInputNumberIntFromUser(listFuelType, true, maxRange);
            this.m_ManagerGarageLogic.IsVehicleEnergyFuelTypeIsMatch(fuelTypeUserChoice // will throw if not Match
                , licenseNumberStr);
            amountFuelToAdd = this.m_ConsoleUi.
                GetDataInputNumberFloatFromUser("Enter amount fuel you want to add: ");
            this.m_ManagerGarageLogic.AddEnergyToVehicle(amountFuelToAdd, licenseNumberStr);
            this.m_ConsoleUi.PrintMsg("Fuel added successfully");
        }
        private void chargeButteryVehicle()
        {
            string licenseNumberStr;
            float numberButteryToAdd;

            licenseNumberStr = this.m_ConsoleUi.
              GetDataInputNumberStrFromUser("Enter the vehicle license Number: ");
            this.m_ManagerGarageLogic.CheckIfVehicleLicenseInGarage(licenseNumberStr);  // will throw if not exist
            this.m_ManagerGarageLogic.IsVehicleElectricEnergy(licenseNumberStr); // will throw if not electric
            numberButteryToAdd = this.m_ConsoleUi.
                GetDataInputNumberFloatFromUser("Enter number of minutes to charge: ");
            this.m_ManagerGarageLogic.AddEnergyToVehicle(numberButteryToAdd, licenseNumberStr);
            this.m_ConsoleUi.PrintMsg("Battery charged successfully");
        }
        private void getFullInfoOfVehicleInGarage()
        {
            string licenseNumberStr, fullInfoVehicle;

            licenseNumberStr = this.m_ConsoleUi.
             GetDataInputNumberStrFromUser("Enter the vehicle license Number: ");
            this.m_ManagerGarageLogic.CheckIfVehicleLicenseInGarage(licenseNumberStr);  // will throw if not exist
            fullInfoVehicle =  this.m_ManagerGarageLogic.GetFullInfoOfVehicleInGarage(licenseNumberStr);
            this.m_ConsoleUi.PrintMsg(fullInfoVehicle);
        }
        private string getStrVehicleTypesInGarage(List<string> i_ListVehicleType)
        {
            int countOptions = 1;
            StringBuilder output = new StringBuilder();

            foreach (string vehicleType in i_ListVehicleType)
            {
                output.AppendLine(string.Format("{0} - {1}", countOptions, vehicleType));
                countOptions++;
            }

            output.Append("Please enter the number of vehicle type: ");

            return output.ToString();
        }

    }
}
