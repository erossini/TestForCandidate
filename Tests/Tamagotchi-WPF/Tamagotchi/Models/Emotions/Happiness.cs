using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagotchi.Models.Emotions
{
    public class Happiness : Base, INotifyPropertyChanged
    {
        #region Properties

        //private const int LEVELMAX = 100;

        private int _level;
        /// <summary>
        /// Gets or sets the happiness level of the parent from a scale of 1 to LEVELMAX
        /// </summary>
        public int Level
        {
            get { return _level; }
            set
            {
                _level = value;
                OnPropertyChanged("Level");

                // ensures happiness never goes over max lever
                if (Level > LEVELMAX)
                    Level--;

                // ensures happiness never goes less than min level
                if (Level < LEVELMIN)
                    Level++;
            }
        }

        /// <summary>
        /// Gets or sets the path of the happy icon
        /// </summary>
        public string HappyIconPath { get; set; } = "/Tamagotchi;component/Resources/veryhappy.png";

        /// <summary>
        /// Gets or sets the path of the sad icon
        /// </summary>
        public string SadIconPath { get; set; } = "/Tamagotchi;component/Resources/bored.png";

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
