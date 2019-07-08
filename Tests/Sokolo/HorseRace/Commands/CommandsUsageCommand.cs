using System;

namespace HorseRace.Commands
{
    public class CommandsUsageCommand : ICommand
    {

        public CommandsUsageCommand()
        {
        }

        public void Execute()
        {
            Console.WriteLine("Command not specified or unknown command.");
            Console.WriteLine("Usage: <command> [arguments]");
            Console.WriteLine($"Available commands: {string.Join(", ", Enum.GetNames(typeof(CommandKeys)))}");
            Console.WriteLine("For getting command help use help <Command>");
        }
    }
}