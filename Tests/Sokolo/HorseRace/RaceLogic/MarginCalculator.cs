using System;
using System.Linq;
using HorseRace.Extensions;

namespace HorseRace.RaceLogic
{
    public static class MarginCalculator
    {
        public static double Calculate(double[] odds)
        {
            var result = odds.Select(odd => odd.ToPercentageOdds()).Sum();
            return Math.Round(result, 2, MidpointRounding.AwayFromZero);
        }
    }
}