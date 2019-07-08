using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amdocs.HorseRace
{
    public class RunnerAppearance
    {
        public RunnerAppearance(string name, int appearances)
        {
            Name = name;
            Appearances = appearances;
            WinningPercentage = 0;
        }

        public RunnerAppearance(string name, decimal winningPercentage, int appearances)
        {
            Name = name;
            WinningPercentage = winningPercentage;
            Appearances = appearances;
        }

        public string Name { get; set; }
        public decimal WinningPercentage { get; set; }
        public int Appearances { get; set; }
    }
}
