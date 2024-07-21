using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01_05
{
    class Program
    {
        public static void Main()
        {
            string numberFromUserStr;

            numberFromUserStr = getStringOfEightCharsFromUser();
            numberFromUserStr = checkUntilNumberIsValid(numberFromUserStr);
            getStatisticsOfNumber(numberFromUserStr, numberFromUserStr.Length);
        }
        private static string getStringOfEightCharsFromUser()
        {
            string stringFromUserStr;

            Console.WriteLine("Please enter your 8-digit number and then press enter:");
            stringFromUserStr = Console.ReadLine();

            return stringFromUserStr;
        }
        private static string checkUntilNumberIsValid(string i_NumberFromUserStr)
        {
            bool isNumberValid = isInputPositiveAndWholeNumberWithEightDigits(i_NumberFromUserStr);
            
            while (!isNumberValid)
            {
                Console.WriteLine("invalid input ,try again!");
                i_NumberFromUserStr = getStringOfEightCharsFromUser();
                isNumberValid = isInputPositiveAndWholeNumberWithEightDigits(i_NumberFromUserStr);
            }

            return i_NumberFromUserStr;
        }
        private static bool isInputPositiveAndWholeNumberWithEightDigits(string i_StringFromUserStr)
        {
            int numberFromUser;

            bool isStringContainEightDigits = i_StringFromUserStr.Length == 8;
            bool isOnlyDigits = Ex01_04.Program.IsStringContainOnlyDigits(i_StringFromUserStr);
            bool isNumberPositiveAndWhole = int.TryParse(i_StringFromUserStr, out numberFromUser)
                                                         && numberFromUser > 0;

            return isStringContainEightDigits && isOnlyDigits && isNumberPositiveAndWhole;
        }
        private static void getStatisticsOfNumber(string i_NumberFromUserStr, int i_LengthNumber)
        {
            int currentDigit, countDigitsSmaller = 0, maxDigit = 0, countDigitsDevidedByThree = 0;
            double avgOfDigits, sumDigits = 0.0;
            int unit = int.Parse(i_NumberFromUserStr[i_LengthNumber - 1].ToString());

            foreach (char currentChar in i_NumberFromUserStr)
            {
                currentDigit = int.Parse(currentChar.ToString());
                sumDigits += currentDigit;
                if (currentDigit < unit)
                {
                    countDigitsSmaller++;
                }

                if (currentDigit % 3 == 0)
                {
                    countDigitsDevidedByThree++;
                }

                if (currentDigit > maxDigit)
                {
                    maxDigit = currentDigit;
                }
            }  

            avgOfDigits = sumDigits / i_LengthNumber;

            Console.WriteLine(string.Format(@"The number of digits smaller then the unity number:{0}
Digits divided by 3: {1}
Largest digit: {2}
Average of the digits:{3}",
countDigitsSmaller,
countDigitsDevidedByThree,
maxDigit,
Math.Round(avgOfDigits, 3)));    
        }
    }
}
