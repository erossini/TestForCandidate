using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amdocs.HorseRace.Validation
{
    public interface IValidator<T>
    {
        ValidateResult Validate(T item);
    }
}
