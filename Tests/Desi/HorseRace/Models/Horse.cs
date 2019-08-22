using System.ComponentModel.DataAnnotations;

namespace HorseRace.Models
{
    public class Horse
    {
        //private decimal fractionToDecimal;

        [Required]
        [MaxLength(18)]
        [RegularExpression("^[A-Z ]*$")]
        public string HorseName { get; set; }


        public int Winning { get; set; }
        public int Stake { get; set; }
 
        public Horse(string name, int winning, int stake)
        {
            this.HorseName = name;
            this.Winning = winning;
            this.Stake = stake;
        }
        public Horse()
        { }
        
    }
}
