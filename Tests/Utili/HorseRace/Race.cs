using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseRace
{
    public class Race
    {
        static readonly Random rnd = new Random();

        public Race()
        {
            Runners = new List<Runner>();
        }
        public List<Runner> Runners { get; set; }

        public double Margin { get; private set; }

        private void CalculateMargin()
        {
            Margin = Runners.Sum(x => x.DecimalPrice);
        }


        /// <summary>
        /// Calculating winner according this algorythm
        /// https://en.wikipedia.org/wiki/Alias_method and 
        /// http://code.activestate.com/recipes/576564-walkers-alias-method-for-random-objects-with-diffe/
        /// </summary>
        /// <returns></returns>
        public Runner CalculateWinner()
        {
            double sumOfAllChances = Runners.Sum(x => x.Chance(Margin));
            double sumU = Math.Ceiling(sumOfAllChances);
            
            var pick = rnd.Next((int)sumU);

            double sum = 0;
            Runner res = new Runner();

            foreach (var item in Runners)
            {
                sum += item.Chance(Margin);
                if (sum >= pick)
                {
                    res = item;
                    Runners[Runners.IndexOf(res)].winCount++;

                    break;
                }
            }

            return res;
        }

        void DisplayWinner(Runner runner) => Console.WriteLine($"The winner is: {runner.Name}, {runner.FractionalPrice}, Chance: {runner.Chance(Margin):0.00}");

        public void RunRace(bool displayWinners = false)
        {
            CalculateMargin();

            if (Margin > 140 || Margin < 110)
                throw new ArgumentOutOfRangeException($"'{nameof(Margin)}' must be between 110% and 140%");
            var winner = CalculateWinner();
            if (displayWinners) DisplayWinner(winner);

        }
    }
}
