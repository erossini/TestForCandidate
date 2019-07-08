using System;
using System.Collections.Generic;
using System.Linq;

namespace HorseRace.Commands
{
    public class HelpCommand : ICommand
    {
        private readonly string[] _args;

        private readonly Dictionary<string, string> _helpMap =
            new Dictionary<string, string>
            {
                {
                    "createrace",
                    $"CreateGame command{Environment.NewLine}" +
                    $"Creating/resetting game{Environment.NewLine}" +
                    $"Usage: CreateGame{Environment.NewLine}"

                },
                {
                    "addparticipant",
                    $"AddParticipant command {Environment.NewLine}" +
                    $"Adding new participants to the game{Environment.NewLine}" +
                    $"Usage: AddParticipant <name> <odds>{Environment.NewLine}" +
                    $"Each name should be maximum of 18 characters long (A-Z only including spaces){Environment.NewLine}" +
                    $"Odds should be in UK fractional format X/Y where X,Y are integer numbers greater than 1{Environment.NewLine}"
                },
                {
                    "beginrace",
                    $"BeginRace command {Environment.NewLine}" +
                    $"Starting current race and printing final result{Environment.NewLine}" +
                    $"Usage: BeginRace{Environment.NewLine}"
                },
                {
                    "help",
                    $"HelpCommand command {Environment.NewLine}" +
                    $"Provides info about any available command{Environment.NewLine}" +
                    $"Usage:  Help <command>{Environment.NewLine}"
                },
                {
                    "wrong",
                    $"Wrong command usage{Environment.NewLine}"
                },
                {
                    "info",
                    $"This app provided to emulate horse race competition{Environment.NewLine}" +
                    $"Available commands: {string.Join(", ", Enum.GetNames(typeof(CommandKeys)))}{Environment.NewLine}" +
                    $"To get help about any command use: help <command>"
                },
            };

        public HelpCommand(string[] args)
        {
            _args = args;
        }

        public void Execute()
        {
            var command = _args.FirstOrDefault()?.ToLower();
            var helpText = _helpMap.ContainsKey(command) ? _helpMap[command] : _helpMap["wrong"];

            Console.WriteLine(helpText);
        }
    }
}