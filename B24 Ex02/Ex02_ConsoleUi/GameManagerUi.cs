using Ex02_System;
using System.Collections.Generic;

namespace Ex02_ConsoleUi
{
    public class GameManagerUi
    {
        private const int k_MaxDimension = 6;
        private const int k_MinDimension = 4;
        private GameConsoleInterface m_GameConsoleInterface;
        private GameManagerLogic m_GameManagerLogic;
        public GameManagerUi()
        {
            this.m_GameConsoleInterface = new GameConsoleInterface();
            this.m_GameManagerLogic = null;
        }
        public void StartGame()
        {
            int heightBoard, widthBoard;
            string playerName1, playerName2;
            bool shouldStartNewGame;
            eGameType gameType;

            this.m_GameConsoleInterface.PrintOpeningStartGame();
            this.m_GameManagerLogic = new GameManagerLogic();
            playerName1 = this.m_GameConsoleInterface.GetPlayerName();
            this.m_GameConsoleInterface.ChooseYourGameType(out gameType);
            playerName2 = this.m_GameConsoleInterface.GetNameSecondPlayerAccordingToGameType(gameType);
            List<string> namePlayers = buildListPlayerNamesForLogic(playerName1, playerName2);
            List<bool> signPlayers = buildListSignPlayerForLogic(gameType);
            this.m_GameManagerLogic.InitGameManagerPlayers(namePlayers, signPlayers);
            do
            {
                getDimentionsAntilLogicApproveLegality(out heightBoard, out widthBoard);
                this.m_GameManagerLogic.InitBoard(heightBoard, widthBoard);
                if (gameRounds())
                    break; 
                this.m_GameConsoleInterface.CheckIfUserWantAnotherGame(out shouldStartNewGame);
            } while (shouldStartNewGame);
        }
        private List<string> buildListPlayerNamesForLogic(string i_PlayerName1, string i_PlayerName2)
        {
            List<string> namePlayers = new List<string>();

            namePlayers.Add(i_PlayerName1);
            namePlayers.Add(i_PlayerName2);
           
            return namePlayers;
        }
        private List<bool> buildListSignPlayerForLogic(eGameType i_GameType)
        {
            List<bool> signPlayers = new List<bool>();

            signPlayers.Add(false);
            if (i_GameType==eGameType.PlayerVsPlayer)
            {
                signPlayers.Add(false);
            }
            else
            {
                signPlayers.Add(true);
            }
            
            return signPlayers;
        }
        private void getDimentionsAntilLogicApproveLegality(out int o_HeightBoard, out int o_WidthBoard)
        {
            bool isEvenDimention, isDimenstionsInRange;
           
            do
            {
                this.m_GameConsoleInterface.GetAndCheckIsDimenstionNumber(out o_HeightBoard, "height");
                this.m_GameConsoleInterface.GetAndCheckIsDimenstionNumber(out o_WidthBoard, "width");
                isDimenstionsInRange = GetAndCheckIsDimenstionInRange(o_HeightBoard, o_WidthBoard);
                isEvenDimention = this.m_GameManagerLogic
                    .CheckEvenDimensionsForBoard(o_HeightBoard, o_WidthBoard);
                if (!isDimenstionsInRange)
                {
                    this.m_GameConsoleInterface.PrintExeptionForBoardDimentionsInUi();
                }
                else if (!isEvenDimention)
                {
                    this.m_GameConsoleInterface.PrintExeptionForBoardDimenstionsInLogic();
                }
            } while (!isEvenDimention || !isDimenstionsInRange);
        }
        internal bool GetAndCheckIsDimenstionInRange(int i_Height, int i_Width)
        {
            return (i_Height <= k_MaxDimension && i_Height >= k_MinDimension)
                 && (i_Width <= k_MaxDimension && i_Width >= k_MinDimension);         
        }
        private bool gameRounds()
        {
            bool isUserExitGame = false, isGameOver = false;
            int rowPlayerCellChoice1, rowPlayerCellChoice2;
            char columnPlayerCellChoice1, columnPlayerCellChoice2;

            clearAndPrintBoard();
            do
            {
                if(this.m_GameManagerLogic.IsComputerTurn())
                {
                    this.m_GameManagerLogic.HalfRoundOfComputerPlayer(out columnPlayerCellChoice1,
                        out rowPlayerCellChoice1);
                    clearAndPrintBoard();
                    this.m_GameManagerLogic.HalfRoundOfComputerPlayer(out columnPlayerCellChoice2,
                        out rowPlayerCellChoice2);
                    clearAndPrintBoard();
                }
                else
                {
                    halfRoundOfUserPlayer(ref isUserExitGame,
                   out columnPlayerCellChoice1, out rowPlayerCellChoice1);
                    if(isUserExitGame)
                    {
                        break;
                    }
                    halfRoundOfUserPlayer(ref isUserExitGame,
                        out columnPlayerCellChoice2, out rowPlayerCellChoice2);
                    if (isUserExitGame)
                    {
                        break;
                    }
                }

                bool isMatchingPair = this.m_GameManagerLogic
                    .UpdateRoundResultAndReturnIsMatchingPair(columnPlayerCellChoice1,
                    rowPlayerCellChoice1, columnPlayerCellChoice2, rowPlayerCellChoice2);
                if (!isMatchingPair)
                {
                    System.Threading.Thread.Sleep(2000);
                }

                clearAndPrintBoard();
                checkAndHandleGameOver(ref isGameOver);
            } while (!isUserExitGame && !isGameOver);

            return isUserExitGame;
        }
        private void getPlayerCellChoiceAntilLegal(ref bool io_IsUserExitGame,
            out char o_ColumnPlayerCellChoice, out int o_RowPlayerCellChoice)
        {
            bool isValidPlayerCellChoice;
            
            do
            {
                this.m_GameConsoleInterface.GetAndCheckPlayerCellChoiceSyntax(ref io_IsUserExitGame,
                    out o_ColumnPlayerCellChoice, out o_RowPlayerCellChoice);
                if(io_IsUserExitGame)
                {
                    return;
                }

                isValidPlayerCellChoice = this.m_GameManagerLogic
                    .CheckLegalPlayerCellBoardChoice(o_ColumnPlayerCellChoice, o_RowPlayerCellChoice);
                if (!isValidPlayerCellChoice)
                {
                    this.m_GameConsoleInterface.PrintExeptionForPlayerCellBoardChoiceIllegal();
                }
            } while (!isValidPlayerCellChoice);
        }
        private void halfRoundOfUserPlayer(ref bool io_IsUserExitGame,
            out char o_ColumnPlayerCellChoice, out int o_RowPlayerCellChoice)
        {
            getPlayerCellChoiceAntilLegal(ref io_IsUserExitGame,
               out o_ColumnPlayerCellChoice, out o_RowPlayerCellChoice);
            if (io_IsUserExitGame)
            {
                return;
            }

            this.m_GameManagerLogic.SetPlayerCellChoiceVisibleForBaord(o_ColumnPlayerCellChoice
                , o_RowPlayerCellChoice);
            clearAndPrintBoard();
        }
        private void clearAndPrintBoard()
        {
            string playerName;
            int playerScore;

            Ex02.ConsoleUtils.Screen.Clear();
            this.m_GameConsoleInterface.PrintBoard(this.m_GameManagerLogic.GetMatrixBoard());
            this.m_GameManagerLogic.GetCurrentPlayerNameAndScore(out playerName, out playerScore);
            this.m_GameConsoleInterface.PrintPlayerNameAndScore(playerName, playerScore);
        }
        private void checkAndHandleGameOver(ref bool io_IsGameOver)
        {
            List<string> playersNames;
            List<int> playersScores;

            io_IsGameOver = this.m_GameManagerLogic.CheckIfGameOver();
            if(io_IsGameOver)
            {
                this.m_GameManagerLogic.GetPlayersNameAndScoresForGameResult(out playersNames,
                    out playersScores);
                this.m_GameConsoleInterface.PrintResultOfGame(playersNames[0]
                    , playersNames[1], playersScores[0], playersScores[1]);
            }
        }
    }
}
