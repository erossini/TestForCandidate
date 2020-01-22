namespace ConnectFour
{
    public static class CurrentPlayerExtensions
    {
        public static CurrentPlayer GetNext(this CurrentPlayer currentPlayer)
        {
            return currentPlayer == CurrentPlayer.Blue ? CurrentPlayer.Red : CurrentPlayer.Blue;
        }

        public static Cell ToCell(this CurrentPlayer currentPlayer)
        {
            return currentPlayer == CurrentPlayer.Blue ? Cell.Blue : Cell.Red;
        }
    }
}