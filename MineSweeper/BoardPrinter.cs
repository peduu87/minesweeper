using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{
    internal class BoardPrinter
    {
        private string topLine = "   | A | B | C | D | E | F | G | H | I "; // 3 spaces.

        public void PrintBoard(char[,] board)
        {
            for (int i = 0; i < topLine.Length; i++)
            {
                if (char.IsLetter(topLine[i]))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(topLine[i].ToString());
                    Console.ForegroundColor = ConsoleColor.White;
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
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{i + 1} ");
                Console.ForegroundColor = ConsoleColor.White;
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
