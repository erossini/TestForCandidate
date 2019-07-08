using System;
using HorseRaceEmu.Commands.Abstractions;
using HorseRaceEmu.Helpers;
using HorseRaceEmu.Horses;
using HorseRaceEmu.Races;

namespace HorseRaceEmu.Commands
{
    public class AddHorseCommand : ConsoleCommand<HorseRace>
    {
        public AddHorseCommand() : base(new HotKey(ConsoleKey.A), "Add horse to race")
        {
        }

        protected override void Body(HorseRace context)
        {
            if (!context.CanAddHorse)
            {
                ConsoleHelper.ColorWriteLine("Can't add more horses. Max 16", ConsoleColor.Red);
                return;
            }

            var horse = new Horse();

            while (true)
            {
                var name = ConsoleHelper.UserInput("Horse name: ", ConsoleColor.Green);

                if (!context.HorseExists(name))
                {
                    var addNameResult = horse.AddName(name);


                    if (addNameResult)
                        break;

                    ConsoleHelper.ColorWriteLine(addNameResult.Message, ConsoleColor.Red);
                }
                else
                {
                    ConsoleHelper.ColorWriteLine("Horse with the same name already exists. Choose another.");
                }
            }

            while (true)
            {
                var addOddResult = horse.AddOdd(ConsoleHelper.UserInput("Odd price: ", ConsoleColor.Green));

                if (addOddResult)
                    break;

                ConsoleHelper.ColorWriteLine(addOddResult.Message, ConsoleColor.Red);
            }

            context.AddHorse(horse);
        }

        public override bool CanRun(HorseRace context)
        {
            return context.CanAddHorse;
        }
    }
}