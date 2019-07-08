using System;
using HorseRace.Exceptions;
using HorseRace.RaceLogic;

namespace HorseRace.Commands
{
    public class BeginRaceCommand : ICommand
    {
        public BeginRaceCommand(string[] args)
        {
        }

        public void Execute()
        {
            try
            {
                var result = RaceSingleton.Instance.DoRace();
                Console.WriteLine($"Winner: {result.Name}");
            }
            catch (HorseRaceExceptionBase e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Race can't be started");
            }
        }
    }
}