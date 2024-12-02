using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{
    internal class ConsoleTextManager
    {
        public void TextWrite(string output, char color = 'w')
        {
            switch (color)
            {
                case 'w':
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case 'g':
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case 'r':
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case 'd':
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    break;
                case 'c':
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case 'y':
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
            }

            Console.Write(output);
            Console.ForegroundColor = ConsoleColor.White;
        }


        public void TextWriteLine(string output, char color = 'w')
        {
            switch (color)
            {
                case 'w':
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case 'g':
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case 'r':
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case 'd':
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    break;
                case 'c':
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case 'y':
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
            }

            Console.WriteLine(output);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
