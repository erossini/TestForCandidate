using System.Text.RegularExpressions;
using HorseRaceEmu.Helpers;

namespace HorseRaceEmu.Horses
{
    public static class Validations
    {
        private const string HORSE_NAME_PATTERN = @"^[A-Z, ]{1,16}$";
        private const string ODD_PRICE_PATTERN = @"^[1-9]{1}[0-9]*/[1-9]{1}[0-9]*$";

        public static ValidationResult ValidateName(string input)
        {
            if (Regex.IsMatch(input, HORSE_NAME_PATTERN))
                return ValidationResult.Valid();

            return ValidationResult.Invalid("Horse name must contains A-Z and space symbols only");
        }

        public static ValidationResult ValidateOddPrice(string input)
        {
            if (Regex.IsMatch(input, ODD_PRICE_PATTERN))
                return ValidationResult.Valid();

            return ValidationResult.Invalid(
                "Odd price must be in x/y format, contains only numbers more or equals 1 and split with /");
        }
    }
}