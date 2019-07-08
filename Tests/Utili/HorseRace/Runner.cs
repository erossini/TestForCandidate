using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseRace
{
    public class Runner
    {
        private string _name;
        public int winCount;

        public Runner()
        {
            X = 1; Y = 1; // default values 
        }

        public Runner(string name, int x, int y)
        {
            Name = name; X = x; Y = y;

            if (y == 0 ) throw new ArgumentOutOfRangeException($"y must be greather than 0 ");
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (value.Length > 18 || value.Any(c => char.IsDigit(c)))
                    throw new ArgumentOutOfRangeException($"The length of '{nameof(value)}' must be maximum 18 characters long (A-Z only including spaces)");
                _name = value;
            }
        }

        public int X { get; set; }

        public int Y { get; set; }

        public string FractionalPrice
        {
            get { return $"{X}/{Y}"; }
        }

        public double DecimalPrice
        {
            get
            {
                return 100 / (1 + (double)X / (double)Y);
            }
        }

        public double Chance(double margin)
        {
            return (DecimalPrice / margin) * 100;
        }
    }
}
