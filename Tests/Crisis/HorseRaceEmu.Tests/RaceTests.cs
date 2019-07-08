using System.Collections.Generic;
using HorseRaceEmu.Horses;
using HorseRaceEmu.Races;
using Xunit;

namespace HorseRaceEmu.Tests
{
    public class RaceTests
    {
        /// <summary>
        ///     Godlike test, contains at least 4 tests in one, should be more for every step: Create horse validations, add horse
        ///     to race, race validations,
        ///     race results
        /// </summary>
        [Fact]
        public void RunTest()
        {
            var race = new HorseRace();

            var winners = new Dictionary<Horse, int>();
            winners.Add(AddHorse(race, CreateHorse("FIRST", "1/2")), 1);
            winners.Add(AddHorse(race, CreateHorse("SECOND", "2/1")), 1);
            winners.Add(AddHorse(race, CreateHorse("THIRD", "3/1")), 1);
            winners.Add(AddHorse(race, CreateHorse("FOUR", "8/1")), 1);

            var raceCount = 1000000;

            for (var i = 0; i < raceCount; i++)
            {
                var winner = race.Start();
                winners[winner]++;
            }

            foreach (var winner in winners) AssertWinCount(winner.Key, winner.Value, race.Margin, raceCount);
        }

        #region Utilities

        private Horse AddHorse(HorseRace race, Horse horse)
        {
            var addResult = race.AddHorse(horse);
            Assert.True(addResult, addResult.Message);

            return horse;
        }

        private Horse CreateHorse(string name, string odd)
        {
            var horse = new Horse();

            var nameValidateResult = horse.AddName(name);

            Assert.True(nameValidateResult, nameValidateResult.Message);

            var oddValidateResult = horse.AddOdd(odd);

            Assert.True(oddValidateResult, oddValidateResult.Message);

            return horse;
        }

        private void AssertWinCount(Horse winner, int wins, double margin, int races)
        {
            var horseMediumValue = winner.Margin / margin * races;

            Assert.InRange(wins, horseMediumValue * 0.98d, horseMediumValue * 1.02d);
        }

        #endregion
    }
}