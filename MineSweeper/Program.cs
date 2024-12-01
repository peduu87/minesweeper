namespace MineSweeper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("### WELCOME ###\n\nPeduu's Minesweeper V1.0\n\n");

            BoardManager boardManager = new BoardManager();

            boardManager.PrintBoard(boardManager.CreateEmptyViewBoard());

            Console.WriteLine("\nSelect a cell to start (line and column, example: 1A):");
            while (true)
            {
                string startingCoord = Console.ReadLine();

                if (boardManager.CheckCoordinates(startingCoord))
                {
                    char[,] mineBoard = boardManager.GenerateMineBoard(startingCoord);
                    boardManager.PrintBoard(mineBoard);
                }

                break;
            }
        }
    }
}
