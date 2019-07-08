using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseRace
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input iteration count: ");
            int iterations = Convert.ToInt32(Console.ReadLine());


            Race r = new Race()            
            {
                Runners = new List<Runner>() {
                    { new Runner("Test A", 1, 2) },
                    {new Runner("Test B", 2, 1)},
                    {new Runner("Test C", 3, 1)},
                    {new Runner("Test D", 8, 1)},
                }
            };
            
            for (int i = 0; i < iterations; i++)
            {
                r.RunRace(displayWinners: false);

            }
            Console.WriteLine($"\n Iterations: {iterations}");
            Console.WriteLine(" Name\t|chance\t|wincount");
            Console.WriteLine("-------------------------");
            foreach (var item in r.Runners)
            {
                Console.WriteLine($" {item.Name}\t|{item.Chance(r.Margin):0.00}\t|{item.winCount}");
            }
            Console.ReadKey(true);
        }
    }
}
