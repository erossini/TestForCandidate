using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using HorseRaceEmu.Helpers;

namespace HorseRaceEmu.Horses
{
    public class HorseCollection : IEnumerable<Horse>
    {
        private Horse[] _horses;

        public HorseCollection()
        {
            _horses = new Horse[0];
        }

        public double Margin => _horses.Aggregate(0d, (margin, horse) => margin + horse.Margin);

        public bool CanAddHorse => _horses.Length < 16;

        public IEnumerator<Horse> GetEnumerator()
        {
            for (var i = 0; i < _horses.Length; i++)
                if (i == 0)
                {
                    var horse = _horses[i];
                    horse.From = 0;
                    horse.To = horse.Margin / Margin;

                    yield return horse;
                }
                else
                {
                    var prev = _horses[i - 1];
                    var horse = _horses[i];

                    horse.From = prev.To + double.Epsilon;
                    horse.To = horse.From + horse.Margin / Margin;

                    yield return horse;
                }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool ContainsName(string name)
        {
            return _horses.Any(h => h.Name.Equals(name));
        }

        public ValidationResult Add(Horse horse)
        {
            if (_horses.Any(h => h.Name.Equals(horse.Name)))
                return ValidationResult.Invalid("Horse with the same name already exists.");

            if (_horses.Length == 16)
                return ValidationResult.Invalid("Cant add more horses. Only 16 horses are allowed");

            Array.Resize(ref _horses, _horses.Length + 1);
            _horses[_horses.Length - 1] = horse;
            return ValidationResult.Valid();
        }
    }
}