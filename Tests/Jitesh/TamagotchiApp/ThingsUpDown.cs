using System.Collections.Generic;

namespace TamagotchiApp
{
    public static class ThingsUpDown
    {
        private static Dictionary<int, bool> selectedAction = new Dictionary<int, bool>();

        public delegate void UpAndDown(bool isUp);

        public static int Hungriness { get; set; } = 1;
        public static int Fullness { get; set; } = 1;
        public static int Tiredness { get; set; } = 1;
        public static int Happiness { get; set; } = 1;

        public static void HungrinessUpDown(bool isUp)
        {
            if (isUp)
            {
                Hungriness = Hungriness < 100 ? (Hungriness + 1) : Hungriness;
            }
            else
            {
                Hungriness = Hungriness > 1 ? (Hungriness - 1) : Hungriness;
            }
        }
        public static void FullnessUpDown(bool isUp)
        {
            if (isUp)
            {
                Fullness = Fullness < 100 ? (Fullness + 1) : Fullness;
            }
            else
            {
                Fullness = Fullness > 1 ? (Fullness - 1) : Fullness;
            }
        }
        public static void TirednessUpDown(bool isUp)
        {
            if (isUp)
            {
                Tiredness = Tiredness < 100 ? (Tiredness + 1) : Tiredness;
            }
            else
            {
                Tiredness = Tiredness > 1 ? (Tiredness - 1) : Tiredness;
            }
        }
        public static void HappinessUpDown(bool isUp)
        {
            if (isUp)
            {
                Happiness = Happiness < 100 ? (Happiness + 1) : Happiness;
            }
            else
            {
                Happiness = Happiness > 1 ? (Happiness - 1) : Happiness;
            }
        }

        public static void AllUpAndDownThings(Dictionary<int,bool> actionName)
        {
            selectedAction = actionName;
            CreateThings(HungrinessUpDown, FullnessUpDown, TirednessUpDown, HappinessUpDown);

        }

        private static void CreateThings(params UpAndDown[] upAndDowns)
        {
            foreach (var item in selectedAction)
            {
                upAndDowns[item.Key].Invoke(item.Value);
            }
        }
    }

}
