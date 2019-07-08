using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HorseRacing
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfHorses = 0;
          


         

            List<Runner> runners = new List<Runner>();

            while (!Helpers.ValidNumberOfHorses(numberOfHorses))
            {
                Console.WriteLine("Welcome to Horse Racing, please set the number of horses for todays race");
                int.TryParse(Console.ReadLine(), out numberOfHorses);

            }


           runners = Helpers.SubmitHorses(runners,numberOfHorses);

          
            Console.WriteLine("Margin is {0} %", String.Format("{0:.##}", Helpers.CalculateMargin(runners)));

            if (Helpers.CalculateMargin(runners) >= 110 && Helpers.CalculateMargin(runners) <= 140)
            {
                bool start = false;
                ButtonForm button = new ButtonForm(start);
              
                if(button.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    start = true;
                }

                if (start)
                {
                    foreach(var runner in runners)
                    {
                       runner.Chance = Helpers.RunnersChance(runner, Helpers.CalculateMargin(runners));
                    }
                  Runner winner = Helpers.CalculateWinner(runners);
                    Console.WriteLine("the winner is {0} who had a chance of winning {1}", winner.Name , winner.Chance);
                }
            }
            else
            {
                Console.WriteLine("Margin is Invalid");
                

            }

           
            

            Console.ReadKey();
          
          

        }
    }
}
