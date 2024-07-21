using System;
using System.Collections.Generic;

namespace Ex02_System
{
    public class GameManagerLogic
    {
        private GameManagerPlayers m_GameManagerPlayers;
        private Board m_Board;
        public void InitBoard(int i_HeightBoard,int i_WidthBoard)
        {
            this.m_Board = new Board(i_HeightBoard, i_WidthBoard);
        }
        public void InitGameManagerPlayers(List<string> i_PlayersNames, List<bool> i_IsComputerPerIndexInListNames)
        {
            this.m_GameManagerPlayers = new GameManagerPlayers();
            this.m_GameManagerPlayers.AddPlayersToListOfPlayers(i_PlayersNames,
            i_IsComputerPerIndexInListNames);
        }
        public bool CheckEvenDimensionsForBoard(int i_Height, int i_Width)
        {
            return (i_Height % 2 == 0) && (i_Width % 2 == 0);
        }
        public BoardCell[,] GetMatrixBoard()
        {
            return this.m_Board.BoardPairSymbolMatrix;
        }
        public bool CheckLegalPlayerCellBoardChoice(char i_ColumnPlayerCellChoice, int i_RowPlayerCellChoice)
        {
            return this.m_Board.CheckChosenBoardCell(i_ColumnPlayerCellChoice, i_RowPlayerCellChoice);
        }
        public void SetPlayerCellChoiceVisibleForBaord(char i_ColumnPlayerCellChoice, int i_RowPlayerCellChoice)
        {
            BoardCell boardCell;

            boardCell = this.m_Board.GetBoardCell(i_ColumnPlayerCellChoice, i_RowPlayerCellChoice);
            this.m_Board.SetPlayerCellChoiceVisible(boardCell);
        }
        public bool UpdateRoundResultAndReturnIsMatchingPair(char i_ColumnPlayerCellChoice1,
            int i_RowPlayerCellChoice1, char i_ColumnPlayerCellChoice2, int i_RowPlayerCellChoice2)
        {
            bool isMatchingPair;

            BoardCell boardCell1 = this.m_Board.GetBoardCell(i_ColumnPlayerCellChoice1, i_RowPlayerCellChoice1);
            BoardCell boardCell2 = this.m_Board.GetBoardCell(i_ColumnPlayerCellChoice2, i_RowPlayerCellChoice2);
            if(this.m_Board.CheckIfCellsArePair(boardCell1, boardCell2))
            {
                updateRoundScore();
                isMatchingPair = true;
            }
            else
            {
                boardCell1.IsVisibleCell = false;
                boardCell2.IsVisibleCell = false;
                this.m_GameManagerPlayers.SwitchPlayerTurn();
                isMatchingPair = false;
            }

            return isMatchingPair;
        }
        private void updateRoundScore()
        {
            this.m_GameManagerPlayers.AddPointToScoreForCurrentPlayer();
            this.m_Board.AddToCountVisiblePair();
        }
        public void HalfRoundOfComputerPlayer(out char o_ColumnPlayerCellChoice,
           out int o_RowPlayerCellChoice)
        {
            int rowRandom, columnRandom;
            bool isComputerBoardCellValid;
            Random rand = new Random();

            do
            {
                rowRandom = rand.Next(0, this.m_Board.HeightBoard);
                columnRandom = rand.Next(0, this.m_Board.WidthBoard);
                isComputerBoardCellValid = this.m_Board
                    .CheckChosenBoardCell((char)('A' + columnRandom), rowRandom + 1);
            } while (!isComputerBoardCellValid);

            o_ColumnPlayerCellChoice = (char)('A' + columnRandom);
            o_RowPlayerCellChoice = rowRandom + 1;
            SetPlayerCellChoiceVisibleForBaord(o_ColumnPlayerCellChoice, o_RowPlayerCellChoice);
        } 
        public bool IsComputerTurn()
        {
            return this.m_GameManagerPlayers.IsComputerTurn();
        }
        public bool CheckIfGameOver()
        {
            return this.m_Board.IsAllCellsBoardVisible();
        }
        public void GetPlayersNameAndScoresForGameResult(out List<string> o_PlayersName,
            out List<int> o_ScorePerIndexInListPlayersNames)
        {
            o_PlayersName = new List<string>();
            o_ScorePerIndexInListPlayersNames = new List<int>();
            this.m_GameManagerPlayers.GetNamesListAndScoresListOfPlayers(o_PlayersName, o_ScorePerIndexInListPlayersNames);
        }
        public void GetCurrentPlayerNameAndScore(out string o_NamePlayer, out int o_ScorePlayer)
        {
            this.m_GameManagerPlayers.GetNameAndScoreOfCurrentPlayer(out o_NamePlayer, out o_ScorePlayer);
        }
    }
}
