using HorseRace.Extensions;
using HorseRace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace HorseRace.Tests
{
    public class FractionalConvertionTest
    {
        readonly HorseData horseData;
        readonly FractionalConvertion fractionalConvertion;
        public FractionalConvertionTest()
        {
            fractionalConvertion = new FractionalConvertion();
            horseData = new HorseData();
        }
        [Fact]
        public void FractionToDecimalTest()
        {
            // arrange
            decimal result = 0;
            decimal actual = 0;
            var query = from h in horseData.horses
                        select new { Odds = h.Winning / h.Stake + 1 };
            foreach (var item in query)
                result = item.Odds;
            // act
            foreach (var item in horseData.horses)
                actual = fractionalConvertion.FractionToDecimal(item.Winning, item.Stake);

            //asert
            Assert.Equal(result, actual);
        }

        [Fact]
        public void StringToFraction()
        {
            //arrange
            string result = "";
            string actual = "";
            foreach (var h in horseData.horses)
            {
                result = h.Winning.ToString() + "/" + h.Stake.ToString();
            }

            //action
            foreach (var h in horseData.horses)
            {
                actual = fractionalConvertion.StringFraction(h.Winning, h.Stake);
            }

            //assert
            Assert.Equal(result, actual);
        }

    }
}
