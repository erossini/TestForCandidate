using System.Collections.Generic;

namespace TamagotchiApp
{
    public static class Pet
    {

        private delegate void ActionsDelegate();
        private static int _choice { get; set; }
        private static Dictionary<int, bool> distonary;


        static void Feed()
        {
            distonary = new Dictionary<int, bool>();
            distonary.Add(Enums.Hungriness, Enums.Decreased);
            distonary.Add(Enums.Fullness, Enums.Increased);
        }

        static void Play()
        {
            distonary = new Dictionary<int, bool>();
            distonary.Add(Enums.Happiness, Enums.Increased);
            distonary.Add(Enums.Tiredness, Enums.Increased);
        }

        static void PutToBed()
        {
            distonary = new Dictionary<int, bool>();
            distonary.Add(Enums.Tiredness, Enums.Decreased);
        }

        static void Poop()
        {
            distonary = new Dictionary<int, bool>();
            distonary.Add(Enums.Fullness, Enums.Decreased);
        }
        static void NeedOverTime()
        {
            distonary = new Dictionary<int, bool>();
            distonary.Add(Enums.Tiredness, Enums.Increased);
            distonary.Add(Enums.Hungriness, Enums.Increased);
            distonary.Add(Enums.Happiness, Enums.Decreased);
        }

        private static void Create(params ActionsDelegate[] actions)
        {
            actions[_choice].Invoke();
        }
        public static void GetAllActions(int choice)
        {
            _choice = (choice - 1);

            Create(Feed, Play, PutToBed, Poop, NeedOverTime);
            ThingsUpDown.AllUpAndDownThings(distonary);

        }
    }
}
