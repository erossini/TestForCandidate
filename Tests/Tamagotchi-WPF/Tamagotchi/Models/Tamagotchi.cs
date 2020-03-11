using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tamagotchi.Models.Emotions;

namespace Tamagotchi.Models
{
    public class Tamagotchi
    {
        public Hunger Hunger { get; set; } = new Hunger();

        public Happiness Happiness { get; set; } = new Happiness();

        public Tiredness Tiredness { get; set; } = new Tiredness();
    }
}
