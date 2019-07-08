using System;
using System.Text.RegularExpressions;
using HorseRace.RaceLogic;

namespace HorseRace.Commands
{
    public class AddParticipantCommand : ICommand
    {
        private readonly string[] _args;

        public AddParticipantCommand(string[] args)
        {
            _args = args;
        }

        public void Execute()
        {
            if (_args.Length != 2)
            {
                Console.WriteLine("Invalid parameters count");
                return;
            }

            if (!ValidateNameOfParticipant(_args[0]))
            {
                Console.WriteLine("Incorrect name");
                Console.WriteLine("Name should be maximum of 18 characters long (A-Z only including spaces)");
                return;
            }

            if (!ValidateOddsOfParticipant(_args[1]))
            {
                Console.WriteLine("Incorrect odds");
                Console.WriteLine(
                    "Odds should be in UK fractional format X/Y where X,Y are integer numbers greater than 1");
                return;
            }

            var participant = new Participant(_args[0], _args[1]);
            RaceSingleton.Instance.AddParticipant(participant);
            Console.WriteLine($"Participant {participant.Name} added");
        }

        private bool ValidateNameOfParticipant(string name)
        {
            Regex regexNamePattern = new Regex("^[a-zA-Z ]{1,18}$");
            if (!regexNamePattern.IsMatch(name))
                return false;
            return true;
        }

        private bool ValidateOddsOfParticipant(string odd)
        {
            Regex regexOddPattern = new Regex(@"^[1-9][0-9]*\/[1-9][0-9]*$");
            if (!regexOddPattern.IsMatch(odd))
                return false;
            return true;
        }
    }
}