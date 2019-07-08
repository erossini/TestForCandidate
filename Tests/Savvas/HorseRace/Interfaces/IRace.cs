using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amdocs.HorseRace.Interfaces
{
    public interface IRace
    {
        decimal CalculateRaceMargin();
        void CalculateRunnersWinningPercentage();
        IRunner PickWinner(int randomNum);
    }
}
