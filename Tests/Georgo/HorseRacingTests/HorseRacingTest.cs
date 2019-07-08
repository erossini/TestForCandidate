using Microsoft.VisualStudio.TestTools.UnitTesting;
using HorseRacing;
using System.Collections.Generic;

namespace HorseRacingTests
{
    [TestClass]
    public class HorseRacingTest
    {
        [TestMethod]
        public void WinningPercent()
        {
            List<Runner> runners = new List<Runner>();
            Runner Runner1 = new Runner();
            Runner1.SetName("kostas");
            Runner1.SetOdds("1/2");
            runners.Add(Runner1);

            Runner Runner2 = new Runner();
            Runner2.SetName("Giorgos");
            Runner2.SetOdds("2/1");
            runners.Add(Runner2);

            Runner Runner3 = new Runner();
            Runner3.SetName("Nikos");
            Runner3.SetOdds("3/1");
            runners.Add(Runner3);

            Runner Runner4 = new Runner();
            Runner4.SetName("Takis");
            Runner4.SetOdds("8/1");
            runners.Add(Runner4);

            Runner winner = new Runner();

           
                foreach (var runner in runners)
                {
                    runner.Chance = Helpers.RunnersChance(runner, Helpers.CalculateMargin(runners));
                    
                }
            winner = Helpers.CalculateWinner(runners);
            Assert.AreEqual(Runner1, winner);
            
           
        }

        [TestMethod]
        public void TestForManyIterations()
        {
            int succeeded = 0;
            int failed = 0;
            for (int i = 1; i <= 1000000; i++)
            {
                try
                {
                    WinningPercent();
                    succeeded++;
                }
                catch
                {
                    
                    failed++;
                }
               
            }

            Assert.IsTrue(succeeded >= 460000 && succeeded <= 500000);
        }

    }
}
