using System;
using HorseRace.RaceLogic;

namespace HorseRace.Commands
{
    public class CreateRaceCommand : ICommand
    {
        public CreateRaceCommand(string[] args)
        {
        }

        public void Execute()
        {
            RaceSingleton.Instance.Reset();
            Console.WriteLine("New race created!");
            Console.WriteLine("Now you can add participants by using command AddParticipant <Name> <Odd>");
        }
    }
}