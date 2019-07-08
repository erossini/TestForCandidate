using System;

namespace HorseRaceEmu.Helpers
{
    public static class ConsoleHelper
    {
        public static string UserInput(string message, ConsoleColor? foreground = null, ConsoleColor? background = null)
        {
            ColorWrite(message, foreground, background);
            return Console.ReadLine();
        }

        public static void ColorWriteLine(string message, ConsoleColor? foreground = null,
            ConsoleColor? background = null)
        {
            if (foreground.HasValue)
                Console.ForegroundColor = foreground.Value;

            if (background.HasValue)
                Console.BackgroundColor = background.Value;

            Console.WriteLine(message);

            Console.ResetColor();
        }

        public static void ColorWrite(string message, ConsoleColor? foreground = null, ConsoleColor? background = null)
        {
            if (foreground.HasValue)
                Console.ForegroundColor = foreground.Value;

            if (background.HasValue)
                Console.BackgroundColor = background.Value;

            Console.Write(message);

            Console.ResetColor();
        }
    }
}