using System;
using System.Linq;
using System.Text;
using HorseRaceEmu.Helpers;
using HorseRaceEmu.Horses;

namespace HorseRaceEmu.Races
{
    public class HorseRace
    {
        public HorseRace()
        {
            Horses = new HorseCollection();
        }

        private HorseCollection Horses { get; }

        public double Margin => Horses.Margin;
        public bool CanAddHorse => Horses.CanAddHorse;
        public bool CanStartRace => Horses.Count() > 2 && Horses.Count() < 16 && Margin > 110d && Margin < 140d;

        public bool HorseExists(string name)
        {
            return Horses.ContainsName(name);
        }

        public ValidationResult AddHorse(Horse horse)
        {
            return Horses.Add(horse);
        }

        public Horse Start()
        {
            if(!CanStartRace)
                throw new InvalidOperationException("Cant start race. Not all conditions are met.");
            var rnd = new Random().NextDouble();

            return Horses.Single(h => h.From <= rnd && h.To >= rnd);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            if (Horses.Any())
                Horses.Aggregate(sb.Append($"Horses ({Horses.Count()} of 16):\n\n"),
                    (s, horse) => s.Append(horse.ToString()).Append("\n"));

            sb.Append("\n\nRace margin: ").Append(Margin.ToString("F")).Append("\n\n");

            return sb.ToString();
        }
    }
}