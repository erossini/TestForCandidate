using System;

namespace HorseRace.RaceLogic
{
    public class RaceSingleton
    {
        private static readonly Lazy<Race> _lazy = new Lazy<Race>(() => new Race());

        public static Race Instance => _lazy.Value;
    }
}