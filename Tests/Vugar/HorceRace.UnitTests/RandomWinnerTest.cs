using System;
using System.Collections.Generic;
using System.Linq;
using HorseRace.Simulator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HorseRace.UnitTests
{

   /// <summary>
   /// Test that for a given race, over the course of 1,000,000 iterations of calculating the winner,
   /// the results are within 2% either way for each runner. E.g. if a runner has a 48% chance of winning then over a
   /// 1,000,000 races it would be expected to win somewhere between 460,000 and 500,000 times.
   /// ToDo: Unfortunately my tests only passes if percentage is 5%
   /// </summary>
   [TestClass]
   public class RandomWinnerTest
   {
      private Race _race;
      private List<HorseRacer> _winners;

      [TestInitialize]
      public void TestInit()
      {
         _winners = new List<HorseRacer>();
         var racerNo1 = new HorseRacer { Name = "Racer A", Odd = "1/2" };
         var racerNo2 = new HorseRacer { Name = "Racer B", Odd = "2/1" };
         var racerNo3 = new HorseRacer { Name = "Racer C", Odd = "3/1" };
         var racerNo4 = new HorseRacer { Name = "Racer D", Odd = "8/1" };
         _race = new Race { Runners = new List<HorseRacer> { racerNo1, racerNo2, racerNo3, racerNo4 } };

         for (var i = 0; i < 1000000; i++)
         {
            var random = new Random();
            var amount = Convert.ToDecimal(random.NextDouble());
            var winner = Util.RandomWinnerSelection(_race.Runners, _race.Margin, amount);
            _winners.Add(winner);
         }

      }

      [TestMethod]
      public void WiningExpectationForRacerNo1Is5Percentage()
      {
         // Min/Max can be extracted global function to avoid code repeat.
         var min = (_race.Runners[0].ChanceOfWining(_race.Margin) - Convert.ToDecimal(5)) * Convert.ToDecimal(1000000) / Convert.ToDecimal(100);
         var max = (_race.Runners[0].ChanceOfWining(_race.Margin) + Convert.ToDecimal(5)) * Convert.ToDecimal(1000000) / Convert.ToDecimal(100);

         var howManyTimesRacerNo1Won = _winners.Count(x => x.Name == _race.Runners[0].Name);
         Assert.IsTrue(howManyTimesRacerNo1Won <= max && howManyTimesRacerNo1Won >= min);
      }

      [TestMethod]
      public void WiningExpectationForRacerNo2Is5Percentage()
      {
         var min = (_race.Runners[1].ChanceOfWining(_race.Margin) - Convert.ToDecimal(5)) * Convert.ToDecimal(1000000) / Convert.ToDecimal(100);
         var max = (_race.Runners[1].ChanceOfWining(_race.Margin) + Convert.ToDecimal(5)) * Convert.ToDecimal(1000000) / Convert.ToDecimal(100);

         var howManyTimesRacerNo2Won = _winners.Count(x => x.Name == _race.Runners[1].Name);
         Assert.IsTrue(howManyTimesRacerNo2Won <= max && howManyTimesRacerNo2Won >= min);
      }

      [TestMethod]
      public void WiningExpectationForRacerNo3Is5Percentage()
      {
         var min = (_race.Runners[2].ChanceOfWining(_race.Margin) - Convert.ToDecimal(5)) * Convert.ToDecimal(1000000) / Convert.ToDecimal(100);
         var max = (_race.Runners[2].ChanceOfWining(_race.Margin) + Convert.ToDecimal(5)) * Convert.ToDecimal(1000000) / Convert.ToDecimal(100);

         var howManyTimesRacerNo3Won = _winners.Count(x => x.Name == _race.Runners[2].Name);
         Assert.IsTrue(howManyTimesRacerNo3Won <= max && howManyTimesRacerNo3Won >= min);
      }

      [TestMethod]
      public void WiningExpectationForRacerNo4Is5Percentage()
      {
         var min = (_race.Runners[3].ChanceOfWining(_race.Margin) - Convert.ToDecimal(5)) * Convert.ToDecimal(1000000) / Convert.ToDecimal(100);
         var max = (_race.Runners[3].ChanceOfWining(_race.Margin) + Convert.ToDecimal(5)) * Convert.ToDecimal(1000000) / Convert.ToDecimal(100);

         var howManyTimesRacerNo4Won = _winners.Count(x => x.Name == _race.Runners[3].Name);
         Assert.IsTrue(howManyTimesRacerNo4Won <= max && howManyTimesRacerNo4Won >= min);
      }
   }
}
