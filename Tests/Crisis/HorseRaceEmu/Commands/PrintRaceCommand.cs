using System;
using HorseRaceEmu.Commands.Abstractions;
using HorseRaceEmu.Helpers;
using HorseRaceEmu.Races;

namespace HorseRaceEmu.Commands
{
    public class PrintRaceInfo : ConsoleCommand<HorseRace>
    {
        public PrintRaceInfo() : base(new HotKey(ConsoleKey.P), "Prints race information")
        {
        }

        protected override void Body(HorseRace context)
        {
            ConsoleHelper.ColorWriteLine(context.ToString(), ConsoleColor.Blue);
        }

        public override bool CanRun(HorseRace context)
        {
            return true;
        }
    }
}