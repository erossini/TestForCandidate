using System.Collections.Generic;

namespace ConnectFour.Tests
{
    public class GridTestCases
    {
        public static IEnumerable<Grid> GetGridVerticalRedWinnerCases()
        {
            return GetGridVerticalWinnerCases(Cell.Red);
        }

        public static IEnumerable<Grid> GetGridVerticalBlueWinnerCases()
        {
            return GetGridVerticalWinnerCases(Cell.Blue);
        }

        private static IEnumerable<Grid> GetGridVerticalWinnerCases(Cell c)
        {
            const Cell u = Cell.Unowned;
            yield return new Grid(new[,]
            {
                {c, c, c, c, u, u},
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
            }, 7, 6);

            yield return new Grid(new[,]
            {
                {u, u, u, u, u, u},
                {u, c, c, c, c, u},
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
            }, 7, 6);

            yield return new Grid(new[,]
            {
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
                {u, u, c, c, c, c},
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
            }, 7, 6);

            yield return new Grid(new[,]
            {
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
                {u, u, c, c, c, c},
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
            }, 7, 6);

            yield return new Grid(new[,]
            {
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
                {u, c, c, c, c, u},
                {u, u, u, u, u, u},
            }, 7, 6);

            yield return new Grid(new[,]
            {
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
                {c, c, c, c, u, u},
            }, 7, 6);

            yield return new Grid(new[,]
            {
                {u, u, u, u, u, u},
                {u, u, c, c, c, c},
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
            }, 7, 6);

            yield return new Grid(new[,]
            {
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
                {u, c, c, c, c, u},
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
            }, 7, 6);

            yield return new Grid(new[,]
            {
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
                {c, c, c, c, u, u},
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
            }, 7, 6);

            yield return new Grid(new[,]
            {
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
                {u, c, c, c, c, u},
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
            }, 7, 6);

            yield return new Grid(new[,]
            {
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
                {u, u, c, c, c, c},
                {u, u, u, u, u, u},
            }, 7, 6);
        }

        public static IEnumerable<Grid> GetGridHorizontalRedWinnerCases()
        {
            return GetGridHorizontalWinnerCases(Cell.Red);
        }

        public static IEnumerable<Grid> GetGridHorizontalBlueWinnerCases()
        {
            return GetGridHorizontalWinnerCases(Cell.Blue);
        }

        private static IEnumerable<Grid> GetGridHorizontalWinnerCases(Cell c)
        {
            const Cell u = Cell.Unowned;
            yield return new Grid(new[,]
            {
                {c, u, u, u, u, u},
                {c, u, u, u, u, u},
                {c, u, u, u, u, u},
                {c, u, u, u, u, u},
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
            }, 7, 6);

            yield return new Grid(new[,]
            {
                {u, u, u, u, u, u},
                {u, c, u, u, u, u},
                {u, c, u, u, u, u},
                {u, c, u, u, u, u},
                {u, c, u, u, u, u},
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
            }, 7, 6);

            yield return new Grid(new[,]
            {
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
                {u, u, c, u, u, u},
                {u, u, c, u, u, u},
                {u, u, c, u, u, u},
                {u, u, c, u, u, u},
                {u, u, u, u, u, u},
            }, 7, 6);

            yield return new Grid(new[,]
            {
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
                {u, u, u, c, u, u},
                {u, u, u, c, u, u},
                {u, u, u, c, u, u},
                {u, u, u, c, u, u},
            }, 7, 6);

            yield return new Grid(new[,]
            {
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
                {u, u, u, u, c, u},
                {u, u, u, u, c, u},
                {u, u, u, u, c, u},
                {u, u, u, u, c, u},
                {u, u, u, u, u, u},
            }, 7, 6);

            yield return new Grid(new[,]
            {
                {u, u, u, u, u, u},
                {u, u, u, u, u, c},
                {u, u, u, u, u, c},
                {u, u, u, u, u, c},
                {u, u, u, u, u, c},
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
            }, 7, 6);

            yield return new Grid(new[,]
            {
                {u, u, u, u, u, c},
                {u, u, u, u, u, c},
                {u, u, u, u, u, c},
                {u, u, u, u, u, c},
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
            }, 7, 6);

            yield return new Grid(new[,]
            {
                {u, u, u, u, u, u},
                {u, u, u, u, c, u},
                {u, u, u, u, c, u},
                {u, u, u, u, c, u},
                {u, u, u, u, c, u},
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
            }, 7, 6);

            yield return new Grid(new[,]
            {
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
                {u, u, u, c, u, u},
                {u, u, u, c, u, u},
                {u, u, u, c, u, u},
                {u, u, u, c, u, u},
                {u, u, u, u, u, u},
            }, 7, 6);


            yield return new Grid(new[,]
            {
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
                {u, u, c, u, u, u},
                {u, u, c, u, u, u},
                {u, u, c, u, u, u},
                {u, u, c, u, u, u},
            }, 7, 6);

            yield return new Grid(new[,]
            {
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
                {u, c, u, u, u, u},
                {u, c, u, u, u, u},
                {u, c, u, u, u, u},
                {u, c, u, u, u, u},
                {u, u, u, u, u, u},
            }, 7, 6);


            yield return new Grid(new[,]
            {
                {u, u, u, u, u, u},
                {c, u, u, u, u, u},
                {c, u, u, u, u, u},
                {c, u, u, u, u, u},
                {c, u, u, u, u, u},
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
            }, 7, 6);
        }

