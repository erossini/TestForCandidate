using NUnit.Framework;

namespace ConnectFour.Tests
{
    public class GridTests
    {
        private static Grid CreateGrid()
        {
            return new Grid(new Cell[7, 6], 7, 6);
        }

        [Test]
        public void InitializedWithAllUnownedCells(
            [Values(0, 1, 2, 3, 4, 5, 6)] int x,
            [Values(0, 1, 2, 3, 4, 5)] int y)
        {
            var grid = CreateGrid();

            Assert.AreEqual(Cell.Unowned, grid.GetCellState(x, y));
        }

        [Test]
        public void AllowsToInsertValuesForEachColumnOfNewGrid(
            [Values(0, 1, 2, 3, 4, 5, 6)] int x)
        {
            var grid = CreateGrid();

            Assert.True(grid.CanInsert(x));
        }

        [TestCase(-1)]
        [TestCase(7)]
        [TestCase(8)]
        public void CanNotAddTokenOutsideTheBoundsOfAGrid(int x)
        {
            var grid = CreateGrid();

            Assert.False(grid.CanInsert(x));
        }

        [Test]
        public void FillsOneColumnToTheTop(
            [Values(0, 1, 2, 3, 4, 5, 6)] int x)
        {
            var grid = CreateGrid();

            Assert.True(grid.CanInsert(x));

            Helper.InvokeSixTimes(() => grid.Insert(x, Cell.Blue));

            Assert.False(grid.CanInsert(x));
        }

        [Test]
        public void HasCorrectCellTypesForAllColumnCellsAfterFillsOneColumnToTheTop(
            [Values(0, 1, 2, 3, 4, 5, 6)] int x,
            [Values(Cell.Blue, Cell.Red)] Cell cell)
        {
            var grid = CreateGrid();

            Helper.InvokeSixTimes(() => grid.Insert(x, cell));

            for (var y = 0; y < 6; y++)
            {
                Assert.AreEqual(cell, grid.GetCellState(x, y));
            }
        }

        [TestCaseSource(typeof(GridTestCases), nameof(GridTestCases.GetGridNoWinnerCases))]
        public void HasNoWinner(Grid grid)
        {
            Assert.AreEqual(Winner.NoWinner, grid.GetWinner());
        }

        [TestCaseSource(typeof(GridTestCases), nameof(GridTestCases.GetGridVerticalRedWinnerCases))]
        public void HasRedVerticalWinner(Grid grid)
        {
            Assert.AreEqual(Winner.Red, grid.GetWinner());
        }

        [TestCaseSource(typeof(GridTestCases), nameof(GridTestCases.GetGridVerticalBlueWinnerCases))]
        public void HasBlueVerticalWinner(Grid grid)
        {
            Assert.AreEqual(Winner.Blue, grid.GetWinner());
        }

        [TestCaseSource(typeof(GridTestCases), nameof(GridTestCases.GetGridHorizontalRedWinnerCases))]
        public void HasRedHorizontalWinner(Grid grid)
        {
            Assert.AreEqual(Winner.Red, grid.GetWinner());
        }

        [TestCaseSource(typeof(GridTestCases), nameof(GridTestCases.GetGridHorizontalBlueWinnerCases))]
        public void HasBlueHorizontalWinner(Grid grid)
        {
            Assert.AreEqual(Winner.Blue, grid.GetWinner());
        }

        [TestCaseSource(typeof(GridTestCases), nameof(GridTestCases.GetGridDiagonalRedWinnerCases))]
        public void HasBlueDiagonalWinner(Grid grid)
        {
            Assert.AreEqual(Winner.Red, grid.GetWinner());
        }

        [TestCaseSource(typeof(GridTestCases), nameof(GridTestCases.GetGridDiagonalBlueWinnerCases))]
        public void HasRedDiagonalWinner(Grid grid)
        {
            Assert.AreEqual(Winner.Blue, grid.GetWinner());
        }

        [TestCaseSource(typeof(GridTestCases), nameof(GridTestCases.GetGridBackDiagonalRedWinnerCases))]
        public void HasRedBackDiagonalWinner(Grid grid)
        {
            Assert.AreEqual(Winner.Red, grid.GetWinner());
        }

        [TestCaseSource(typeof(GridTestCases), nameof(GridTestCases.GetGridBackDiagonalBlueWinnerCases))]
        public void HasBlueBackDiagonalWinner(Grid grid)
        {
            Assert.AreEqual(Winner.Blue, grid.GetWinner());
        }

        [Test]
        public void HasFriendship()
        {
            const Cell b = Cell.Blue;
            const Cell r = Cell.Red;
            var grid = new Grid(new[,]
            {
                {r, r, b, b, r, r},
                {b, b, r, r, b, b},
                {r, r, b, b, r, r},
                {b, b, r, r, b, b},
                {r, r, b, b, r, r},
                {b, b, r, r, b, b},
                {r, r, b, b, r, r},
            }, 7, 6);

            Assert.AreEqual(Winner.Friendship, grid.GetWinner());
        }

        [Test]
        public void HasFriendshipAnother()
        {
            const Cell b = Cell.Blue;
            const Cell r = Cell.Red;
            var grid = new Grid(new[,]
            {
                {r, r, b, r, b, r},
                {b, b, r, b, r, b},
                {r, r, b, r, b, r},
                {b, r, b, r, b, r},
                {b, b, r, b, r, b},
                {r, r, b, b, r, b},
                {b, r, b, r, r, b}
            }, 7, 6);


            Assert.AreEqual(Winner.Friendship, grid.GetWinner());
        }
    }
}