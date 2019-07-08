using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseRacing
{
    public static class Helpers
    {
        public static List<int> SplitOdds(string oddsAsString)
        {

            List<int> oddsAsList = new List<int>();

            string[] splitted = oddsAsString.Split('/');
            if (splitted.Length <= 2 && int.TryParse(splitted[0], out int numerator) && int.TryParse(splitted[1], out int denominator))
            {
                oddsAsList.Add(numerator);
                oddsAsList.Add(denominator);
                return oddsAsList;
            }
            return oddsAsList;
        }


        public static bool ValidateOdds(int numerator, int denominator)
        {
            if (numerator >= 1 && denominator >= 1)
            {
                return true;
            }
            return false;
        }

        public static decimal FractionalToDecimal(int numerator, int denominator)
        {

            decimal dec = ((decimal)numerator / (decimal)denominator) + 1;
            return dec;
        }

        public static decimal CalculateMargin(List<Runner> runners)
        {
            decimal margin = 0;

            foreach (var runner in runners)
            {
                string tempOddsAsString = runner.Odds;
                List<int> tempOddsAslist = SplitOdds(tempOddsAsString);

                decimal decimalEquivalentForEach = FractionalToDecimal(tempOddsAslist[0], tempOddsAslist[1]);
                decimal decimalToAdd = 100 / decimalEquivalentForEach;
                runner.PersonalMargin = decimalToAdd;
                margin += decimalToAdd;

            }

            return margin;
        }

        public static bool ValidNumberOfHorses(int number)
        {
            if (number >= 4 && number <= 18)
            {
                return true;
            }
            return false;
        }
        public static decimal RunnersChance(Runner runner, decimal margin)
        {
            decimal chance = (runner.PersonalMargin / margin) * 100;
            return chance;
        }

        public static Runner CalculateWinner(List<Runner> runners)
        {
            Random s_Random = new Random();
            Runner winner = new Runner();
            List<Runner> sortedrunners = runners.OrderBy(c => c.Chance).ToList();

            decimal sum = 0;
            int percent = s_Random.Next(0, 99);

            for (int i = 0; i <= runners.Count(); i++)
            {
                {
                    sum += sortedrunners[i].Chance;
                    winner = sortedrunners[i];
                    if (sum > percent)
                        break;
                }

            }

            return winner;
        }

        public static List<Runner> SubmitHorses(List<Runner> runners, int numberOfHorses)
        {
            int previousRunnersCount = 0;
            int currentRunnersCount = 0;
            while (runners.Count() != numberOfHorses)
            {

                Console.WriteLine("Current Number of Horses Submitted for race {0} \n \n", runners.Count());

                previousRunnersCount = currentRunnersCount;
                Console.WriteLine("Please submit Horse name with a maximum length of 18 characters");

                string temp_name = Console.ReadLine();
                Runner temprunner = new Runner();

                if (temprunner.SetName(temp_name))
                {
                    while (previousRunnersCount == currentRunnersCount)
                    {
                        Console.WriteLine("Submit the odds for horse with the name : {0}", temprunner.Name);
                        string temp_odds = Console.ReadLine();
                        if (temprunner.SetOdds(temp_odds))
                        {
                            runners.Add(temprunner);
                            currentRunnersCount++;
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("Wrong input for odds, please resubmit ");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Name can only contain letters from A-Z");
                }

            }
            return runners;
        }
    }
}


