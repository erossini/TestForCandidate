using System;

namespace ConnectFour
{
    public class Program
    {
        private const int GridHeight = 6;
        private const int GridWidth = 7;

        public static void Main()
        {
            var grid = new Grid(new Cell[GridWidth, GridHeight], GridWidth, GridHeight);

            Console.WriteLine("\nWelcome to 'Connect Four' Game.\n\n");

            var currentPlayer = CurrentPlayer.Blue;

            while (true)
            {
                Console.WriteLine(grid.Stringify());
                Console.WriteLine($"{currentPlayer} player, please, input row number where you want drop the token:");

                var line = Console.ReadLine();
                if (!int.TryParse(line, out var parsedNumber))
                {
                    Console.WriteLine($"{currentPlayer} player inputs invalid value.");
                    continue;
                }

                if (!grid.CanInsert(parsedNumber))
                {
                    Console.WriteLine($"Row {parsedNumber} is full, drop the token to another row.");
                    continue;
                }

                grid.Insert(parsedNumber, currentPlayer.ToCell());
                var winner = grid.GetWinner();
                if (winner != Winner.NoWinner)
                {
                    Console.WriteLine($"\n\n\n{winner} is a winner!");
                    Console.WriteLine(grid.Stringify());

                    break;
                }

                currentPlayer = currentPlayer.GetNext();
            }
        }
    }
}