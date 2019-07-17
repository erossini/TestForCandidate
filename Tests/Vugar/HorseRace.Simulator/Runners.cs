using System.Collections.Generic;
using System.Linq;


namespace HorseRace.Simulator
{
   public class Race
   {
      public List<HorseRacer> Runners { get; set; }

      public decimal Margin => Runners.Sum(x => x.CalculateDecimalEquivalent());

      public bool CanWeStartTheRace => Margin >= 110 && Margin <= 140;
   }
}
