using System;
using HorseRaceEmu.Commands.Abstractions;
using HorseRaceEmu.Helpers;
using HorseRaceEmu.Races;

namespace HorseRaceEmu.Commands
{
    public class StartRaceCommand : ConsoleCommand<HorseRace>
    {
        public StartRaceCommand() : base(new HotKey(ConsoleKey.R), "Start race")
        {
        }

        protected override void Body(HorseRace context)
        {
            ConsoleHelper.ColorWriteLine($"And the winner is {context.Start().Name}\n\n", ConsoleColor.Yellow);
            
        }

        public override bool CanRun(HorseRace context)
        {
            return context.CanStartRace;
        }
    }
}