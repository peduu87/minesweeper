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

            while (true)
            {
                if (!answerLoopCheck)
                {
                    Console.WriteLine("\nInvalid cell value.\n");
                    Console.WriteLine("\nSelect a cell to start (line and column, example: 1A):");
                }
                string startingCoord = Console.ReadLine();
                if (boardManager.CheckCoordinates(startingCoord))
                {
                    char[,] mineBoard = boardManager.GenerateMineBoard(startingCoord);
                    boardPrinter.PrintBoard(mineBoard);
                    boardPrinter.PrintBoard(boardManager.GenerateGameBoard(mineBoard));
                    answerLoopCheck = true;
                    break;
                }
                else
                {
                    answerLoopCheck = false;
                }
            }
        }
    }
}
