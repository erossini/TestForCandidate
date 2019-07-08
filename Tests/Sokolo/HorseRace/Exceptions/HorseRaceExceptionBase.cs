using System;

namespace HorseRace.Exceptions
{
    public class HorseRaceExceptionBase : Exception
    {
        public HorseRaceExceptionBase(string message)
            : base(message)
        {
        }
    }
}