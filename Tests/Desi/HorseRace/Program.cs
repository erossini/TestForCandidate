using HorseRace.Models;
using System;

namespace HorseRaceProblem
{
    public class HorseRace
    {
        static void Main(string[] args)
        {
            
            var horseData = new HorseData();

           

            Console.WriteLine("");
            Console.WriteLine("All the horses enter in race");
            horseData.GetHorsesByName();
            
            Console.WriteLine("");
            Console.WriteLine("The percentage chance of all racing hors");
            horseData.BestChanceDisplay();


            Console.WriteLine("");
            Console.WriteLine("The winner of the game");
            horseData.ChanceToWin();

            Console.ReadLine();
        }


    }
}