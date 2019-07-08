namespace HorseRace.Exceptions
{
    public class TotalMarginDeficitException : HorseRaceExceptionBase
    {
        public TotalMarginDeficitException() : base("Total margin can't be less than 110%")
        {
        }
    }
}