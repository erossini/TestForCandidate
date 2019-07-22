using HorseRace.Model;
using HorseRace.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseRace
{
    class Program
    {
        private static List<Horse> horses;

        private static double raceMargin;

        private static Dictionary<String, int> raceResults;

        static void Main(string[] args)
        {
            try
            {
                Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:" + ex.Message);
            }

            Console.ReadKey();
        }

        static void Start()
        {
            if (horses != null) horses.Clear();
            if (raceResults != null) raceResults.Clear();
            Console.Clear();

            int horseCount = GetHorseCount();
            Console.Clear();

            Console.WriteLine("Total horses in race:" + horseCount);
            Console.WriteLine("Please Enter Each Horse Detail");

            CreateHorses(horseCount);

            Console.Clear();

            Console.WriteLine("Following horses have enrolled:");

            for (var h = 0; h < horses.Count; h++)
            {
                Console.WriteLine(String.Format("Horse {0}: Name-{1}, OddPrice-{2}, Margin-{3}", (h + 1), horses[h].HorseName, horses[h].OddPrice, horses[h].Margin));
            }

            raceMargin = horses.Select(a => a.Margin).Sum();

            if (Validation.isValidRaceMargin(raceMargin) == false)
            {
                Console.WriteLine(String.Format("Race margin {0} should be between (110%-140%), wish to re enter details, type 'yes'.", raceMargin));
                var _continue = Console.ReadLine();
                if (_continue.ToLower() == "yes")
                    Start();
                else
                    Environment.Exit(0);
            }

            horses.ForEach(h => h.PercentChance = Math.Round((h.Margin / raceMargin) * 100, 2));
            horses = horses.OrderBy(a => a.PercentChance).ToList();
            horses.ForEach(a => a.CumulativePercent = GetCumulativePercentage(horses.IndexOf(a)));


            Console.Clear();

            RunRace();

        }

        private static int GetHorseCount()
        {
            bool IsValidCount = false;
            int horsesCount = 0;

            do
            {
                Console.WriteLine("Enter number of horses in race");
                var inputCount = Console.ReadLine();
                var count = Validation.isNumeric(inputCount);
                if (count.Item1 == true && (count.Item2 < 4 || count.Item2 > 16))
                {
                    Console.WriteLine("You can have between 4 to 16 horses.");
                    horsesCount = count.Item2;
                }
                else
                {
                    IsValidCount = count.Item1;
                    horsesCount = count.Item2;
                }

            }
            while (IsValidCount == false);

            return horsesCount;
        }

        private static String GetHorseName(int horseIndex)
        {
            var validHorseName = false;
            String horsename = String.Empty;
            do
            {
                Console.WriteLine("Enter horse " + horseIndex + " name:");
                horsename = Console.ReadLine();

                if (horses != null && horses.Any(a => a.HorseName.ToUpper().Equals(horsename.ToUpper())))
                {
                    validHorseName = false;
                    Console.WriteLine("Horse name already taken, please choose different name.");
                }
                else
                {
                    validHorseName = Validation.isValidName(horsename);
                    if (validHorseName == false)
                        Console.WriteLine("Horse name should be maximum of 18 characters long (A-Z only including spaces)");
                }



            }
            while (validHorseName == false);

            return horsename;
        }

        private static String GetHorseOddPrice(int horseIndex)
        {
            var validHorsePrice = false;
            String oddPrice = String.Empty;
            do
            {
                Console.WriteLine("Enter horse " + horseIndex + " odd price:");
                oddPrice = Console.ReadLine();
                var oddPriceDetail = Validation.isValidOddPrice(oddPrice);
                validHorsePrice = oddPriceDetail.Item1;
                if (validHorsePrice == false)
                    Console.WriteLine(oddPriceDetail.Item2);
            }
            while (validHorsePrice == false);

            return oddPrice;
        }

        private static void CreateHorses(int totalCount)
        {
            for (var h = 0; h < totalCount; h++)
            {
                String horsename = GetHorseName(h + 1);
                String oddPrice = GetHorseOddPrice(h + 1);
                double margin = AppUtil.GenerateIndividualMargin(oddPrice);
                var horse = new Horse(horsename, oddPrice, margin);
                if (horses == null)
                    horses = new List<Horse>();

                Console.Clear();
                Console.WriteLine("Total horses in race:" + totalCount);

                horses.Add(horse);
            }
        }

        private static void RunRace()
        {
            int noOfRaces = GetNoOfRaces();
            raceResults = new Dictionary<string, int>();
            foreach (var horse in horses)
            {
                raceResults.Add(horse.HorseName, 0);
            }

            for (var r = 1; r <= noOfRaces; r++)
            {
                var winningHorse = pickWinner();
                //Console.WriteLine("Winner is:" + winningHorse.HorseName);
                raceResults[winningHorse.HorseName] += 1;
            }
            
            DisplayResult(noOfRaces);
        }

        private static int GetNoOfRaces()
        {
            bool IsValidCount = false;
            int raceCount = 0;
            do
            {
                Console.WriteLine("Enter number of rounds for race:");
                var inputRaceCount = Console.ReadLine();
                var count = Validation.isNumeric(inputRaceCount);

                if (count.Item1 == false)
                {
                    Console.WriteLine("invalid rounds count.");
                    raceCount = count.Item2;
                }
                else
                {                        
                    IsValidCount = count.Item1;
                    raceCount = count.Item2;
                }

            }
            while (IsValidCount == false);

            return raceCount;
        }

        private static Horse pickWinner()
        {

            Random r = new Random();
            var winMargin = r.Next(0, 100);

            var winner = horses.Where(a => a.CumulativePercent > winMargin).FirstOrDefault();
            return winner;
        }

        private static void DisplayResult(int maxRaces)
        {
            foreach (var winner in raceResults)
            {
                Console.WriteLine(String.Format("Name: {0}, Count: {1}, WinPercent: {2}%", winner.Key, winner.Value, (((double)winner.Value) / maxRaces) * 100));
            }

            Console.WriteLine(Environment.NewLine);

            Console.WriteLine("Max Race Winner Is:" + raceResults.OrderByDescending(a => a.Value).FirstOrDefault().Key);

            Console.WriteLine(Environment.NewLine);

            Console.WriteLine("Continue again? type 'yes'.");
            
            var continueagain = Console.ReadLine();
            if(continueagain.ToLower()=="yes")
                Start();
            else
                Environment.Exit(0);
        }

        private static double GetCumulativePercentage(int currentIndex)
        {
            double cumulativePercent = 0;
            for (var i = 0; i <= currentIndex; i++)
            {
                cumulativePercent += horses[i].PercentChance;
            }
            return cumulativePercent;
        }
    }
}
