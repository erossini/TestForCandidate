using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagotchi.Models.Emotions
{
    public class Hunger : Base, INotifyPropertyChanged
    {
        #region Properties

        //public int LEVELMAX = 100;
        //private const int LEVELMIN = 0;

        private int _hungerlevel;
        /// <summary>
        /// Gets or sets the hunger level of the parent from a scale of 1 to LEVELMAX
        /// </summary>
        public int HungerLevel
        {
            get { return _hungerlevel; }
            set
            {
                _hungerlevel = value;
                OnPropertyChanged("HungerLevel");

                // ensures hunger never goes over max lever
                if (HungerLevel > LEVELMAX)
                    HungerLevel--;

                // ensures hunger never goes less than min level
                if (HungerLevel < LEVELMIN)
                    HungerLevel++;
            }
        }

        private int _fullnesslevel;
        /// <summary>
        /// Gets or sets the level of satiety of the parent on a scale of 1 to LEVELMAX
        /// </summary>
        public int FullnessLevel
        {
            get { return _fullnesslevel; }
            set
            {
                _fullnesslevel = value;
                OnPropertyChanged("FullnessLevel");

                if (FullnessLevel > LEVELMAX)
                    FullnessLevel--;

                if (FullnessLevel < LEVELMIN)
                    FullnessLevel++;
            }
        }

        /// <summary>
        /// Gets or sets the path of the hungry icon
        /// </summary>
        public string HungryIconPath { get; set; } = "/Tamagotchi;component/Resources/surprised.png";

        #endregion


        #region PropertyChange
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string PropName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropName));
            }
        }
        #endregion
    }
}
