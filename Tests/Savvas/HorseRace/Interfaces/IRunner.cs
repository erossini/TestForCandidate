using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amdocs.HorseRace.Interfaces
{
    public interface IRunner
    {
        string Name { get; }
        decimal FractionalOdd { get; }
        decimal DecimalOdd { get; }
        decimal Margin { get; }
        decimal WinningPercentage { get; set; }
        void CalculateWinningPercentage(decimal runnerMargin, decimal raceMargin);
    }
}
