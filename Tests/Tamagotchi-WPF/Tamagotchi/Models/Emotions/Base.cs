using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagotchi.Models.Emotions
{
    public class Base
    {
        // the max level of emotions
        public const int LEVELMAX = 1000;

        // the min level of emotions
        public const int LEVELMIN = 0;

        /// <summary>
        /// Returns the value from a percentage depending on max and min consts
        /// </summary>
        /// <param name="Percent"></param>
        /// <returns></returns>
        public static int GetValueFromPercent(int Percent)
        {
            return LEVELMAX * Percent / 100;
        }
    }
}
