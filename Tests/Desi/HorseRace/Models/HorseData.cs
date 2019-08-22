using System;
using System.Collections.Generic;
using System.Linq;
using HorseRace.Extensions;
namespace HorseRace.Models
{
    public class HorseData
    {
        FractionalConvertion fraction = new FractionalConvertion();
        decimal chanceToWin;

        public List<Horse> horses;

        public HorseData()
        {
            horses = new List<Horse>()
             {
                new Horse{HorseName="Lucky", Winning = 1, Stake = 2 },
                new Horse{HorseName="Feragust", Winning = 2, Stake = 1 },
                new Horse{HorseName="Arch Gold", Winning = 3, Stake = 1 },
                new Horse{HorseName="Laieth", Winning = 8, Stake = 1 },
                new Horse{HorseName="Best", Winning = 51, Stake = 4},
                new Horse{HorseName="Celion", Winning = 73, Stake = 5 },
                new Horse{HorseName="Devian", Winning = 123, Stake = 10 },
                new Horse{HorseName="Lucky", Winning = 70, Stake = 2 },
                new Horse{HorseName="Feragust", Winning = 99, Stake = 3 },
                new Horse{HorseName="Arch Gold", Winning = 33, Stake = 1 },
                new Horse{HorseName="Laieth", Winning = 100, Stake = 3 },
                new Horse{HorseName="Grecian Spirit", Winning = 18, Stake = 1 },
                new Horse{HorseName="Alpine Peak", Winning = 1, Stake = 2 },
                new Horse{HorseName="Escalator", Winning = 14, Stake = 1 },
                new Horse{HorseName="Arti", Winning = 12, Stake = 1 },
                new Horse{HorseName="Arius", Winning = 13, Stake = 1 },
                new Horse{HorseName="Orion", Winning = 54, Stake = 6 },
                new Horse{HorseName="Cactus", Winning = 71, Stake = 9 },
                new Horse{HorseName="Julius", Winning = 83, Stake = 10 }

             };
        }

        
    public void GetHorsesByName(string name = null)
    {
        Console.WriteLine("{0,-10} ", "_________________________________________________");
        Console.WriteLine("{0,-10} {1,30} ", " Winner Name", " Fraction Odds ");
        var query = from h in horses
                    where string.IsNullOrEmpty(name) || h.HorseName.StartsWith(name)
                    orderby h.HorseName
                    select h;
        foreach (var item in query)
        {
            //Console.WriteLine("{1,-10} {1,15}", item.HorseName.ToUpper(), fraction.StringFraction(item.Winning, item.Stake));
            Console.WriteLine("{0,-10} ", "_________________________________________________");
            Console.WriteLine($"| {item.HorseName.ToUpper(),-25} | {fraction.StringFraction(item.Winning, item.Stake),-15} |");
            //Console.WriteLine($"| {item.HorseName.ToUpper(),-25} | {fraction.FractionToDecimal(item.Winning, item.Stake),-15} |");
            //Console.WriteLine($"| {item.HorseName.ToUpper(),-25} | {Decimal.Divide(100, fraction.FractionToDecimal(item.Winning, item.Stake)),-15} |");
            //Console.WriteLine($"| {item.HorseName.ToUpper(),-25} | {horses.Sum(a => Decimal.Divide(100M, Decimal.Divide(item.Winning, item.Stake) + 1)),-15} |");
        }
        Console.WriteLine("{0,-10} ", "_________________________________________________");
        RaceMargin();
    }

    public int GetCountOfHorses()
    {
        return horses.Count();
    }

    public decimal RaceMargin()
    {
        decimal x = (from h in horses
                     let o = Decimal.Divide(100M, fraction.FractionToDecimal(h.Winning, h.Stake))
                     select o).Sum();

        // Console.WriteLine($"margin: {x}");

        return x;
    }

    public decimal ChanceToWin()
    {
        decimal raceMargin = RaceMargin();
        List<decimal> list = new List<decimal>();

        foreach (var h in horses)
        {
            chanceToWin = (Decimal.Divide(100M, Decimal.Divide(h.Winning, h.Stake) + 1) / raceMargin) * 100M;
            list.Add(chanceToWin);

        }

        decimal max = list[0];

        for (int i = 0; i < list.Count; i++)
        {

            if (list[i] > max)
            {

                max = list[i];
            }

        }
        Console.WriteLine($"The Winner of the race with {Math.Round(max, 2)} best chance");

            return 0;
    }
    public void BestChanceDisplay()
    {
        Console.WriteLine("{0,-10} ", "_________________________________________________");
        Console.WriteLine("{0,-10} {1,30} ", " Winner Name", " Percentage ");

        decimal raceMargin = RaceMargin();
        foreach (var h in horses.Randomize())
        {
            chanceToWin = (Decimal.Divide(100M, Decimal.Divide(h.Winning, h.Stake) + 1) / raceMargin) * 100M;
            Console.WriteLine("{0,-10} ", "_________________________________________________");
            Console.WriteLine($"| {h.HorseName.ToUpper(),-25}  | {Math.Round(chanceToWin, 2),15} |");
        }
    }



}
}

