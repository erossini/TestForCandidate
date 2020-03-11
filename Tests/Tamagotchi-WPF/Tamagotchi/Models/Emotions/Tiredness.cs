using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagotchi.Models.Emotions
{
    public class Tiredness : Base, INotifyPropertyChanged
    {
        #region Properties

        private int _level;
        /// <summary>
        /// Gets or sets the tiredness level of the parent from a scale of 1 to LEVELMAX
        /// </summary>
        public int Level
        {
            get { return _level; }
            set
            {
                _level = value;
                OnPropertyChanged("Level");

                // ensures tiredness never goes over max lever
                if (Level > LEVELMAX)
                    Level--;

                // ensures tiredness never goes less than min level
                if (Level < LEVELMIN)
                    Level++;
            }
        }

        /// <summary>
        /// Gets or sets the path of the tired icon
        /// </summary>
        public string TiredIconPath { get; set; } = "/Tamagotchi;component/Resources/tired.png";

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
