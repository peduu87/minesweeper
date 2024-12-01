using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{
    public class BoardManager
    {
        char[] boardLines = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        char[] boardColumns = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I' };

        public char[,] CreateEmptyViewBoard()
        {
            char[,] board = new char[9, 9];

            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j] = 'O';
                }
            }

            return board;
        }

        public char[,] GenerateMineBoard(string startingCoord, int mineAmount = 10)
        {
            Random rdn = new Random();

            int[] iStartingCoord = new int[2];

            for(int i = 0; i < boardLines.Length; i++)
            {
                if (int.Parse(startingCoord[0].ToString()) == int.Parse(boardLines[i].ToString()))
                {
                    iStartingCoord[0] = i;
                }
            }
            for (int i = 0; i < boardLines.Length; i++)
            {
                if (startingCoord.ToUpper()[1] == boardColumns[i])
                {
                    iStartingCoord[1] = i;
                }
            }

            //Console.WriteLine($"{iStartingCoord[0]}, {iStartingCoord[1]}");

            //char[,] mineBoard = new char[9, 9];

            char[,] mineBoard = CreateEmptyViewBoard(); // Temporary solution to view the board.

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

        

        internal int CheckAdjacentCell(char[,] mineBoard, int[] adjCellCoord)
        {
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

        public void PrintBoard(char[,] board)
        {
            string topLine = "    | A | B | C | D | E | F | G | H | I |"; // 4 spaces.
            Console.WriteLine(topLine + "\n");

            for (int i = 0; i < board.GetLength(0); i++)
            {
                Console.Write($"{i + 1}   | ");
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    Console.Write((char)board[i, j] + " | ");
                }
                Console.WriteLine();
                if(i < board.GetLength(0) - 1)
                {
                    for (int j = 0; j < topLine.Length; j++)
                    {
                        Console.Write("-");
                    }
                    Console.WriteLine();
                }
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
    }
}
