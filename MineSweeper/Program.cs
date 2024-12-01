namespace MineSweeper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("   _  _      _  _      _  _     __      __       .__                                   _  _      _  _      _  _   ");
            Console.WriteLine("__| || |____| || |____| || |__ /  \\    /  \\ ____ |  |   ____  ____   _____   ____   __| || |____| || |____| || |__");
            Console.WriteLine("\\   __   /\\   __   /\\   __   / \\   \\/\\/   // __ \\|  | _/ ___\\/  _ \\ /     \\_/ __ \\  \\   __   /\\   __   /\\   __   /");
            Console.WriteLine(" |  ||  |  |  ||  |  |  ||  |   \\        /\\  ___/|  |_\\  \\__(  <_> )  Y Y  \\  ___/   |  ||  |  |  ||  |  |  ||  | ");
            Console.WriteLine("/_  ~~  _\\/_  ~~  _\\/_  ~~  _\\   \\__/\\  /  \\___  >____/\\___  >____/|__|_|  /\\___  > /_  ~~  _\\/_  ~~  _\\/_  ~~  _\\");
            Console.WriteLine("  |_||_|    |_||_|    |_||_|          \\/       \\/          \\/            \\/     \\/    |_||_|    |_||_|    |_||_|  ");

            Console.WriteLine("\nPeduu's Minesweeper V1.0\n\n");

            BoardManager boardManager = new BoardManager();
            BoardPrinter boardPrinter = new BoardPrinter();

            boardPrinter.PrintBoard(boardManager.CreateEmptyViewBoard());

            Console.WriteLine("\nSelect a cell to start (line and column, example: 1A):");

            bool answerLoopCheck = true;
            string startingCoord;

            while (true)
            {
                if (!answerLoopCheck)
                {
                    Console.WriteLine("\nInvalid cell value.\n");
                    Console.WriteLine("\nSelect a cell to start (line and column, example: 1A):");
                }
                startingCoord = Console.ReadLine();
                if (boardManager.CheckCoordinates(startingCoord))
                {
                    answerLoopCheck = true;
                    break;
                }
                else
                {
                    answerLoopCheck = false;
                }
            }

            answerLoopCheck = true;

            Console.WriteLine("\nInsert the amount of mines in the board (1-30):");

            while (true)
            {
                if (!answerLoopCheck)
                {
                    Console.WriteLine("\nInvalid value.\n");
                    Console.WriteLine("\nInsert the amount of mines in the board (1-30):");
                }
                string sMineAmount = Console.ReadLine();

                if (int.TryParse(sMineAmount, out int mineAmount))
                {
                    if (mineAmount > 0 && mineAmount < 30)
                    {
                        char[,] mineBoard = boardManager.GenerateMineBoard(startingCoord, mineAmount);
                        char[,] gameBoard = boardManager.GenerateGameBoard(mineBoard);
                        answerLoopCheck = true;
                        break;
                    }
                    else
                    {
                        answerLoopCheck = false;
                    }
                }
                else
                {
                    answerLoopCheck = false;
                }
            }


        }
    }
}
