using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConnectFour
{
    public class Grid
    {
        private readonly int _gridWidth;
        private readonly int _gridHeight;
        private readonly Cell[,] _grid;

        public Grid(Cell[,] data, int width, int height)
        {
            _gridWidth = width;
            _gridHeight = height;
            _grid = data;
        }

        public string Stringify()
        {
            var lines = new List<string>();
            for (var y = _gridHeight - 1; y >= 0; y--)
            {
                var sb = new StringBuilder();

                for (var x = 0; x < _gridWidth; x++)
                {
                    switch (_grid[x, y])
                    {
                        case Cell.Unowned:
                            sb.Append("...");
                            break;
                        case Cell.Red:
                            sb.Append(".R.");
                            break;

                        case Cell.Blue:
                            sb.Append(".B.");
                            break;

                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }

                lines.Add(sb.ToString());
            }

            var result = "=====================\n" + lines.Aggregate("", (a, b) => a + b + Environment.NewLine) +
                         " 0  1  2  3  4  5  6 ";
            return result;
        }

        public Cell GetCellState(int x, int y)
        {
            return _grid[x, y];
        }

        public bool CanInsert(int x)
        {
            if (x >= _gridWidth || x < 0)
                return false;

            for (var y = 0; y < _gridHeight; y++)
                if (_grid[x, y] == Cell.Unowned)
                    return true;

            return false;
        }

        public void Insert(int x, Cell cell)
        {
            if (!CanInsert(x))
                return;

            var y = GetYToInsert(x);

            _grid[x, y] = cell;
        }

        private int GetYToInsert(int x)
        {
            for (var y = 0; y < _gridHeight; y++)
                if (_grid[x, y] == Cell.Unowned)
                    return y;

            return -1;
        }

        public Winner GetWinner()
        {
            for (var x = 0; x < _gridWidth; x++)
            {
                for (var y = 0; y < _gridHeight; y++)
                {
                    var verticalWinner = TryGetVerticalWinnerFrom(x, y);
                    if (verticalWinner != Winner.NoWinner)
                        return verticalWinner;

                    var horizontalWinner = TryGetHorizontalWinnerFrom(x, y);
                    if (horizontalWinner != Winner.NoWinner)
                        return horizontalWinner;

                    var diagonalWinner = TryGetDiagonalWinnerFrom(x, y);
                    if (diagonalWinner != Winner.NoWinner)
                        return diagonalWinner;

                    var diagonalBackWinner = TryGetBackDiagonalWinnerFrom(x, y);
                    if (diagonalBackWinner != Winner.NoWinner)
                        return diagonalBackWinner;

                    if (IsDraw())
                        return Winner.Friendship;
                }
            }

            return Winner.NoWinner;
        }

        private bool IsDraw()
        {
            return _grid.Cast<Cell>().All(c => c != Cell.Unowned);
        }

        private Winner TryGetVerticalWinnerFrom(int x, int y)
        {
            var currentCell = _grid[x, y];

            if (currentCell == Cell.Unowned)
                return Winner.NoWinner;

            for (var y2 = y; y2 <= y + 3; y2++)
            {
                if (y2 >= _gridHeight)
                    return Winner.NoWinner;

                if (_grid[x, y2] != currentCell)
                    return Winner.NoWinner;
            }

            return currentCell.ToWinner();
        }

        private Winner TryGetHorizontalWinnerFrom(int x, int y)
        {
            var currentCell = _grid[x, y];

            if (currentCell == Cell.Unowned)
                return Winner.NoWinner;

            for (var x2 = x; x2 <= x + 3; x2++)
            {
                if (x2 >= _gridWidth)
                    return Winner.NoWinner;

                if (_grid[x2, y] != currentCell)
                    return Winner.NoWinner;
            }

            return currentCell.ToWinner();
        }

        private Winner TryGetDiagonalWinnerFrom(int x, int y)
        {
            var currentCell = _grid[x, y];

            if (currentCell == Cell.Unowned)
                return Winner.NoWinner;

            for (var index = 0; index <= 3; index++)
            {
                var x2 = x + index;
                var y2 = y + index;

                if (x2 >= _gridWidth || y2 >= _gridHeight)
                    return Winner.NoWinner;

                if (_grid[x2, y2] != currentCell)
                    return Winner.NoWinner;
            }

            return currentCell.ToWinner();
        }

        private Winner TryGetBackDiagonalWinnerFrom(int x, int y)
        {
            var currentCell = _grid[x, y];

            if (currentCell == Cell.Unowned)
                return Winner.NoWinner;

            for (var index = 0; index <= 3; index++)
            {
                var x2 = x - index;
                var y2 = y + index;

                if (x2 < 0 || y2 >= _gridHeight)
                    return Winner.NoWinner;

                if (_grid[x2, y2] != currentCell)
                    return Winner.NoWinner;
            }

            return currentCell.ToWinner();
        }
    }
}