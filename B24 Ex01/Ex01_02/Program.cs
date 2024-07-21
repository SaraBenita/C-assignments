using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01_02
{
    public class Program
    {
        public static void Main()
        {
            int maxNumberOfStars = 9;
            int rowNumber = 1;

            DimondsForBeginners(maxNumberOfStars, rowNumber);
        }
        public static void DimondsForBeginners(int i_MaxNumberOfStars, int i_RowNumber)
        {
            StringBuilder diamondBuilder = new StringBuilder();

            if (i_MaxNumberOfStars < (i_RowNumber * 2) - 1)
            {
                return;
            }
            else
            {
                diamondBuilder.Append(buildRowOfDiamonds(i_MaxNumberOfStars, i_RowNumber));
                diamondBuilder.AppendLine();
                Console.Write(diamondBuilder.ToString());
                DimondsForBeginners(i_MaxNumberOfStars, i_RowNumber + 1);
                if (i_MaxNumberOfStars != (i_RowNumber * 2) - 1)
                {
                    diamondBuilder.Clear();
                    diamondBuilder.Append(buildRowOfDiamonds(i_MaxNumberOfStars, i_RowNumber));
                    diamondBuilder.AppendLine();
                    Console.Write(diamondBuilder.ToString());
                }
            }
        }
        private static string buildRowOfDiamonds(int i_MaxNumberOfStars, int i_RowNumber)
        {
            StringBuilder rowBuilder = new StringBuilder();
            int numberOfSpaces = (i_MaxNumberOfStars / 2) + 1 - i_RowNumber;
            int numberOfStars = 2 * i_RowNumber - 1;

            for (int j = 1; j <= numberOfSpaces; j++)
            {
                rowBuilder.Append(" ");
            }

            for (int j = 1; j <= numberOfStars; j++)
            {
                rowBuilder.Append("*");
            }

            return rowBuilder.ToString();
        }
    }
}

