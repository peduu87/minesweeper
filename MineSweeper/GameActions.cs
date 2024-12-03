using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{
    internal class GameActions
    {
        BoardPrinter boardPrinter = new BoardPrinter();
        ConsoleTextManager textManager = new ConsoleTextManager();

        private char[] boardLines = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        private char[] boardColumns = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I' };

        private bool CheckCoordinates(string coord)
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

        private int[] ConvertCoordinates(string coord)
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

        public bool openCell(char[,] viewBoard, char[,] gameBoard) // It will return a bool so the cell can be further count as open.
        {
            Console.WriteLine("\nSelect a cell to open (line and column, example: 1A):");
            textManager.TextWriteLine("Insert [CCC] to cancel the action.", 'd');

            int[] coord = new int[2];

            while (true)
            {
                string sCoord = Console.ReadLine();

                if(sCoord.ToUpper() == "CCC")
                {
                    break;
                }
                else if (CheckCoordinates(sCoord))
                {
                    coord = ConvertCoordinates(sCoord);

                    if(viewBoard[coord[0], coord[1]] == 'F' || viewBoard[coord[0], coord[1]] == ' ')
                    {
                        viewBoard[coord[0], coord[1]] = gameBoard[coord[0], coord[1]];

                        return true;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    textManager.TextWriteLine("\n\n\n\nInvalid value.\n\n", 'r');

                    boardPrinter.PrintBoard(viewBoard, false);
                    boardPrinter.PrintGameInfo(viewBoard, gameBoard);

                    Console.WriteLine("\nSelect a cell to open (line and column, example: 1A):");
                    textManager.TextWriteLine("Insert [CCC] to cancel the action.", 'd');
                }
            }

            return false;
        }

        public void placeFlag(char[,] viewBoard, char[,] gameBoard)
        {
            Console.WriteLine($"\nSelect a cell to place a flag (line and column, example: 1A):");
            textManager.TextWriteLine("Insert [CCC] to cancel the action.", 'd');

            int[] coord = new int[2];

            while (true)
            {
                string sCoord = Console.ReadLine();

                if (sCoord.ToUpper() == "CCC")
                {
                    break;
                }
                else if (CheckCoordinates(sCoord))
                {
                    coord = ConvertCoordinates(sCoord);
                    if(viewBoard[coord[0], coord[1]] == ' ')
                    {
                        viewBoard[coord[0], coord[1]] = 'F';
                    }
                    
                    break;
                }
                else
                {
                    textManager.TextWriteLine("\n\n\n\nInvalid value.\n\n", 'r');

                    boardPrinter.PrintBoard(viewBoard, false);
                    boardPrinter.PrintGameInfo(viewBoard, gameBoard);

                    Console.WriteLine("\nSelect a cell to open (line and column, example: 1A):");
                    textManager.TextWriteLine("Insert [CCC] to cancel the action.", 'd');
                }
            }
        }
    }
}
