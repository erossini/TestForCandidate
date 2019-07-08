namespace HorseRaceEmu.Helpers
{
    public class ValidationResult
    {
        private ValidationResult()
        {
        }

        public string Message { get; set; }
        public bool Result { get; set; }


        public static ValidationResult Valid()
        {
            return new ValidationResult {Result = true};
        }

        public static ValidationResult Invalid(string message)
        {
            return new ValidationResult {Message = message, Result = false};
        }

        public static implicit operator bool(ValidationResult result)
        {
            return result.Result;
        }
    }
}