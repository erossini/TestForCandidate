using System;
using System.Collections.Generic;
using System.Linq;
using HorseRaceEmu.Commands.Abstractions;
using HorseRaceEmu.Helpers;

namespace HorseRaceEmu.Commands
{
    public class Menu<TContext>
    {
        private readonly List<ConsoleCommand<TContext>> _commands;
        private readonly HotKey _key;

        public Menu()
        {
            _key = new HotKey(ConsoleKey.X, ConsoleModifiers.Control);
            _commands = new List<ConsoleCommand<TContext>>();
        }

        public Menu<TContext> AddCommand(ConsoleCommand<TContext> command)
        {
            _commands.Add(command);

            return this;
        }

        public void Run(TContext context)
        {
            ConsoleKeyInfo key;

            Console.Clear();

            do
            {
                ConsoleHelper.ColorWriteLine("Commands list\n", ConsoleColor.Cyan);

                foreach (var command in _commands)
                {
                    if(command.CanRun(context)) ConsoleHelper.ColorWriteLine(command.ToString(), ConsoleColor.DarkCyan);
                    else ConsoleHelper.ColorWriteLine(command.ToString(), ConsoleColor.Gray);
                }
                    
                var availableCommands = _commands.Where(c => c.CanRun(context)).ToArray();

                ConsoleHelper.ColorWriteLine($"\n{_key} Stop application", ConsoleColor.DarkCyan);

                key = Console.ReadKey(true);

                Console.Clear();

                availableCommands.SingleOrDefault(c => c.Key.IsEqual(key))?.Run(context);
            } while (!_key.IsEqual(key));
        }
    }
}