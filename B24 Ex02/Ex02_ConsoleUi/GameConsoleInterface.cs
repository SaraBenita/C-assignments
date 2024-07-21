using System;
using System.Text;
using Ex02_System;

namespace Ex02_ConsoleUi
{
    internal struct GameConsoleInterface
    {
        private const int k_MaxUserChoiceLength = 2;
        internal void PrintOpeningStartGame()
        {
            Console.WriteLine(string.Format(@"Welcome to best memory game!!!
=============================="));
        }
        internal string GetPlayerName()
        {
            string playerName;

            Console.WriteLine("Please enter your name: ");
            playerName = Console.ReadLine();
            printBorder();

            return playerName;
        }
        internal void ChooseYourGameType(out eGameType o_TypeOfGame)
        {
            string typeOfGameStr;
            bool isTypeNumber, isInputValid, isTypeInRange = true;
            int gameType;

            do
            {
                Console.WriteLine(string.Format(@"press 1 to play against another player
press 2 to play against computer
Enter type game: "));
                typeOfGameStr = Console.ReadLine();
                isTypeNumber = int.TryParse(typeOfGameStr, out gameType);
                if (!isTypeNumber)
                {
                    Console.WriteLine("InValid type - please enter a number ");
                }
                else
                {
                    isTypeInRange = gameType == (int)eGameType.PlayerVsComputer
                                 || gameType == (int)eGameType.PlayerVsPlayer;
                    if (!isTypeInRange)
                    {
                        Console.WriteLine("InValid type - please enter 1 or 2 ");
                    }
                }

                isInputValid = isTypeNumber && isTypeInRange;
                printBorder();
            } while (!isInputValid);
        
            o_TypeOfGame = (eGameType)gameType;
        }
        internal string GetNameSecondPlayerAccordingToGameType(eGameType i_TypeOfGame)
        {
            string nameSecondPlayer = "Computer";

            if (i_TypeOfGame == eGameType.PlayerVsPlayer)
            {
                nameSecondPlayer = GetPlayerName();
            }
          
            return nameSecondPlayer;
        }
        internal void GetAndCheckIsDimenstionNumber(out int o_Dimenstion, string i_TypeDimenstion)
        {
            string dimenstionStr;
            bool isDimenstionNumber;

            do
            {
                Console.WriteLine(string.Format(@"Please enter the {0} for board size: ", i_TypeDimenstion));
                dimenstionStr = Console.ReadLine();
                isDimenstionNumber = int.TryParse(dimenstionStr, out o_Dimenstion);
                if (!isDimenstionNumber)
                {
                    Console.WriteLine(string.Format(@"Illegal {0} - enter a number ", i_TypeDimenstion));
                    printBorder();
                }
            } while (!isDimenstionNumber);
        }
        internal void PrintExeptionForBoardDimenstionsInLogic()
        {
            Console.WriteLine("Illegal size board - enter even number");
            printBorder();
        }
        internal void PrintExeptionForBoardDimentionsInUi()
        {
            Console.WriteLine("Illegal size board - enter number between 4 to 6");
            printBorder();
        }
        internal void PrintBoard(BoardCell[,] i_BoardValuesMatrix)
        {
            StringBuilder boardStringBuilder = new StringBuilder();
            int rows = i_BoardValuesMatrix.GetLength(0);
            int columns = i_BoardValuesMatrix.GetLength(1);

            boardStringBuilder.Append("   ");
            for (char c = 'A'; c < 'A' + columns; c++)
            {
                boardStringBuilder.AppendFormat(" {0}  ", c);
            }

            boardStringBuilder.AppendLine();
            boardStringBuilder.AppendLine(getBorderLineForBoard(columns));
            for (int i = 0; i < rows; i++)
            {
                boardStringBuilder.AppendFormat("{0} |", i + 1);
                for (int j = 0; j < columns; j++)
                {
                    if (i_BoardValuesMatrix[i, j].IsVisibleCell)
                    {
                        //we chose to map our cell symbol(digit) to his match upper character
                        boardStringBuilder.AppendFormat(" {0} |", (char)(i_BoardValuesMatrix[i, j].PairSymbol + 'A'));
                    }
                    else
                    {
                        boardStringBuilder.Append("   |");
                    }
                }

                boardStringBuilder.AppendLine();
                boardStringBuilder.AppendLine(getBorderLineForBoard(columns));
            }

            Console.Write(boardStringBuilder.ToString());
        }
        private string getBorderLineForBoard(int i_Columns)
        {
            return "  " + new string('=', i_Columns * 3 + 2 + (i_Columns - 1));
        }
        internal void GetAndCheckPlayerCellChoiceSyntax(ref bool io_IsUserExitGame
            ,out char o_ColumnPlayerCellChoice, out int o_RowPlayerCellChoice)
        {
            o_RowPlayerCellChoice = 0; // init for case user want to exit with Q
            string playerCellChoice;
            bool isRowDigit = true, isColumnUpperCaseChar = true;          
            bool isLengthTwoCharacter, isValidCellChoice;          

            do
            {
                Console.WriteLine("Please enter column character and row digit or Q for exit");
                playerCellChoice = Console.ReadLine();
                if(playerCellChoice.ToUpper() == "Q")
                {
                    io_IsUserExitGame = true;
                    break;
                }

                isLengthTwoCharacter = playerCellChoice.Length == k_MaxUserChoiceLength;
                if(isLengthTwoCharacter)
                {
                    isColumnUpperCaseChar = char.IsUpper(playerCellChoice[0]);
                    isRowDigit = int.TryParse(playerCellChoice[1].ToString()
                                              , out o_RowPlayerCellChoice);
                }

                isValidCellChoice = isLengthTwoCharacter && isColumnUpperCaseChar && isRowDigit;
                if (!isValidCellChoice)
                {
                    Console.WriteLine("InValid Cell Choice(one Upper case character and one digit)");
                }

                printBorder();
            } while (!isValidCellChoice);

            o_ColumnPlayerCellChoice = playerCellChoice[0];
        }
        internal void PrintExeptionForPlayerCellBoardChoiceIllegal()
        {
            Console.WriteLine("Illegal player cell board (out of range or the cell was selected already)");
            printBorder();
        }
        internal void PrintResultOfGame(string i_NamePlayer1, string i_NamePlayer2,
            int i_ScorePlayer1,int i_ScorePlayer2)
        {
            printBorder();
            Console.WriteLine(string.Format(@"First player Name: {0} score: {1}
Second player Name: {2} score: {3}
", i_NamePlayer1, i_ScorePlayer1, i_NamePlayer2, i_ScorePlayer2));
        }
        internal void PrintPlayerNameAndScore(string i_NamePlayer, int i_ScorePlayer)
        {
            Console.WriteLine(string.Format(@"player Name: {0}  score: {1}",
                i_NamePlayer, i_ScorePlayer));
        }
        internal void CheckIfUserWantAnotherGame(out bool o_ShouldStartNewGame)
        {
            string userChoice;
            bool isNOrYCharacter = false, isLengthOneCharacter, isValidInput;
          
            do
            {
                Console.WriteLine("Do you want another game? press Y/N");
                userChoice = Console.ReadLine();
                isLengthOneCharacter = userChoice.Length == 1;
                if (isLengthOneCharacter)
                {
                    isNOrYCharacter = userChoice.ToUpper() == "N" || userChoice.ToUpper() == "Y";
                }

                isValidInput = isNOrYCharacter && isLengthOneCharacter;
            } while (!isValidInput);

            o_ShouldStartNewGame = userChoice.ToUpper() == "Y" ? true : false;
        }
        private void printBorder()
        {
            Console.WriteLine("==============================");
        }
    }
}
