using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HorseRace.Utility
{
   public class Validation
    {
       /// <summary>
       /// 1-18 char & alphabets+space
       /// </summary>
       /// <param name="horsename"></param>
       /// <returns></returns>
        internal static bool isValidName(String horsename)
        {
            Regex r = new Regex(@"^([a-zA-Z]+\s)*[a-zA-Z]{1,18}$");
            if (!r.IsMatch(horsename) || !(horsename.Length >= 1 && horsename.Length <= 18))
                return false;
            else
                return true;
        }


       /// <summary>
       /// integers greater than eq 1
       /// 
       /// </summary>
       /// <param name="price"></param>
       /// <returns></returns>
        internal static Tuple<bool, String> isValidOddPrice(String price)
        {
            if (!price.Contains("/")) return Tuple.Create(false, "'x/y' where x and y are integer numbers greater than 1"); ;
            var fraction = price.Split('/');

            var numertor = isNumeric(fraction[0]);
            if (numertor.Item1 == false)
                return Tuple.Create(false, "numerator not a valid integer");

            if (numertor.Item2 < 1)
                return Tuple.Create(false, "numerator should be greater than 1");

            var denominator = isNumeric(fraction[1]);
            if (denominator.Item1 == false)
                return Tuple.Create(false, "denominator not a valid integer");

            if (denominator.Item2 < 1)
                return Tuple.Create(false, "denominator should be greater than 1");

            return Tuple.Create(true, "");
        }


        internal static Tuple<bool, int> isNumeric(string text)
        {
            int number;
            var isNumber = int.TryParse(text, out number);
            return Tuple.Create(isNumber, number);
        }
    
        internal static bool isValidRaceMargin(double totalMargin)
        {
            return (totalMargin > 110 && totalMargin < 140);
        }

    }
}
