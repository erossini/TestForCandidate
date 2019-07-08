using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HorseRacing
{
    public class Runner
    {
        public string Name { get; private set; }

        public string Odds { get; private set; }

        public decimal PersonalMargin { get; set; }

        public decimal Chance { get; set; }

        public bool SetName(string name)
        {
            if (Regex.IsMatch(name, @"^[a-zA-Z]+$"))
                if (name.Length >= Constants.MAX_NAME_LENGTH)
                {
                    this.Name = name.Substring(0, Constants.MAX_NAME_LENGTH);
                    return true;
                }
                else
                {
                    this.Name = name;
                    return true; 
                }
            else
            {
                return false;
            }
        }


        public bool SetOdds(string odds)
        {
            if(Helpers.SplitOdds(odds).Count() == 2)
            {
                if (Helpers.ValidateOdds(Helpers.SplitOdds(odds)[0], Helpers.SplitOdds(odds)[1]))
                {
                    this.Odds = odds;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
           
        }

        public Runner(string name, string odds)
        {
            if (Regex.IsMatch(name, @"^[a-zA-Z]+$"))
                if (name.Length >= Constants.MAX_NAME_LENGTH)
                {
                    this.Name = name.Substring(0, Constants.MAX_NAME_LENGTH);
                }
                else
                {
                    this.Name = name;
                }
            else
            {
                throw new ArgumentException();
            }

            //

            if (Helpers.ValidateOdds(Helpers.SplitOdds(odds)[0], Helpers.SplitOdds(odds)[1]))
            {
                this.Odds = odds;
            }
            else
            {
                throw new ArgumentException();
            }

        }

        public Runner()
        {

        }

    }
}
