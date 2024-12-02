namespace MineSweeper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string appVersion = "0.3";

            Console.Title = $"Peduu's Minesweeper | version {appVersion}";

            BoardManager boardManager = new BoardManager();
            BoardPrinter boardPrinter = new BoardPrinter();

            Console.WriteLine("   _  _      _  _      _  _     __      __       .__                                   _  _      _  _      _  _   ");
            Console.WriteLine("__| || |____| || |____| || |__ /  \\    /  \\ ____ |  |   ____  ____   _____   ____   __| || |____| || |____| || |__");
            Console.WriteLine("\\   __   /\\   __   /\\   __   / \\   \\/\\/   // __ \\|  | _/ ___\\/  _ \\ /     \\_/ __ \\  \\   __   /\\   __   /\\   __   /");
            Console.WriteLine(" |  ||  |  |  ||  |  |  ||  |   \\        /\\  ___/|  |_\\  \\__(  <_> )  Y Y  \\  ___/   |  ||  |  |  ||  |  |  ||  | ");
            Console.WriteLine("/_  ~~  _\\/_  ~~  _\\/_  ~~  _\\   \\__/\\  /  \\___  >____/\\___  >____/|__|_|  /\\___  > /_  ~~  _\\/_  ~~  _\\/_  ~~  _\\");
            Console.WriteLine("  |_||_|    |_||_|    |_||_|          \\/       \\/          \\/            \\/     \\/    |_||_|    |_||_|    |_||_|  ");

            Console.WriteLine($"\nPeduu's Minesweeper V{appVersion}\n\n");

            boardPrinter.PrintBoard(boardManager.CreateEmptyViewBoard());

            Console.WriteLine("\nSelect a cell to start (line and column, example: 1A):");

            bool answerLoopCheck = true;
            string sStartingCoord;
            int[] startingCoord = new int[2];

            while (true)
            {
                if (!answerLoopCheck)
                {
                    Console.WriteLine("\nInvalid cell value.\n\n");
                    boardPrinter.PrintBoard(boardManager.CreateEmptyViewBoard());
                    Console.WriteLine("\nSelect a cell to start (line and column, example: 1A):");
                }
                sStartingCoord = Console.ReadLine();
                if (boardManager.CheckCoordinates(sStartingCoord))
                {
                    startingCoord = boardManager.ConvertCoordinates(sStartingCoord);
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

            char[,] gameBoard = new char[boardManager.CreateEmptyViewBoard().GetLength(0), boardManager.CreateEmptyViewBoard().GetLength(1)];

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
                        gameBoard = boardManager.GenerateGameBoard(mineBoard);
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

            char[,] viewBoard = boardManager.CreateEmptyViewBoard();
            viewBoard[startingCoord[0], startingCoord[1]] = gameBoard[startingCoord[0], startingCoord[1]];

            boardPrinter.PrintBoard(viewBoard);
            
            short gameStatus = 0; // 0 while playing, -1 if the player lose and 1 if he win.

            while (gameStatus == 0)
            {

            }
        }
    }
}
