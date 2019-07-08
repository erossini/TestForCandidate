using System;
using System.Linq;
using HorseRace.Commands;

namespace HorseRace
{
    class Program
    {
        //I did some overengineering for sure
        //I've implemented margin, winners picking logic pretty fast (~40-50 minutes)
        //and i has a lot of free time. So i decided to play with command patterns and
        //to implement simple console UI
        //If you interested only in race logic, you can find it in folder RaceLogic.
        
        //overall, i've spent ~4hrs on everything
        static void Main()
        {
            var commandFactory = new CommandFactory();
            commandFactory.Create(new [] {"help", "info"}).Execute();

            while (true)
            {
                var input = Console.ReadLine();
                var splittedInput = input?.Split(' ').Select(el => el.Trim()).ToArray();
                var command = commandFactory.Create(splittedInput);
                command.Execute();
            }
        }
    }
}