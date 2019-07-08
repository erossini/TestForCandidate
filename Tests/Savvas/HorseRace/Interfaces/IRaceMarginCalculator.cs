using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amdocs.HorseRace.Interfaces
{
    public interface IRaceMarginCalculator
    {
        decimal Calculate(IRunner[] runners);
    }
}
