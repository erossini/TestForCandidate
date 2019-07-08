using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amdocs.HorseRace.Validation
{
    public class ValidateResult
    {
        public ValidateResult(IEnumerable<string> errors)
        {
            Succeeded = false;
            Errors = errors;
        }

        protected ValidateResult(bool success)
        {
            Succeeded = success;
            Errors = new string[0];
        }

        public bool Succeeded { get; private set; }
        public IEnumerable<string> Errors { get; private set; }
        public static ValidateResult Success
        {
            get
            {
                return new ValidateResult(true);
            }
        }
    }
}
