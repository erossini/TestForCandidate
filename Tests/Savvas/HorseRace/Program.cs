using Amdocs.HorseRace.Exceptions;
using Amdocs.HorseRace.Interfaces;
using Amdocs.HorseRace.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amdocs.HorseRace
{
    class Program
    {
        static void Main(string[] args)
        {
            var lengthValidator = new StringLengthValidator(18);
            var regexValidator = new RegexStringValidator("^[A-Z ]+$");
            var rangeRaceMarginValidator = new RangeDecimalValidator(110, 140);
            var numOfRunnersValidator = new RangeIntValidator(4, 16);

            int capacity;
            ValidateResult rangeResult;
            do
            {
                Console.WriteLine("How many runners do you want for the race [4-16]:");
                var numOfRunners = Console.ReadLine();
                int.TryParse(numOfRunners, out capacity);
                rangeResult = numOfRunnersValidator.Validate(capacity);
                if (!rangeResult.Succeeded)
                {
                    Console.WriteLine(string.Concat(rangeResult.Errors.Select(e => e)));
                    Console.WriteLine();
                }

            } while (capacity == 0 || !rangeResult.Succeeded);

            var runners = new IRunner[capacity];
            Console.WriteLine();
            for (int i = 0; i < capacity; i++)
            {
                var currentRunnerId = i + 1;
                ValidateResult lengthResult;
                ValidateResult regexResult;
                var runnerName = string.Empty;
                do
                {
                    Console.WriteLine($"Please give me the name of runner{currentRunnerId}:");
                    runnerName = Console.ReadLine();
                    lengthResult = lengthValidator.Validate(runnerName);
                    regexResult = regexValidator.Validate(runnerName);
                    if (!lengthResult.Succeeded)
                        Console.WriteLine(string.Concat(lengthResult.Errors.Select(e => e)));
                    if (!regexResult.Succeeded)
                        Console.WriteLine(string.Concat(regexResult.Errors.Select(e => e)));
                    Console.WriteLine();
                } while (!lengthResult.Succeeded || !regexResult.Succeeded);

                var fractionIsValid = true;
                do
                {
                    Console.WriteLine($"Please give me the fractional odd for runner{currentRunnerId}:");
                    var fractionalOdd = Console.ReadLine();
                    try
                    {
                        var fraction = new Fraction(fractionalOdd);
                        var runner = new Runner(runnerName, fraction);
                        runners[i] = runner;
                        fractionIsValid = true;
                    }
                    catch (InvalidFractionException ex)
                    {
                        fractionIsValid = false;
                        Console.WriteLine(ex.Message);
                        Console.WriteLine();
                    }
                } while (fractionIsValid == false);
                Console.WriteLine();
            }

            var calculator = new RaceMarginCalculator();
            IRace race = new Race(runners, calculator);
            var raceMargin = race.CalculateRaceMargin();
            Console.WriteLine(raceMargin);
            ValidateResult raceMarginResult = rangeRaceMarginValidator.Validate(raceMargin);
            if (!raceMarginResult.Succeeded)
                Console.WriteLine(string.Concat(raceMarginResult.Errors.Select(e => e)));

            Console.WriteLine();
            race.CalculateRunnersWinningPercentage();

            var appearances = new List<RunnerAppearance>();
            foreach (var runner in runners)
            {
                appearances.Add(new RunnerAppearance(runner.Name, runner.WinningPercentage, 0));
            }

            string menuOption;
            do
            {
                Console.WriteLine();
                Console.WriteLine("============Menu==============");
                Console.WriteLine();
                Console.WriteLine("Choose P to pick a winner (P)");
                Console.WriteLine("Choose A to display the number of appearances for each runner based on winning percentage (A)");
                Console.WriteLine("Choose W to display the winning percentage for each runner (A)");
                Console.WriteLine("Choose Q to exit (Q)");
                Console.WriteLine();
                Console.WriteLine("Select an option:");
                menuOption = Console.ReadLine();
                var rnd = new Random();

                switch (menuOption)
                {
                    case "P":
                        Console.WriteLine();
                        Console.WriteLine("Please select how many iterations do you want ?");
                        Console.WriteLine();
                        Console.WriteLine("Select 1 for 1 iteration (1):");
                        Console.WriteLine("Select 10 for 10 iterations (10):");
                        Console.WriteLine("Select 100 for 100 iterations (100):");
                        Console.WriteLine("Select 1,000 for 1,000 iterations (1,000):");
                        Console.WriteLine("Select 10,000 for 10,000 iterations (10,000):");
                        Console.WriteLine("Select 100,000 for 100,000 iterations (100,000):");
                        Console.WriteLine("Select 1,000,000 for 1,000,000 iterations (1,000,000):");
                        menuOption = Console.ReadLine();
                        int.TryParse(menuOption, out int iterations);
                        switch (menuOption)
                        {
                            case "1":
                            case "10":
                            case "100":
                            case "1000":
                            case "10000":
                            case "100000":
                            case "1000000":
                                for (int i = 0; i < iterations; i++)
                                {
                                    var randomNum = rnd.Next(1, 101);
                                    PickWinner(randomNum, race, appearances);
                                }
                                break;
                            default:
                                break;
                        }
                        break;
                    case "A":
                        DisplayRunnerAppearances(appearances);
                        break;
                    case "W":
                        DisplayWinningPercentages(runners);
                        break;
                    case "Q":
                        break;

                }
            } while (menuOption != null && !menuOption.Equals("Q"));
            Environment.Exit(0);

            Console.ReadKey();
        }

        static void PickWinner(int randomNum, IRace race, List<RunnerAppearance> appearances)
        {
            var winner = race.PickWinner(randomNum);
            var runner = appearances.SingleOrDefault(r => r.Name == winner.Name);
            runner.Appearances += 1;
            Console.WriteLine(winner.Name);
        }

        static void DisplayRunnerAppearances(List<RunnerAppearance> appearances)
        {
            Console.WriteLine();
            foreach (var item in appearances.OrderByDescending(a => a.Appearances))
                Console.WriteLine($"{item.Name} has {item.WinningPercentage} % probability to win and {item.Appearances} appearances");
        }

        static void DisplayWinningPercentages(IRunner[] runners)
        {
            Console.WriteLine();
            foreach (var item in runners.OrderByDescending(r => r.WinningPercentage))
                Console.WriteLine($"{item.Name} has {item.WinningPercentage} % probability to win");
        }
    }
}
