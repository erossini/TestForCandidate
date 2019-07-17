using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HorseRace.Simulator
{
   class Program
   {
      static void Main(string[] args)
      {
         var race = InitRace();

         foreach (var item in race.Runners)
         {
            Console.WriteLine($"Name: {item.Name}, Odd: {item.Odd}, Chance of Wining: {item.ChanceOfWining(race.Margin)}, Decimal Equivalent: {item.CalculateDecimalEquivalent()}");
         }

         var random = new Random();
         var amount = Convert.ToDecimal(random.NextDouble());
         var winner = Util.RandomWinnerSelection(race.Runners, race.Margin,amount);

         Console.WriteLine($"***Today's race winner is {winner.Name}. Congrats");
         Console.ReadLine();
      }

      public static Race InitRace()
      {
         while (true)
         {
            var race = new Race { Runners = new List<HorseRacer>() };

            var racerCount = GetRacersCount();

            for (var i = 0; i < racerCount; i++)
            {
               var racer = GetHorseRacer(i);
               race.Runners.Add(racer);
            }

            if (race.CanWeStartTheRace)
            {
               Console.WriteLine("Please any key to start the race....");
               Console.ReadKey();
               return race;
            }

            Console.WriteLine("Race margin is not between 110% and 140%. Please try one more time. Please any key to start again");
            Console.ReadKey();
         }
      }

      public static int? GetRacersCount()
      {
         while (true)
         {
            Console.WriteLine("Please enter horse racers count, count must be between 4 and 16");
            var enteredRacerCount = Console.ReadLine();

            if (int.TryParse(enteredRacerCount, out var racerCount) && racerCount>=4 && racerCount<=16)
            {
               return racerCount;
            }

            Console.WriteLine("Entered racer count must be integer and must be between 4 and 16.");
         }
      }
      
      public static HorseRacer GetHorseRacer(int racerNumber)
      {
         while (true)
         {
            var racer = new HorseRacer(); 
            Console.WriteLine($"#{racerNumber + 1} racer");
            Console.WriteLine($"Please enter #{racerNumber + 1} racer Name: ");
            racer.Name = Console.ReadLine();
            Console.WriteLine($"Please enter #{racerNumber + 1} racer Odd: ");
            racer.Odd = Console.ReadLine();

            var context = new ValidationContext(racer, null, null);
            var result = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(racer, context, result, true); 

            if (isValid)
            {
               return racer;
            }

            Console.WriteLine("Wrong value entered, please obey the validation rule(s) mentioned below.");
            foreach (var validationResult in result)
            {
               Console.WriteLine($"***{validationResult.ErrorMessage}");
            }
         }
      }
   }
}
