using System;
using System.Collections.Generic;


namespace Ex02_System
{
    internal class Board
    {
        private int m_HeightBoard;
        private int m_WidthBoard;
        private int m_CountVisiblePairs;
        private BoardCell[,] m_BoardPairSymbolMatrix;
        internal Board(int i_HeightBoard, int i_WidthBoard)
        {
            this.m_HeightBoard = i_HeightBoard;
            this.m_WidthBoard = i_WidthBoard;
            this.m_BoardPairSymbolMatrix = new BoardCell[i_HeightBoard, i_WidthBoard];
            this.m_CountVisiblePairs = 0;
            initPairsSymbolForBoardMatrix();
        }
        internal int HeightBoard
        {
            get
            {
                return this.m_HeightBoard;
            }
        }
        internal int WidthBoard
        {
            get
            {
                return this.m_WidthBoard;
            }
        }
        internal BoardCell[,] BoardPairSymbolMatrix
        {
            get
            {
                return this.m_BoardPairSymbolMatrix;
            }
        }
        private void initPairsSymbolForBoardMatrix()
        {
            List<int> numbersBoardList = new List<int>();
            int totalCells = this.m_HeightBoard * this.m_WidthBoard;
            int numberPairCount = totalCells / 2;

            for (int i = 0; i < numberPairCount; i++)
            {
                numbersBoardList.Add(i);
                numbersBoardList.Add(i);
            }

            shuffleListNumbers(numbersBoardList);
            fillMatrixWithShuffledNumbers(numbersBoardList);
        }
        private void shuffleListNumbers(List<int> i_NumbersBoardList)
        {
            // Shuffle the list using Fisher-Yates algorithm
            Random rand = new Random();
            int randomIndex;
            int currentNumberShuffled;

            for (int i = i_NumbersBoardList.Count - 1; i > 0; i--)
            {
                randomIndex = rand.Next(i + 1);
                currentNumberShuffled = i_NumbersBoardList[i];
                i_NumbersBoardList[i] = i_NumbersBoardList[randomIndex];
                i_NumbersBoardList[randomIndex] = currentNumberShuffled;
            }
        }
        private void fillMatrixWithShuffledNumbers(List<int> i_NumbersBoardList)
        {
            int indexList = 0;

            for (int row = 0; row < this.m_HeightBoard; row++)
            {
                for (int col = 0; col < this.m_WidthBoard; col++)
                {
                    this.m_BoardPairSymbolMatrix[row, col] = new BoardCell(i_NumbersBoardList[indexList++]);
                }
            }
        }
        internal bool CheckChosenBoardCell(char i_ColumnPlayerCellChoice,int i_RowPlayerCellChoice)
        {
            bool isColumnInRange, isRowInRange, isCellVisible = false;
          
            isColumnInRange = i_ColumnPlayerCellChoice - 'A' < this.m_WidthBoard 
                              && i_ColumnPlayerCellChoice - 'A' >= 0;
            isRowInRange = i_RowPlayerCellChoice - 1 < this.m_WidthBoard
                              && i_ColumnPlayerCellChoice >= 1;
            if(isColumnInRange && isRowInRange)
            {
                isCellVisible = this.m_BoardPairSymbolMatrix
                    [i_RowPlayerCellChoice - 1, i_ColumnPlayerCellChoice - 'A'].IsVisibleCell;
            }

            return isColumnInRange && isRowInRange && !isCellVisible;
        }
        internal void SetPlayerCellChoiceVisible(BoardCell i_BoardCell)
        {
            i_BoardCell.IsVisibleCell = true;
        }
        internal BoardCell GetBoardCell(char i_ColumnPlayerCellChoice, int i_RowPlayerCellChoice)
        {
            return this.m_BoardPairSymbolMatrix[i_RowPlayerCellChoice - 1, i_ColumnPlayerCellChoice - 'A'];
        }
        internal bool CheckIfCellsArePair(BoardCell i_BoardCell1, BoardCell i_BoardCell2)
        {
            return i_BoardCell1.PairSymbol == i_BoardCell2.PairSymbol;
        }
        internal void AddToCountVisiblePair()
        {
            this.m_CountVisiblePairs++;
        }
        internal bool IsAllCellsBoardVisible()
        {
            return this.m_CountVisiblePairs == (this.m_HeightBoard * this.m_WidthBoard) / 2;
        }
    }
}
