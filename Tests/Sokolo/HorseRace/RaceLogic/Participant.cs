using System.Linq;

namespace HorseRace.RaceLogic
{
    public class Participant
    {
        public string Name { get; }
        public double Odd { get; }

        public Participant(string Name, double Odd)
        {
            this.Name = Name;
            this.Odd = Odd;
        }
        
        public Participant(string Name, string Odd)
        {
            this.Name = Name;
            var splittedOdds = Odd.Split('/').Select(double.Parse).ToArray();
            this.Odd = splittedOdds[0] / splittedOdds[1];
        }
    }
}