using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.ConsoleUI
{
    internal struct ConsoleUi
    {
        private const int k_MaxMenuOption = 7;
        private const int k_Empty = 0;
        internal void PrintOpeningGarageLine()
        {
            Console.WriteLine("Welcome To The Best Garage!!!");
            printBorder();
        }
        internal float GetDataInputNumberFloatFromUser(string i_MsgForUser)
        {
            string dataInputStr;
            float dataInput = 0.0f;
            bool isDataValid = false;

            do
            {
                Console.WriteLine(i_MsgForUser);
                dataInputStr = Console.ReadLine();
                try
                {
                    dataInput = float.Parse(dataInputStr);
                    isDataValid = true;
                    Console.Clear();
                }
                catch (FormatException)
                {
                    Console.WriteLine("Illegal Data Input(enter only digits)");
                }  

                printBorder();
            } while (!isDataValid);

            return dataInput;
        }
        internal int GetDataInputNumberIntFromUser(string i_MsgForUser, bool i_IsInputInRange,
            int i_MaxRange)
        {
            string dataInputStr;
            int dataInput = 0;
            bool isDataValid = false, isDataInRange;

            do
            {
                Console.WriteLine(i_MsgForUser);
                dataInputStr = Console.ReadLine();
                try
                {
                    dataInput = int.Parse(dataInputStr);
                    if (i_IsInputInRange)
                    {
                        isDataInRange = dataInput <= i_MaxRange && dataInput > 0;
                        if (!isDataInRange)
                        {
                            throw new IndexOutOfRangeException();
                        }
                    }

                    isDataValid = true;
                    Console.Clear();
                }
                catch (FormatException)
                {
                    Console.WriteLine("Illegal Data Input(enter only digit)");
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Illegal Data Input(out of range)");
                }

                printBorder();
            } while (!isDataValid);

            return dataInput;
        }
        internal string GetDataInputStringFromUser(string i_MsgForUser)
        {
            string dataInputStr;
            bool isDataInputValid = false, isContainDigit, isDataInputEmpty; 

            do
            {
                Console.WriteLine(i_MsgForUser);
                dataInputStr = Console.ReadLine();
                try
                {
                    isContainDigit = isAllLetters(dataInputStr);
                    if (!isContainDigit)
                    {
                        throw new FormatException();
                    }

                    isDataInputEmpty = dataInputStr.Length == k_Empty;
                    if (isDataInputEmpty)
                    {
                        throw new Exception();
                    }

                    isDataInputValid = true;
                    Console.Clear();
                }
                catch (FormatException)
                {
                    Console.WriteLine("Illegal Data Input(enter only character)");
                }
                catch (Exception)
                {
                    Console.WriteLine("Illegal Data Input(cant be empty)");
                }

                printBorder();
            } while (!isDataInputValid);

            return dataInputStr;
        }
        internal bool GetDataInputBoolFromUser(string i_MsgForUser)
        {
            string dataInputStr;
            bool isDataInputValid = false, dataInput = true,
                isContainDigit, isDataInputEmpty, isYesOrNo;

            do
            {
                Console.WriteLine(i_MsgForUser);
                dataInputStr = Console.ReadLine();
                try
                {
                    isContainDigit = isAllLetters(dataInputStr);
                    if (!isContainDigit)
                    {
                        throw new FormatException();
                    }

                    isDataInputEmpty = dataInputStr.Length == k_Empty;
                    isYesOrNo = dataInputStr.Length == 1 && (dataInputStr.ToUpper() == "Y" ||
                        dataInputStr.ToUpper() == "N");
                    if (isDataInputEmpty || !isYesOrNo)
                    {
                        throw new Exception();
                    }

                    isDataInputValid = true;
                    dataInput = dataInputStr == "N" ? false : true;
                    Console.Clear();
                }
                catch (FormatException)
                {
                    Console.WriteLine("Illegal Data Input(enter only character)");
                }
                catch (Exception)
                {
                    Console.WriteLine("Illegal Data Input");
                }

                printBorder();
            } while (!isDataInputValid);

            return dataInput;
        }
        internal string GetDataInputNumberStrFromUser(string i_MsgForUser)
        {
            string dataInputNumberStr;
            bool isDataValid = false;

            do
            {
                Console.WriteLine(i_MsgForUser);
                dataInputNumberStr = Console.ReadLine();
                try
                {
                    int.Parse(dataInputNumberStr);
                    isDataValid = true;
                    Console.Clear();
                }
                catch (FormatException)
                {
                    Console.WriteLine("Illegal Data Input(enter only digits)");
                }

                printBorder();
            } while (!isDataValid);

            return dataInputNumberStr;
        }
        internal int GetUserChoiceForMenuOption()
        {
            string userChoiceFromMenuStr;
            int userChoiceFromMenu = 0;
            bool isChoiceInRange, isUserChoiceValid = false;

            do
            {
                printMenuOptionsForGarage();
                userChoiceFromMenuStr = Console.ReadLine();
                try
                {
                    userChoiceFromMenu = int.Parse(userChoiceFromMenuStr);
                    isChoiceInRange = userChoiceFromMenu <= k_MaxMenuOption && userChoiceFromMenu > 0;
                    if (!isChoiceInRange)
                    {
                        throw new IndexOutOfRangeException();
                    }

                    isUserChoiceValid = true;
                    Console.Clear();
                }
                catch (FormatException)
                {
                    Console.WriteLine("Illegal Menu Choice(enter only digit)");
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Illegal Menu Choice(out of range)");
                }

                printBorder();
            } while (!isUserChoiceValid);

            return userChoiceFromMenu;
        }
        private void printBorder()
        {
            Console.WriteLine("=========================================");
        }
        private void printMenuOptionsForGarage()
        {
            Console.WriteLine(string.Format(@"1. Add new vehicle to garage
2. Presnt all vehicle license in garage
3. Update state of vehicle that in garage
4. Inflate the tires of a vehicle to the maximum
5. Refuel vehicle
6. Charge electric vehicle
7. Present vehicle information according to license number"));
        }
        internal void PrintMsg(string i_Message)
        {
            Console.WriteLine(i_Message);
            printBorder();
        }
        internal void PrintLicenseNumberByFilter(List<string> i_LicenseNumberByFilter)
        {
            if (i_LicenseNumberByFilter.Count == k_Empty)
            {
                Console.WriteLine("No license number according to filter");
            }
            else
            {
                foreach (string licenseNumber in i_LicenseNumberByFilter)
                {
                    Console.WriteLine(licenseNumber);
                }
            }

            printBorder();
        }
        private bool isAllLetters(string i_Str)
        {
            bool isAllLetters = true;

            foreach (char c in i_Str)
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