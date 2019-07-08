using Amdocs.HorseRace.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amdocs.HorseRace
{
    public class Race : IRace
    {
        private readonly IRunner[] _runners;
        private readonly IRaceMarginCalculator _raceMarginCalculator;
        public Race(IRunner[] runners, IRaceMarginCalculator raceMarginCalculator)
        {
            _runners = runners;
            _raceMarginCalculator = raceMarginCalculator;
        }

        public decimal CalculateRaceMargin()
        {
            return _raceMarginCalculator.Calculate(_runners);
        }

        public void CalculateRunnersWinningPercentage()
        {
            var raceMargin = _raceMarginCalculator.Calculate(_runners);
            foreach (var runner in _runners)
            {
                runner.CalculateWinningPercentage(runner.Margin, raceMargin);
            }
        }

        public IRunner PickWinner(int randomNum)
        {
            IRunner[] sortedRunners = _runners.OrderByDescending(r => r.WinningPercentage)
                                              .ToArray();

            IRunner winner = null;
            decimal cumulativeProb = 0m;
            foreach (var runner in sortedRunners)
            {
                cumulativeProb += runner.WinningPercentage;
                if (randomNum < cumulativeProb || randomNum > 99.90)
                {
                    winner = runner;
                    break;
                }
            }

            return winner;
        }
    }
}
