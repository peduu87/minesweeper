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
            ConsoleTextManager textManager = new ConsoleTextManager();

            Console.WriteLine("   _  _      _  _      _  _     __      __       .__                                   _  _      _  _      _  _   ");
            Console.WriteLine("__| || |____| || |____| || |__ /  \\    /  \\ ____ |  |   ____  ____   _____   ____   __| || |____| || |____| || |__");
            Console.WriteLine("\\   __   /\\   __   /\\   __   / \\   \\/\\/   // __ \\|  | _/ ___\\/  _ \\ /     \\_/ __ \\  \\   __   /\\   __   /\\   __   /");
            Console.WriteLine(" |  ||  |  |  ||  |  |  ||  |   \\        /\\  ___/|  |_\\  \\__(  <_> )  Y Y  \\  ___/   |  ||  |  |  ||  |  |  ||  | ");
            Console.WriteLine("/_  ~~  _\\/_  ~~  _\\/_  ~~  _\\   \\__/\\  /  \\___  >____/\\___  >____/|__|_|  /\\___  > /_  ~~  _\\/_  ~~  _\\/_  ~~  _\\");
            Console.WriteLine("  |_||_|    |_||_|    |_||_|          \\/       \\/          \\/            \\/     \\/    |_||_|    |_||_|    |_||_|  ");
            Console.WriteLine($"\nPeduu's Minesweeper V{appVersion}\n\n");

            boardPrinter.PrintBoard(boardManager.CreateEmptyViewBoard(), false);

            Console.WriteLine("\nSelect a cell to start (line and column, example: 1A):");

            string sStartingCoord;
            int[] startingCoord = new int[2];

            while (true)
            {
                sStartingCoord = Console.ReadLine();

                if (boardManager.CheckCoordinates(sStartingCoord))
                {
                    startingCoord = boardManager.ConvertCoordinates(sStartingCoord);

                    break;
                }
                else
                {
                    textManager.TextWriteLine("\n\n\n\nInvalid cell value.\n\n", 'r');

                    boardPrinter.PrintBoard(boardManager.CreateEmptyViewBoard());

                    Console.WriteLine("\nSelect a cell to start (line and column, example: 1A):");
                }
            }

            Console.WriteLine("\nInsert the amount of mines in the board (1-30):");

            char[,] gameBoard = new char[boardManager.CreateEmptyViewBoard().GetLength(0), boardManager.CreateEmptyViewBoard().GetLength(1)];

            int mineAmount = 0;

            while (true)
            {
                string sMineAmount = Console.ReadLine();

                if (int.TryParse(sMineAmount, out mineAmount))
                {
                    if (mineAmount > 0 && mineAmount <= 30)
                    {
                        char[,] mineBoard = boardManager.GenerateMineBoard(startingCoord, mineAmount);

                        gameBoard = boardManager.GenerateGameBoard(mineBoard);

                        break;
                    }
                    else
                    {
                        textManager.TextWriteLine("\n\n\n\nInvalid value.\n\n", 'r');
                        Console.WriteLine("\nInsert the amount of mines in the board (1-30):");
                    }
                }
                else
                {
                    textManager.TextWriteLine("\n\n\n\nInvalid value.\n\n", 'r');
                    Console.WriteLine("\nInsert the amount of mines in the board (1-30):");
                }
            }

            char[,] viewBoard = boardManager.CreateEmptyViewBoard();

            viewBoard[startingCoord[0], startingCoord[1]] = gameBoard[startingCoord[0], startingCoord[1]];

            short gameStatus = 0; // 0 while playing, -1 if the player lose and 1 if he win.
            int openCellCounter = 1;

            while (gameStatus == 0)
            {
                boardPrinter.PrintBoard(viewBoard);
                boardPrinter.PrintGameInfo(viewBoard, gameBoard);
                
                Console.WriteLine("\nInsert an action:");
                textManager.TextWriteLine("[O] Open cell\t[A] Open all remaining cells\n[F] Place flag\t[R] Remove flag", 'd');

                string playerAction;

                while (true)
                {
                    playerAction = Console.ReadLine();

                    if (boardManager.CheckAction(playerAction))
                    {
                        openCellCounter += boardManager.PlayAction(viewBoard, gameBoard, playerAction);
                        break;
                    }
                    else
                    {
                        textManager.TextWriteLine("\n\n\n\nInvalid action.\n\n", 'r');

                        boardPrinter.PrintBoard(viewBoard, false);
                        boardPrinter.PrintGameInfo(viewBoard, gameBoard);

                        Console.WriteLine("\nInsert an action:");
                        textManager.TextWriteLine("[O] Open cell\t[F] Place flag");
                    }
                }

                for (int i = 0; i < viewBoard.GetLength(0); i++)
                {
                    for(int j = 0; j < viewBoard.GetLength(1); j++)
                    {
                        if (viewBoard[i, j] == 'M')
                        {
                            gameStatus = -1;
                            break;
                        }
                    }
                    if(gameStatus == -1)
                    {
                        break;
                    }
                }

                if(openCellCounter + mineAmount == gameBoard.GetLength(0) * gameBoard.GetLength(1))
                {
                    gameStatus = 1;
                }
            }

            if(gameStatus == -1)
            {
                textManager.TextWriteLine("\n\n\n\n* GAME OVER *\n\n", 'r');

                boardPrinter.PrintBoard(gameBoard, false);
            }
            else if(gameStatus == 1)
            {
                boardPrinter.PrintBoard(gameBoard);
                Console.WriteLine();
                textManager.TextWriteLine("         _________ _______ _________ _______  _______          ", 'g');
                textManager.TextWriteLine("|\\     /|\\__   __/(  ____ \\\\__   __/(  ___  )(  ____ )|\\     /|", 'g');
                textManager.TextWriteLine("| )   ( |   ) (   | (    \\/   ) (   | (   ) || (    )|( \\   / )", 'g');
                textManager.TextWriteLine("| |   | |   | |   | |         | |   | |   | || (____)| \\ (_) / ", 'g');
                textManager.TextWriteLine("( (   ) )   | |   | |         | |   | |   | ||     __)  \\   /  ", 'g');
                textManager.TextWriteLine(" \\ \\_/ /    | |   | |         | |   | |   | || (\\ (      ) (   ", 'g');
                textManager.TextWriteLine("  \\   /  ___) (___| (____/\\   | |   | (___) || ) \\ \\__   | |   ", 'g');
                textManager.TextWriteLine("   \\_/   \\_______/(_______/   )_(   (_______)|/   \\__/   \\_/   ", 'g');
            }

            Console.ReadKey();
        }
    }
}
