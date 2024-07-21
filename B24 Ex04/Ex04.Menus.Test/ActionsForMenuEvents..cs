using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Test
{
    internal class ActionsForMenuEvents
    {
        internal static void ShowVersion()
        {
            Console.WriteLine("App Version: 24.2.4.9504");
        }
        internal static void CountCapitals()
        {
            string userSentence;
            int countUpperLetters = 0;

            Console.WriteLine("Enter a sentence: ");
            userSentence = Console.ReadLine();
            foreach(char character in userSentence)
            {
                if(char.IsUpper(character))
                {
                    countUpperLetters++;
                }
            }

            Console.WriteLine(string.Format(@"There is {0} upper letters in sentence." , countUpperLetters));
        }
        internal static void ShowTime()
        {
            Console.WriteLine(string.Format(@"The current time is: {0} ", DateTime.Now.ToString("HH:mm:ss")));
        }
        internal static void ShowDate()
        {
            Console.WriteLine(string.Format(@"The current date is: {0} ", DateTime.Now.ToShortDateString()));
        }
    }
}
