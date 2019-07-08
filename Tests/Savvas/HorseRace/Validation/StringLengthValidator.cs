using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amdocs.HorseRace.Validation
{
    public class StringLengthValidator : IStringLengthValidator
    {
        private readonly int _length;

        public StringLengthValidator(int length)
        {
            _length = length;
        }

        public ValidateResult Validate(string item)
        {
            var errorMessage = $"The length of the string is more than {_length} characters";
            return item.Length <= _length
                ? ValidateResult.Success
                : new ValidateResult(new[] { errorMessage });
        }
    }
}
