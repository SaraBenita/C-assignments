using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01_03
{
    class Program
    {
        public static void Main()
        {
            dimondsForAdvanced();
        }
        private static void dimondsForAdvanced()
        {
            int numberRow = 1, numberFromUser;
            string numberFromUserStr;

            numberFromUserStr = getHeigthOfDimondsFromUser();
            numberFromUser = checkUntilNumberIsValid(numberFromUserStr);
            checkIfEvenAndReturnOdd(ref numberFromUser);
            Ex01_02.Program.DimondsForBeginners(numberFromUser, numberRow);
        }
        private static void checkIfEvenAndReturnOdd(ref int io_NumberFromUser)
        {
            bool isEven = io_NumberFromUser % 2 == 0;

            if (isEven)
            {
                io_NumberFromUser = io_NumberFromUser + 1;
            }
        }
        private static string getHeigthOfDimondsFromUser()
        {
            string numberFromUserStr;

            Console.Write("Please enter heigth Of dimonds and then press enter: ");
            numberFromUserStr = Console.ReadLine();

            return numberFromUserStr;
        }
        private static int checkUntilNumberIsValid(string i_NumberFromUserStr)
        {
            int numberFromUser;
            bool isNumberValid = int.TryParse(i_NumberFromUserStr, out numberFromUser);

            while (!isNumberValid)
            {
                Console.WriteLine("invalid input ,try again!");
                i_NumberFromUserStr = getHeigthOfDimondsFromUser();
                isNumberValid = int.TryParse(i_NumberFromUserStr, out numberFromUser);
            }

            return numberFromUser;
        }
    }
}
