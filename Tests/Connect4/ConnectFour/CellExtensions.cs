using System;

namespace ConnectFour
{
    public static class CellExtensions
    {
        public static Winner ToWinner(this Cell cell)
        {
            switch (cell)
            {
                case Cell.Unowned:
                    return Winner.NoWinner;
                case Cell.Red:
                    return Winner.Red;
                case Cell.Blue:
                    return Winner.Blue;
                default:
                    throw new ArgumentOutOfRangeException(nameof(cell), cell, null);
            }
        }
    }
}