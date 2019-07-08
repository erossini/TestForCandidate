using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HorseRace;
using NUnit.Framework;
using RunnersGamblingGame;

namespace HorseRaceTest
{
    [TestFixture]
    public class RaceWinnerCreatorTest
    {
        [Test]
        public void GetRaceWinner_WinningRate_IsValid()
        {
            int numberOfPlays = 1000000;
            var maxMargin = 136.1;

            IRaceConfiguration RaceConfiguration = new HorseRaceConfiguration();
            var creator = new RaceWinnerCreator(RaceConfiguration);
            Dictionary<string, int> winsCounter = new Dictionary<string, int>();

            RaceConfiguration.AddRunner("A", "1/2");
            winsCounter.Add("A", 0);

            RaceConfiguration.AddRunner("B", "2/1");
            winsCounter.Add("B", 0);

            RaceConfiguration.AddRunner("C", "3/1");
            winsCounter.Add("C", 0);

            RaceConfiguration.AddRunner("D", "8/1");
            winsCounter.Add("D", 0);

            RaceConfiguration.GetMaxWinningMargin();

            for (int i = 0; i < numberOfPlays; i++)
            {
                var winner = creator.GetRaceWinner();
                winsCounter[winner.RunnerName] += 1;
            }

            foreach (var runner in RaceConfiguration.GetRunners())
            {
                var winRateForGivenRunner = ((100 / runner.FractionalValue) / maxMargin);

                var expectedWins = (int)(winRateForGivenRunner * numberOfPlays);

                var IsTheWinningRateValid = winsCounter[runner.RunnerName] < expectedWins + 0.02 * expectedWins &&
                    winsCounter[runner.RunnerName] > expectedWins - 0.02 * expectedWins;

                Assert.IsTrue(IsTheWinningRateValid);
 
            }

        }
    }
}
