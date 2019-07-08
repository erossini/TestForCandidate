using HorseRaceEmu.Helpers;

namespace HorseRaceEmu.Horses
{
    public class Horse
    {
        public string Name { get; private set; }
        public string OddPrice { get; private set; }
        public double From { get; set; }
        public double To { get; set; }

        public double Margin
        {
            get
            {
                if (OddPrice == null) return 0;
                var oddPriceNumbers = OddPrice.Split('/');
                return 100d / (double.Parse(oddPriceNumbers[0]) / double.Parse(oddPriceNumbers[1]) + 1.00d);
            }
        }

        public ValidationResult AddName(string name)
        {
            var validationResult = Validations.ValidateName(name);

            if (validationResult)
                Name = name;

            return validationResult;
        }

        public ValidationResult AddOdd(string oddPrice)
        {
            var validationResult = Validations.ValidateOddPrice(oddPrice);
            if (validationResult)
                OddPrice = oddPrice;

            return validationResult;
        }

        public override string ToString()
        {
            return $@"NAME: {Name,-10} ODD PRICE: {OddPrice ?? "NONE",-10} MARGIN: {Margin,-10:F}";
        }
    }
}