using System;
using System.Collections.Generic;
using System.Linq;
using HorseRace.Commands;

namespace HorseRace.Commands
{
    public interface ICommandFactory
    {
        ICommand Create(string[] args);
    }

    public class CommandFactory : ICommandFactory
    {
        private readonly Dictionary<CommandKeys, Func<string[], ICommand>> commandMap =
            new Dictionary<CommandKeys, Func<string[], ICommand>>
            {
                {
                    CommandKeys.CreateRace, args => new CreateRaceCommand(args)
                },
                {
                    CommandKeys.AddParticipant, args => new AddParticipantCommand(args)
                },
                {
                    CommandKeys.BeginRace, args => new BeginRaceCommand(args)
                },
                {
                    CommandKeys.Help, args => new HelpCommand(args)
                },
            };

        public ICommand Create(string[] args)
        {
            if (args.Length == 0)
                return new CommandsUsageCommand();
            
            if (!Enum.TryParse(args.First(), true, out CommandKeys commandKey))
            {
                return new CommandsUsageCommand();
            }
            
            if (!commandMap.ContainsKey(commandKey))
                return new CommandsUsageCommand();

            return commandMap[commandKey](args.Skip(1).ToArray());
        }
    }
}