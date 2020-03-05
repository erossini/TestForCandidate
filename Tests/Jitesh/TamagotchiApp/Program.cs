using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TamagotchiApp
{
    class Program
    {
        public static bool IsExist = true;
        static void Main(string[] args)
        {
            //while (IsExist)
            //{
            //    Menu();
            //}
            int x = 17;
            int y = 15;
            var result = TwinsNumber(x, y);
        }

        public static void Menu()
        {
            Console.WriteLine("1: Feed \n");
            Console.WriteLine("2: Play \n");
            Console.WriteLine("3: PutToBed \n");
            Console.WriteLine("4: Poop \n");
            Console.WriteLine("5: NeedOverTime \n");
            Console.WriteLine("6: Exit \n");
            var chr = Console.ReadKey().KeyChar.ToString();
            switch (chr)
            {
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                    Pet.GetAllActions(int.Parse(chr));
                    Console.WriteLine("\n");
                    Console.WriteLine($"Hungriness: {ThingsUpDown.Hungriness} \n");
                    Console.WriteLine($"Fullness: {ThingsUpDown.Fullness} \n");
                    Console.WriteLine($"Tiredness: {ThingsUpDown.Tiredness} \n");
                    Console.WriteLine($"Happiness: {ThingsUpDown.Happiness} \n");
                    Console.WriteLine($"Do you want to operate more? then Press 9 or 6 for Exit");
                    Console.ReadLine();
                    IsExist = true;
                    break;
                case "6": IsExist = false; break;
            }
        }

        public static bool TwinsNumber(int x, int y)
        {
            bool isPrime = false;

                if (isPrimeNum(x) && isPrimeNum(y))
                {
                    if(Math.Abs(x - y) == 2)
                    return isPrime = true;
                }
                else isPrime = false;
            return isPrime;
        }
        public static bool isPrimeNum(int n)
        {
            if (n == 1) return false;
            if (n == 2 || n==3 || n==5) return true;

            if (n % 2 == 0 || n % 3 == 0 || n % 5 == 0)
               return false;
            else
                return true;

        }

    }
}
