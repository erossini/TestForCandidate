using System;
using System.ComponentModel.DataAnnotations;

namespace HorseRace.Simulator
{
   public class HorseRacer
   {
      [Required]
      [MaxLength(18)]
      [RegularExpression("^[A-Za-z]+$",ErrorMessage = "Name can be A-Z only including spaces only")]
      public string Name { get; set; }

      [Required]
      [RegularExpression("[1-9][0-9]*\\/[1-9][0-9]*", ErrorMessage = "Odds x/y can be only integers")]
      public string Odd { get; set; }

      public decimal CalculateDecimalEquivalent()
      {
         var splitOddToNumbers = Odd.Split('/');
         var result = Convert.ToDecimal(100) / ((Convert.ToDecimal(splitOddToNumbers[0]) / Convert.ToDecimal(splitOddToNumbers[1])) + 1);
         return Convert.ToDecimal(result.ToString("#.##"));
      }

      public decimal ChanceOfWining(decimal raceMargin)
      {
         var result = (CalculateDecimalEquivalent() / raceMargin) * Convert.ToDecimal(100);
         return Convert.ToDecimal(result.ToString("#.##"));
      }
   }
}
