using System;
using System.Collections.Generic;
using System.Linq;

namespace HorseRace.Simulator
{
   public static class Util
   {
      // random selection with wining chances
      public static HorseRacer RandomWinnerSelection(List<HorseRacer> racers, decimal margin, decimal amount)
      {
         var sum = racers.Sum(x => x.ChanceOfWining(margin));
         decimal max = 0;
         foreach (var racer in racers)
         {
            max += racer.ChanceOfWining(margin) / sum;
            if (amount<=max)
            {
               return racer;
            }
         }
         return null;
      }
   }
}
