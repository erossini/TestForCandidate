using HorseRace.Models;
using System;
using System.Linq;
using Xunit;

namespace HorseRace.Tests
{
    public class HorseDataTests
    {
        readonly HorseData horseData;

        public HorseDataTests() =>
            horseData = new HorseData();
        [Fact]
        public void RaceMarginTest()
        {
            //arrange

            decimal result = (from h in horseData.horses
                              let margin = Decimal.Divide(100M, Decimal.Divide(h.Winning, h.Stake) + 1)
                              select margin).Sum();

            //act
            decimal actual = horseData.RaceMargin();

            //assert
            Assert.Equal(result, actual);
        }

       
    }
}
