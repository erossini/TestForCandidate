using HorseRaceEmu.Commands;
using HorseRaceEmu.Races;

namespace HorseRaceEmu
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            var race = new HorseRace();

            new Menu<HorseRace>()
                .AddCommand(new PrintRaceInfo())
                .AddCommand(new AddHorseCommand())
                .AddCommand(new StartRaceCommand())
                .Run(race);
        }
    }
}