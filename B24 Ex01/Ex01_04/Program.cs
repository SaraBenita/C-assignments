using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01_04
{
    public class Program
    {
        public static void Main()
        {
            string typeOfString, stringFromUser;

            stringFromUser = getStringOfTenCharsFromUser();
            stringFromUser = checkUntilStringIsValid(stringFromUser,out typeOfString);
            printIfPalindrom(stringFromUser);
            printAccordingToType(stringFromUser, typeOfString);
        }
        private static string getStringOfTenCharsFromUser()
        {
            string stringFromUserStr; 

            Console.WriteLine("Please enter your 10-char and then press enter:");
            stringFromUserStr = Console.ReadLine();

            return stringFromUserStr;
        }
        private static string checkUntilStringIsValid(string i_StringFromUserStr, out string o_TypeOfString)
        {
            bool isStringValid = isStringContainOneKindOfTenChars(i_StringFromUserStr, out o_TypeOfString);

            while (!isStringValid)
            {
                Console.WriteLine("invalid input ,try again!");
                i_StringFromUserStr = getStringOfTenCharsFromUser();
                isStringValid = isStringContainOneKindOfTenChars(i_StringFromUserStr, out o_TypeOfString);
            }

            return i_StringFromUserStr;
        }
        private static bool isStringContainOneKindOfTenChars(string i_StringFromUserStr, out string o_TypeOfString)
        {
            bool isOnlyLetters, isValid;
            bool isStringContainTenChars = i_StringFromUserStr.Length == 10;
            bool isOnlyDigits = IsStringContainOnlyDigits(i_StringFromUserStr);

            o_TypeOfString = "";
            if (isOnlyDigits)
            {
                o_TypeOfString = "Digit";
            }

            isOnlyLetters = isStringContainOnlyLetters(i_StringFromUserStr);
            if (isOnlyLetters)
            {
                o_TypeOfString = "Letter";
            }

            isValid = isStringContainTenChars && ( isOnlyDigits || isOnlyLetters);

            return isValid;
        }
        public static bool IsStringContainOnlyDigits(string i_StringFromUserStr)
        {
            bool isAllDigits = true;

            foreach (char c in i_StringFromUserStr)
            {
                if (!char.IsDigit(c))
                {
                    isAllDigits = false;
                    break;
                }
            }

            return isAllDigits;
        }
        private static void isStringPalindrom(string i_StringFromUserStr, int i_Left, int i_Right
                                                , out bool o_IsPalindrom)
        {
            if(i_Left >= i_Right)
            {
                o_IsPalindrom = true;
            }
            else
            {
                if (i_StringFromUserStr[i_Left] != i_StringFromUserStr[i_Right])
                {
                    o_IsPalindrom = false;
                }
                else
                {
                    isStringPalindrom(i_StringFromUserStr, i_Left + 1, i_Right - 1,out o_IsPalindrom);
                }
            }
        }
        private static void printIfPalindrom(string i_StringFromUserStr)
        {
            bool isPalindrom;

            isStringPalindrom(i_StringFromUserStr, 0, i_StringFromUserStr.Length - 1, out isPalindrom);
            if (isPalindrom)
            {
                Console.WriteLine("The string is palindrom");
            }
            else
            {
                Console.WriteLine("The string is not palindrom");
            }
        }
        private static bool isStringContainOnlyLetters(string i_StringFromUserStr)
        {
            bool isAllLetters = true;

            foreach (char c in i_StringFromUserStr)
            {
                if (!char.IsLetter(c))
                {
                    isAllLetters = false;
                    break;
                }
            }

            return isAllLetters;
        }
        private static bool isDevidedByFour(string i_StringFromUserStr)
        {
            long numberFromUser = long.Parse(i_StringFromUserStr);
            bool isDevidedByFour = numberFromUser % 4 == 0;

            return isDevidedByFour;
        }
        private static int countNumberLowerCaseInString(string i_StringFromUserStr)
        {
            int countLowerCase = 0;

            foreach (char c in i_StringFromUserStr)
            {
                if (char.IsLower(c))
                {
                    countLowerCase++;
                }
            }

            return countLowerCase;
        }
        private static void printAccordingToType(string i_StringFromUserStr, string i_TypeOfString)
        {
            bool isDevided;
            int countLowerCaseLetters;

            if (i_TypeOfString == "Letter")
            {
                countLowerCaseLetters = countNumberLowerCaseInString(i_StringFromUserStr);
                Console.WriteLine("The amount of lower case letters in string: {0}", countLowerCaseLetters);
            }
            else
            {
                isDevided = isDevidedByFour(i_StringFromUserStr);
                if(isDevided)
                {
                    Console.WriteLine("The number is devided by 4");
                }
                else
                {
                    Console.WriteLine("The number is not devided by 4");
                }
            }
        }
    }
}
