using System;
using System.Collections.Generic;
using HorseRace;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProjectRace
{
    [TestClass]
    public class UnitTestHorceRace
    {
        [TestMethod]
        public void TestMethodRunRace()
        {
            int iterations = 1000000;


            Race r = new Race()
            {
                Runners = new List<Runner>() {
                    { new Runner("Test A", 1, 2) },
                    {new Runner("Test B", 2, 1)},
                    {new Runner("Test C", 3, 1)},
                    {new Runner("Test D", 8, 1)},
                }
            };

            for (int i = 0; i < iterations; i++)
            {
                r.RunRace(displayWinners: false);

            }

            
            Assert.IsTrue(r.Runners[3].winCount >= 460000 && r.Runners[0].winCount <= 500000);
        }
    }
}
