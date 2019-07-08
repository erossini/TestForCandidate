using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amdocs.HorseRace.Validation
{
    public class RangeIntValidator : IRangeValidator<int>
    {
        private readonly int _minValue;
        private readonly int _maxValue;

        public RangeIntValidator(int minValue, int maxValue)
        {
            _minValue = minValue;
            _maxValue = maxValue;
        }

        public ValidateResult Validate(int value)
        {
            var errorMessage = $"{value} is out of range between {_minValue} and {_maxValue}";
            return (value >= _minValue && value <= _maxValue)
                ? ValidateResult.Success
                : new ValidateResult(new[] { errorMessage });
        }
    }
}
