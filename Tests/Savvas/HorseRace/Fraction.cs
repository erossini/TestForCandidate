using Amdocs.HorseRace.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amdocs.HorseRace
{
    public struct Fraction
    {
        private readonly int _numerator;
        private readonly int _denominator;

        public Fraction(string txt)
        {
            string[] items = txt.Split('/');
            _numerator = 0;
            _denominator = 0;
            if (txt.Contains("/"))
            {
                int.TryParse(items[0], out _numerator);
                int.TryParse(items[1], out _denominator);
            }
            
            if (_numerator < 1)
                throw new InvalidFractionException("Fraction value is invalid");
            if (_denominator < 1)
                throw new InvalidFractionException("Fraction value is invalid");
        }

        public Fraction(int numerator, int denominator)
        {
            if (numerator < 1)
                throw new InvalidFractionException("Fraction value is invalid");

            if (denominator < 1)
                throw new InvalidFractionException("Fraction value is invalid");

            _numerator = numerator;
            _denominator = denominator;
        }

        public int Numerator
        {
            get { return _numerator; }
        }

        public int Denominator
        {
            get { return _denominator; }
        }

        public decimal ToDecimal()
        {
            return (decimal)_numerator / _denominator;
        }

        public override string ToString()
        {
            return string.Format($"{_numerator}/{_denominator}");
        }

    }
}
