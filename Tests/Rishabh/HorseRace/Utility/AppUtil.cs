using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseRace.Utility
{
   public class AppUtil
    {
        /// <summary>
        /// To calculate the margin firstly convert each fractional odds into it’s decimal equivalent which is numerator divided by denominator and then add one. 
        ///Divide 100 by each decimal equivalent and sum up all of these answers, to give the margin to 2 decimal places.
        /// </summary>
        /// <param name="oddPrice"></param>
        /// <returns></returns>
        internal static double GenerateIndividualMargin(String oddPrice)
        {
            var fraction = oddPrice.Split('/');
            var numerator = Convert.ToDouble(fraction[0]);
            var denominator = Convert.ToDouble(fraction[1]);
            double odd = (numerator / denominator) + 1;
            return Math.Round((100 / odd), 2);
        }
    }
}
