using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amdocs.HorseRace.Validation
{
    public class RangeDecimalValidator : IRangeValidator<decimal>
    {
        private readonly int _minValue;
        private readonly int _maxValue;

        public RangeDecimalValidator(int minValue, int maxValue)
        {
            _minValue = minValue;
            _maxValue = maxValue;
        }

        public ValidateResult Validate(decimal value)
        {
            var errorMessage = $"{value} is out of range between {_minValue} and {_maxValue}";
            return (value >= _minValue && value <= _maxValue)
                ? ValidateResult.Success
                : new ValidateResult(new[] { errorMessage });
        }
    }
}
