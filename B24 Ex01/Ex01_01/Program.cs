using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01_01
{
    class Program
    {
        public static void Main()
        {
            int numberFromUser1, numberFromUser2, numberFromUser3;
            int decimalNumber1, decimalNumber2, decimalNumber3;

            getAndCheckNumbersInputFromUser(out numberFromUser1, out numberFromUser2, out numberFromUser3);
            parseNumbersToDecimal(numberFromUser1, numberFromUser2, numberFromUser3,
                out decimalNumber1, out decimalNumber2, out decimalNumber3);
            printAscendingOrderDecimalNumbers(decimalNumber1, decimalNumber2, decimalNumber3);
            printStatistics(numberFromUser1, numberFromUser2, numberFromUser3,
                decimalNumber1, decimalNumber2, decimalNumber3);
        }
        private static void printAscendingOrderDecimalNumbers(int i_DecimalNumber1, int i_DecimalNumber2
                                                              ,int i_DecimalNumber3)
        {
            int minDecimalNumber = Math.Min(Math.Min(i_DecimalNumber1, i_DecimalNumber2), i_DecimalNumber3);
            int maxDecimalNumber = Math.Max(Math.Max(i_DecimalNumber1, i_DecimalNumber2), i_DecimalNumber3);
            int midDecimalNumber = i_DecimalNumber1 + i_DecimalNumber2 + i_DecimalNumber3
                                   - minDecimalNumber - maxDecimalNumber;

            Console.WriteLine("The decimal numbers in descending order are: {0}, {1}, {2}",
                                minDecimalNumber, midDecimalNumber, maxDecimalNumber);
        }
        private static void getAndCheckNumbersInputFromUser(out int o_NumberFromUser1, out int o_NumberFromUser2,
                                                            out int o_NumberFromUser3)
        {
            string numberFromUserStr;

            numberFromUserStr = getNumberStrOfNineDigitsFromUser(); 
            checkUntilNumberIsValid(numberFromUserStr, out o_NumberFromUser1);
            numberFromUserStr = getNumberStrOfNineDigitsFromUser();
            checkUntilNumberIsValid(numberFromUserStr, out o_NumberFromUser2);
            numberFromUserStr = getNumberStrOfNineDigitsFromUser();
            checkUntilNumberIsValid(numberFromUserStr, out o_NumberFromUser3);
        }
        private static string getNumberStrOfNineDigitsFromUser()
        {
            string numberFromUserStr;

            System.Console.WriteLine("Please enter your 9 digit positive binary number and then press enter:");
            numberFromUserStr = System.Console.ReadLine();

            return numberFromUserStr;
        }
        private static bool isNumberContainNineBinaryDigit(string i_NumberFromUserStr)
        {
            bool isBinaryNumber = true;
            bool isNumberContainNineDigit = i_NumberFromUserStr.Length == 9;

            if(isNumberContainNineDigit)
            {
                for (int i = 0; i < i_NumberFromUserStr.Length && isBinaryNumber; i++)
                {
                    if (i_NumberFromUserStr[i] != '0' && i_NumberFromUserStr[i] != '1')
                    {
                        isBinaryNumber = false;
                    }
                }
            }

            return isNumberContainNineDigit && isBinaryNumber;
        }
        private static void checkUntilNumberIsValid(string i_NumberFromUserStr, out int o_NumberFromUser)
        {
            bool isNumberValid = isNumberContainNineBinaryDigit(i_NumberFromUserStr);

            while (!isNumberValid)
            {
                Console.WriteLine("invalid input ,try again!");
                i_NumberFromUserStr = getNumberStrOfNineDigitsFromUser();
                isNumberValid = isNumberContainNineBinaryDigit(i_NumberFromUserStr);
            }

            o_NumberFromUser = int.Parse(i_NumberFromUserStr);
        }
        private static int parseFromBinaryNumberToDecimalNumber(int i_NumberFromUser)
        {
            int decimalNumber = 0; 

            for (int i = 0; i < 9; i++)
            {
                decimalNumber += (i_NumberFromUser % 10) * (int)Math.Pow(2, i); 
                i_NumberFromUser /= 10;
            }

            return decimalNumber;
        }
        private static void parseNumbersToDecimal(int i_BinaryNumber1, int i_BinaryNumber2
                                                  , int i_BinaryNumber3, out int o_DecimalNumber1
                                                  , out int o_DecimalNumber2, out int o_DecimalNumber3)
        {
            o_DecimalNumber1 = parseFromBinaryNumberToDecimalNumber(i_BinaryNumber1);
            o_DecimalNumber2 = parseFromBinaryNumberToDecimalNumber(i_BinaryNumber2);
            o_DecimalNumber3 = parseFromBinaryNumberToDecimalNumber(i_BinaryNumber3);
        }
        private static void printStatistics(int i_BinaryNumber1, int i_BinaryNumber2
                                            , int i_BinaryNumber3, int i_DecimalNumber1
                                            , int i_DecimalNumber2, int i_DecimalNumber3)

        {
            avgOfZeroAndOneDigitsInInput(i_BinaryNumber1, i_BinaryNumber2, i_BinaryNumber3);
            countNumbersThatArePowerOfTwo(i_DecimalNumber1, i_DecimalNumber2, i_DecimalNumber3);
            countNumbersThatAreAscendingSeries(i_DecimalNumber1, i_DecimalNumber2, i_DecimalNumber3);
            printMinMaxNumbers(i_DecimalNumber1, i_DecimalNumber2, i_DecimalNumber3);
        }
        private static void countNumbersThatArePowerOfTwo(int i_DecimalNumber1, int i_DecimalNumber2
                                                          , int i_DecimalNumber3)
        {
            int countNumbersPowTwo = 0;

            countNumbersPowTwo += isPowerOfTwo(i_DecimalNumber1) ? 1 : 0;
            countNumbersPowTwo += isPowerOfTwo(i_DecimalNumber2) ? 1 : 0;
            countNumbersPowTwo += isPowerOfTwo(i_DecimalNumber3) ? 1 : 0;
            Console.WriteLine("The amount of numbers that are power of 2: {0}", countNumbersPowTwo);
        }
        private static bool isPowerOfTwo(int i_DecimalNumber)
        {
            return (i_DecimalNumber > 0) && ((i_DecimalNumber & (i_DecimalNumber - 1)) == 0);
        }
        private static void avgOfZeroAndOneDigitsInInput(int i_BinaryNumber1, int i_BinaryNumber2
                                                         , int i_BinaryNumber3)
        {
            int countTotalZero, countTotalOne = 0;
            double avgZeroDigit, avgOneDigit;

            countTotalOne += countOneInBinaryNumber(i_BinaryNumber1);
            countTotalOne += countOneInBinaryNumber(i_BinaryNumber2);
            countTotalOne += countOneInBinaryNumber(i_BinaryNumber3);
            countTotalZero = 27 - countTotalOne;
            avgZeroDigit = (double)countTotalZero / 3;
            avgOneDigit = (double)countTotalOne / 3;
            Console.WriteLine("The avarage of zero digit in numbers is: {0}", avgZeroDigit);
            Console.WriteLine("The avarage of one digit in numbers is: {0}", avgOneDigit);
        }
        private static int countOneInBinaryNumber(int i_BinaryNumber)
        {
            string binaryNumberStr = i_BinaryNumber.ToString();
            int countOne = 0;

            for(int i = 0; i < binaryNumberStr.Length; i++)
            {
                if(binaryNumberStr[i] == '1')
                {
                    countOne++;
                }
            }

            return countOne;
        }
        private static void countNumbersThatAreAscendingSeries(int i_DecimalNumber1, int i_DecimalNumber2
                                                               , int i_DecimalNumber3)
        {
            int countNumbersAscendingSeries = 0;

            countNumbersAscendingSeries += checkIfNumberIsAscendingSeries(i_DecimalNumber1) ? 1 : 0;
            countNumbersAscendingSeries += checkIfNumberIsAscendingSeries(i_DecimalNumber2) ? 1 : 0;
            countNumbersAscendingSeries += checkIfNumberIsAscendingSeries(i_DecimalNumber3) ? 1 : 0;
            Console.WriteLine("The amount of numbers that are ascending series: {0}", countNumbersAscendingSeries);
        }
        private static bool checkIfNumberIsAscendingSeries(int i_DecimalNumber)
        {
            int rightDigit;
            bool isAscending = true;
            int prevRightDigit = i_DecimalNumber % 10;

            i_DecimalNumber /= 10;
            while (i_DecimalNumber > 0 && isAscending)
            {
                rightDigit = i_DecimalNumber % 10;
                if (rightDigit >= prevRightDigit)
                {
                    isAscending = false;
                }

                i_DecimalNumber /= 10;
                prevRightDigit = rightDigit;
            }

            return isAscending;
        }
        private static void printMinMaxNumbers(int i_DecimalNumber1, int i_DecimalNumber2
                                               , int i_DecimalNumber3)
        {
            int minDecimalNumber, maxDecimalNumber;

            minDecimalNumber = Math.Min(Math.Min(i_DecimalNumber1, i_DecimalNumber2), i_DecimalNumber3);
            maxDecimalNumber = Math.Max(Math.Max(i_DecimalNumber1, i_DecimalNumber2), i_DecimalNumber3);
            Console.WriteLine("The minimal number is: {0}\nThe maximal number is: {1} ",
                                minDecimalNumber, maxDecimalNumber);
        }
    }
}
