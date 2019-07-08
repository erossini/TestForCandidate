using System;
using System.Linq;
using HorseRace;
using HorseRace.RaceLogic;
using NUnit.Framework;

namespace Tests
{
    //was used for debug, but i decided to not delete it
    [TestFixture]
    public class MarginCalculatorTests
    {
        [TestCase(new double[] {1}, ExpectedResult = 50)]
        [TestCase(new double[] {1, 1, 1}, ExpectedResult = 150)]
        [TestCase(new double[] {0.5, 2, 3, 8}, ExpectedResult = 136.11)]
        public double Calculate_ReturnsCorrectTotalMargin(double[] odds)
        {
            return MarginCalculator.Calculate(odds);
        }
    }
}