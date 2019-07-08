namespace HorseRace.Exceptions
{
    public class TotalMarginOverloadException : HorseRaceExceptionBase
    {
        public TotalMarginOverloadException() : base("Total margin can't be more than 140%")
        {
        }
    }
}