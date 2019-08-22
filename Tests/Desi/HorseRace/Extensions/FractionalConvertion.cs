using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseRace.Extensions
{
   public class FractionalConvertion
    {
       decimal fractionToDecimal;
        /// <summary>
        /// Converts Fractions into Simplest form.
        /// </summary>
        /// <param name="num">Numerator</param>
        /// <param name="den">Denominator</param>
        /// <returns>Simplest Fractions in string type</returns>
        public string StringFraction(int num, int den)
        {
            int counter;
            if (num > den)
            {
                counter = den;
            }
            else
            {
                counter = num;
            }
            for (int i = 2; i <= counter; i++)
            {
                // xNum = num % i;
                if ((num % i) == 0)
                {
                    //  yDen = den % i;
                    if ((den % i) == 0)
                    {
                        num = num / i;
                        den = den / i;
                        i--;
                    }
                }
            }
            return num.ToString() + "/" + den.ToString();
        }

        public decimal FractionToDecimal(int num, int den)
        {
            if (num > 0 && den > 0)
            {
               fractionToDecimal = Decimal.Divide(num, den) + 1;
            }
            return fractionToDecimal;
        }
    }
}
