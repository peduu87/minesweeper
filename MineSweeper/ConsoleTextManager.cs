using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{
    internal class ConsoleTextManager
    {
        public void TextWrite(string output, char color = 'w', char variant = 's')
        {
            if (variant == 's')
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
                    case 'm':
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
            }
            else
            {
                switch (color)
                {
                    case 'w':
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;
                    case 'g':
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        break;
                    case 'r':
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        break;
                    case 'd':
                        Console.ForegroundColor = ConsoleColor.Black;
                        break;
                    case 'c':
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        break;
                    case 'y':
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        break;
                    case 'm':
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;
                }
            }

            Console.Write(output);
            Console.ForegroundColor = ConsoleColor.White;
        }


        public void TextWriteLine(string output, char color = 'w', char variant = 's')
        {
            if (variant == 's')
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
                    case 'm':
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
            }
            else
            {
                switch (color)
                {
                    case 'w':
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;
                    case 'g':
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        break;
                    case 'r':
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        break;
                    case 'd':
                        Console.ForegroundColor = ConsoleColor.Black;
                        break;
                    case 'c':
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        break;
                    case 'y':
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        break;
                    case 'm':
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;
                }
            }

            Console.WriteLine(output);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
