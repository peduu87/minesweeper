using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{
    internal class BoardManager
    {
        // This will ease the process of converting user coordinates to array coordinates.
        char[] boardLines = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        char[] boardColumns = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I' };

        public char[,] CreateEmptyViewBoard() // Creates an array (board) and fill it with dots so the player can choose where to start.
        {
            char[,] board = new char[9, 9];

            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j] = ' ';
                }
            }

            return board;
        }

        public char[,] GenerateMineBoard(string startingCoord, int mineAmount = 10)
        {
            Random rdn = new Random();

            int[] iStartingCoord = ConvertCoordinates(startingCoord);

            //Console.WriteLine($"{iStartingCoord[0]}, {iStartingCoord[1]}");

            char[,] mineBoard = CreateEmptyViewBoard(); // Improvised solution to view the board.

            int mineCounter = 0;

            while (true)
            {
                for (int i = 0; i < mineBoard.GetLength(0); i++)
                {
                    for (int j = 0; j < mineBoard.GetLength(1); j++)
                    {
                        if ((iStartingCoord[0] != i && iStartingCoord[1] != j) || mineBoard[i, j] != 'M')
                        {
                            if (rdn.Next(0, 10) == 1 && mineAmount != mineCounter)
                            {
                                mineBoard[i, j] = 'M';
                                mineCounter++;
                            }
                        }
                    }
                }

                if(mineAmount == mineCounter)
                {
                    break;
                }
            }

            return mineBoard;
        }

        public char[,] GenerateGameBoard(char[,] mineBoard)
        {
            char[,] gameBoard = mineBoard;

            for(int i = 0; i < mineBoard.GetLength(0); i++)
            {
                for(int j = 0; j <mineBoard.GetLength(1); j++)
                {
                    if (mineBoard[i, j] != 'M')
                    {
                        int mineCounter = 0;

                        mineCounter += CheckAdjacentCell(mineBoard, i - 1, j - 1);
                        mineCounter += CheckAdjacentCell(mineBoard, i - 1, j);
                        mineCounter += CheckAdjacentCell(mineBoard, i - 1, j + 1);
                        mineCounter += CheckAdjacentCell(mineBoard, i, j - 1);
                        mineCounter += CheckAdjacentCell(mineBoard, i, j + 1);
                        mineCounter += CheckAdjacentCell(mineBoard, i + 1, j - 1);
                        mineCounter += CheckAdjacentCell(mineBoard, i + 1, j);
                        mineCounter += CheckAdjacentCell(mineBoard, i + 1, j + 1);

                        if(mineCounter > 0)
                        {
                            gameBoard[i, j] = char.Parse(mineCounter.ToString());

                        }
                        else
                        {
                            gameBoard[i, j] = 'O';
                        }
                    }
                }
            }

            return gameBoard;
        }

        internal int CheckAdjacentCell(char[,] mineBoard, int adjCellLine, int adjCellCol)
        {
            int[] adjCellCoord = { adjCellLine, adjCellCol };
            try
            {
                if (mineBoard[adjCellCoord[0], adjCellCoord[1]] == 'M')
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                return 0;
            }
        }

        public bool CheckCoordinates(string coord)
        {
            coord = coord.ToUpper();

            if (coord.Length != 2)
            {
                return false;
            }

            for (int i = 0; i < boardLines.Length; i++)
            {
                if (coord[0] == boardLines[i])
                {
                    for (int j = 0; j < boardColumns.Length; j++)
                    {
                        if (coord[1] == boardColumns[j])
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public int[] ConvertCoordinates(string coord) 
        {
            int[] iCoord = new int[2];

            for (int i = 0; i < boardLines.Length; i++)
            {
                if (int.Parse(coord[0].ToString()) == int.Parse(boardLines[i].ToString()))
                {
                    iCoord[0] = i;
                }
            }
            for (int i = 0; i < boardLines.Length; i++)
            {
                if (coord.ToUpper()[1] == boardColumns[i])
                {
                    iCoord[1] = i;
                }
            }

            return iCoord;
        }
    }
}
