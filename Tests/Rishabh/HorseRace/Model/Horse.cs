using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseRace.Model
{
   public class Horse
    {
        private String horseName;
        public String HorseName
        {
            get { return horseName; }
            set { horseName = value; }
        }

        private String oddPrice;
        public String OddPrice
        {
            get { return oddPrice; }
            set { oddPrice = value; }
        }

        private double margin;
        public double Margin
        {
            get { return margin; }
            set { margin = value; }
        }

        private double percentChance;
        public double PercentChance
        {
            get { return percentChance; }
            set { percentChance = value; }
        }

        private double cumulativePercent;
        public double CumulativePercent
        {
            get { return cumulativePercent; }
            set { cumulativePercent = value; }
        }

        public Horse(String _horsename, String _oddPrice, double _margin)
        {
            this.HorseName = _horsename;
            this.OddPrice = _oddPrice;
            this.Margin = _margin;
        }


    }
}
