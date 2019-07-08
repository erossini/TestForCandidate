namespace HorseRace.Extensions
{
    public static class DecimalExtensions
    {
        public static double ToPercentageOdds(this double UKOdds)
        {
            return 100D / (UKOdds + 1);
        }
    }
}