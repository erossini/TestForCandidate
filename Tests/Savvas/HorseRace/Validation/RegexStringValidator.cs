using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Amdocs.HorseRace.Validation
{
    public class RegexStringValidator : IRegexStringValidator
    {
        private readonly string _pattern;

        public RegexStringValidator(string pattern)
        {
            _pattern = pattern;
        }

        public ValidateResult Validate(string item)
        {
            var errorMessage = "The string is not matched with pattern";
            var regex = new Regex(_pattern);
            return regex.IsMatch(item)
                ? ValidateResult.Success
                : new ValidateResult(new[] { errorMessage });
        }
    }
}
