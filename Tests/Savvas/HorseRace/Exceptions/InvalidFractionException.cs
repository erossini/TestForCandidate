using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amdocs.HorseRace.Exceptions
{
    public class InvalidFractionException : Exception
    {
        public InvalidFractionException(string message) : base(message)
        {

        }
    }
}
