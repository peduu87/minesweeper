﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{
    internal class BoardPrinter
    {
        ConsoleTextManager textManager = new ConsoleTextManager();

        private string topLine = "   | A | B | C | D | E | F | G | H | I "; // 3 spaces.

        public void PrintBoard(char[,] board, bool upPadding = true)
        {
            if (upPadding)
            {
                Console.WriteLine("\n\n\n");
            }

            for (int i = 0; i < topLine.Length; i++)
            {
                if (char.IsLetter(topLine[i]))
                {
                    textManager.TextWrite(topLine[i].ToString(), 'g');
                }
                else
                {
                    Console.Write(topLine[i].ToString());
                }
            }
            Console.WriteLine();

            for (int j = 0; j < topLine.Length; j++)
            {
                Console.Write("-");
            }
            Console.WriteLine();

            for (int i = 0; i < board.GetLength(0); i++)
            {
                textManager.TextWrite($"{i + 1} ", 'g');

                for (int j = 0; j < board.GetLength(1); j++)
                {
                    Console.Write(" | " + (char)board[i, j]);
                }
                Console.WriteLine();
                if (i < board.GetLength(0) - 1)
                {
                    Console.WriteLine(GetDashLine(topLine));
                }
            }
        }

        public void PrintGameInfo(char[,] viewBoard, char[,] gameBoard)
        {
            int mineAmount = 0, flagAmount = 0;

            for (int i = 0; i < gameBoard.GetLength(0); i++)
            {
                for (int j = 0; j < gameBoard.GetLength(1); j++)
                {
                    if (gameBoard[i, j] == 'M')
                    {
                        mineAmount++;
                    }
                }
            }

            for (int i = 0; i < viewBoard.GetLength(0); i++)
            {
                for (int j = 0; j < viewBoard.GetLength(1); j++)
                {
                    if (viewBoard[i, j] == 'F')
                    {
                        flagAmount++;
                    }
                }
            }

            Console.WriteLine($"\nFlags placed: {flagAmount}.\tExpected mines remaining: {mineAmount - flagAmount}.");
        }

        private string GetDashLine(string referenceLine)
        {
            string dashLine = string.Empty;

            for (int i = 0; i < referenceLine.Length; i++)
            {
                dashLine += "-";
            }

            return dashLine;
        }
    }
}