        public static IEnumerable<Grid> GetGridNoWinnerCases()
        {
            const Cell u = Cell.Unowned;
            const Cell b = Cell.Blue;
            const Cell r = Cell.Red;

            yield return new Grid(new[,]
            {
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
            }, 7, 6);

            yield return new Grid(new[,]
            {
                {b, r, u, u, u, u},
                {b, r, u, u, u, u},
                {b, r, b, r, u, u},
                {u, u, b, r, b, r},
                {u, u, b, r, b, r},
                {u, u, u, u, b, r},
                {u, u, u, u, u, u},
            }, 7, 6);

            yield return new Grid(new[,]
            {
                {b, b, b, u, u, u},
                {r, r, r, u, u, u},
                {u, b, b, b, u, u},
                {u, r, r, r, u, u},
                {u, u, u, b, b, b},
                {u, u, u, r, r, r},
                {u, u, u, u, u, u},
            }, 7, 6);

            yield return new Grid(new[,]
            {
                {b, u, u, u, u, u},
                {u, b, u, u, r, u},
                {u, r, b, r, u, r},
                {u, b, r, u, u, u},
                {u, u, u, u, b, u},
                {r, u, u, b, r, u},
                {u, u, b, u, u, r},
            }, 7, 6);
        }

        public static IEnumerable<Grid> GetGridDiagonalRedWinnerCases()
        {
            return GetGridDiagonalWinnerCases(Cell.Red);
        }

        public static IEnumerable<Grid> GetGridDiagonalBlueWinnerCases()
        {
            return GetGridDiagonalWinnerCases(Cell.Blue);
        }

        private static IEnumerable<Grid> GetGridDiagonalWinnerCases(Cell c)
        {
            const Cell u = Cell.Unowned;

            yield return new Grid(new[,]
            {
                {c, u, u, u, u, u},
                {u, c, u, u, u, u},
                {u, u, c, u, u, u},
                {u, u, u, c, u, u},
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
            }, 7, 6);

            yield return new Grid(new[,]
            {
                {u, u, u, u, u, u},
                {u, c, u, u, u, u},
                {u, u, c, u, u, u},
                {u, u, u, c, u, u},
                {u, u, u, u, c, u},
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
            }, 7, 6);

            yield return new Grid(new[,]
            {
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
                {u, u, c, u, u, u},
                {u, u, u, c, u, u},
                {u, u, u, u, c, u},
                {u, u, u, u, u, c},
                {u, u, u, u, u, u},
            }, 7, 6);

            yield return new Grid(new[,]
            {
                {u, u, c, u, u, u},
                {u, u, u, c, u, u},
                {u, u, u, u, c, u},
                {u, u, u, u, u, c},
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
            }, 7, 6);

            yield return new Grid(new[,]
            {
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
                {c, u, u, u, u, u},
                {u, c, u, u, u, u},
                {u, u, c, u, u, u},
                {u, u, u, c, u, u},
            }, 7, 6);
        }

        public static IEnumerable<Grid> GetGridBackDiagonalRedWinnerCases()
        {
            return GetGridBackDiagonalWinnerCases(Cell.Red);
        }

        public static IEnumerable<Grid> GetGridBackDiagonalBlueWinnerCases()
        {
            return GetGridBackDiagonalWinnerCases(Cell.Blue);
        }

        private static IEnumerable<Grid> GetGridBackDiagonalWinnerCases(Cell c)
        {
            const Cell u = Cell.Unowned;

            yield return new Grid(new[,]
            {
                {u, u, u, u, u, c},
                {u, u, u, u, c, u},
                {u, u, u, c, u, u},
                {u, u, c, u, u, u},
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
            }, 7, 6);

            yield return new Grid(new[,]
            {
                {u, u, u, u, u, u},
                {u, u, u, u, c, u},
                {u, u, u, c, u, u},
                {u, u, c, u, u, u},
                {u, c, u, u, u, u},
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
            }, 7, 6);

            yield return new Grid(new[,]
            {
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
                {u, u, u, c, u, u},
                {u, u, c, u, u, u},
                {u, c, u, u, u, u},
                {c, u, u, u, u, u},
                {u, u, u, u, u, u},
            }, 7, 6);

            yield return new Grid(new[,]
            {
                {u, u, u, c, u, u},
                {u, u, c, u, u, u},
                {u, c, u, u, u, u},
                {c, u, u, u, u, u},
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
            }, 7, 6);

            yield return new Grid(new[,]
            {
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
                {u, u, u, u, u, c},
                {u, u, u, u, c, u},
                {u, u, u, c, u, u},
                {u, u, c, u, u, u},
            }, 7, 6);

            yield return new Grid(new[,]
            {
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
                {u, u, u, u, u, u},
                {u, u, u, c, u, u},
                {u, u, c, u, u, u},
                {u, c, u, u, u, u},
                {c, u, u, u, u, u},
            }, 7, 6);
        }
    }
}