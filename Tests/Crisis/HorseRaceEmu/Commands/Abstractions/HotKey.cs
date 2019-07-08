using System;
using System.Text;

namespace HorseRaceEmu.Commands.Abstractions
{
    public class HotKey
    {
        public HotKey(ConsoleKey key, ConsoleModifiers modifiers = 0)
        {
            Key = key;
            Modifiers = modifiers;
        }

        public ConsoleKey Key { get; }
        public ConsoleModifiers Modifiers { get; }

        public bool IsEqual(ConsoleKeyInfo info)
        {
            return Key == info.Key && Modifiers == info.Modifiers;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            if (Modifiers != 0)
                sb.Append($"{Modifiers.ToString()} + ");

            sb.Append($"{Key.ToString()}");

            return sb.ToString();
        }
    }
}