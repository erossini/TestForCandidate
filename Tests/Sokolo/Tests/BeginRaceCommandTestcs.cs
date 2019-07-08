using System;
using System.IO;
using System.Linq;
using HorseRace.Commands;
using HorseRace.Extensions;
using HorseRace.RaceLogic;
using NUnit.Framework;

namespace Tests
{
    //This test is written to show how to test all commands that i have
    [TestFixture]
    public class RaceByCommandsTest
    {
        private static Random _random = new Random();
        private const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        [TestCase(new object[] {"1/2", "2/1", "3/1", "8/1"})]
        public void Execute_PrintsWinner_ValidRace(params string[] odds)
        {
            using (StringWriter sw = new StringWriter())
            {
                var commandFactory = new CommandFactory();
                Console.SetOut(sw);

                commandFactory.Create(new[] {"createrace"}).Execute();

                foreach (var odd in odds)
                {
                    commandFactory.Create(new[] {"addparticipant", GetRandomName(), odd}).Execute();
                }

                commandFactory.Create(new[] {"beginrace"}).Execute();
                Assert.IsTrue(sw.ToString().Contains("Winner: "));
            }
            
            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
        }

        private string GetRandomName()
        {
            return new string(Enumerable.Repeat(chars, 10)
                .Select(s => s[_random.Next(s.Length)]).ToArray());
        }

    }
}