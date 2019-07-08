using System;
using System.Collections.Generic;
using System.Linq;
using HorseRace;
using HorseRace.Commands;
using HorseRace.Extensions;
using HorseRace.RaceLogic;
using NUnit.Framework;

namespace Tests
{
    //Test from tsk test requirements
    [TestFixture]
    public class RaceTests
    {
        [TestCase(new double[] {0.5, 2, 3, 8})]
        public void PickWinner_UsesUniformDistribution(double[] odds)
        {
            var race = new Race();
            foreach (var odd in odds)
            {
                race.AddParticipant(new Participant(odd.ToString(), odd));
            }

            var winsCounts = odds.ToDictionary(el => el.ToString(), el => 0);
            foreach (var index in Enumerable.Range(1, 1000000))
            {
                var winner = race.DoRace();
                winsCounts[winner.Name]++;
            }

            var totalMargin = MarginCalculator.Calculate(odds);
            foreach (var odd in odds)
            {
                var finalWinningPercentage = winsCounts[odd.ToString()] / 10000D;
                var expectedPercentage = odd.ToPercentageOdds() / totalMargin * 100D;
                Assert.LessOrEqual(Math.Abs(finalWinningPercentage - expectedPercentage), 2D);
            }
        }
    }
}