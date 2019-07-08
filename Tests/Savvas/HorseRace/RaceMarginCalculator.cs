using Amdocs.HorseRace.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amdocs.HorseRace
{
    public class RaceMarginCalculator : IRaceMarginCalculator
    {
        public decimal Calculate(IRunner[] runners)
        {
            var margin = 0m;
            foreach (var runner in runners)
            {
                margin += runner.Margin;
            }
            return margin;
        }
    }
}
