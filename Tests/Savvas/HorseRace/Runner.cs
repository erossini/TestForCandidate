using Amdocs.HorseRace.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amdocs.HorseRace
{
    public class Runner : IRunner
    {
        private readonly string _name;
        private readonly Fraction _fraction;

        public Runner(string name, Fraction fraction)
        {
            _name = name;
            _fraction = fraction;
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public decimal FractionalOdd
        {
            get
            {
                return _fraction.ToDecimal();
            }
        }

        public decimal DecimalOdd
        {
            get
            {
                return FractionalOdd + 1;
            }
        }

        public decimal Margin
        {
            get
            {
                return Math.Round(100 / DecimalOdd, 2);
            }
        }

        public decimal WinningPercentage { get; set; }

        public void CalculateWinningPercentage(decimal runnerMargin, decimal raceMargin)
        {
            WinningPercentage = Math.Round((runnerMargin / raceMargin) * 100, 2);
        }
    }
}
