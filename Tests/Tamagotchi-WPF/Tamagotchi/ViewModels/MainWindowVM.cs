using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Input;
using Tamagotchi.Commands;
using Tamagotchi.Models.Emotions;

namespace Tamagotchi.ViewModels
{
    public class MainWindowVM : INotifyPropertyChanged
    {
        #region Properties

        private Models.Tamagotchi _mytamagotchi = new Models.Tamagotchi();
        /// <summary>
        /// Gets or sets the Tamagotchi object
        /// </summary>
        public Models.Tamagotchi MyTamagotchi
        {
            get { return _mytamagotchi; }
            set
            {
                _mytamagotchi = value;
                OnPropertyChanged("MyTamagotchi");
            }
        }

        private string _iconpath;
        /// <summary>
        /// Gets or sets the path of the tamagotchi expression icon
        /// </summary>
        public string IconPath
        {
            get { return _iconpath; }
            set
            {
                _iconpath = value;
                OnPropertyChanged("IconPath");
            }
        }

        private string DefaultExpression = "/Tamagotchi;component/Resources/happy.png";


        private Timer timer1;

        #endregion

        public MainWindowVM()
        {
            // set default expression
            IconPath = DefaultExpression;

            // initialize tamagotchi
            MyTamagotchi.Hunger.HungerLevel = Models.Emotions.Base.LEVELMIN;
            MyTamagotchi.Hunger.FullnessLevel = Models.Emotions.Base.GetValueFromPercent(100);
            MyTamagotchi.Happiness.Level = Models.Emotions.Base.GetValueFromPercent(50);
            MyTamagotchi.Tiredness.Level = Models.Emotions.Base.LEVELMIN;

            // initialize the timer
            timer1 = new Timer();
            timer1.Elapsed += new ElapsedEventHandler(UpdateTamagatchi);
            // Set the Interval to 100 milliseconds.
            timer1.Interval = 100;
            timer1.Enabled = true;
        }

        private void UpdateTamagatchi(object source, ElapsedEventArgs e)
        {
            // increase hunger
            MyTamagotchi.Hunger.HungerLevel++;

            // decrease fullness
            MyTamagotchi.Hunger.FullnessLevel--;

            // increase tiredness
            MyTamagotchi.Tiredness.Level++;

            // decrease happiness
            MyTamagotchi.Happiness.Level--;

            // determine what icon to show depending on different emotions
            if (MyTamagotchi.Tiredness.Level > Models.Emotions.Base.GetValueFromPercent(80))
                IconPath = MyTamagotchi.Tiredness.TiredIconPath;
            else if (MyTamagotchi.Hunger.HungerLevel > Models.Emotions.Base.GetValueFromPercent(80))
                IconPath = MyTamagotchi.Hunger.HungryIconPath;
            else if (MyTamagotchi.Happiness.Level < Models.Emotions.Base.GetValueFromPercent(20))
                IconPath = MyTamagotchi.Happiness.SadIconPath;
            else IconPath = DefaultExpression;
        }        

        #region Events

        private ICommand _feedmealcommand;
        public ICommand FeedMealCommand
        {
            get
            {
                return _feedmealcommand ?? (_feedmealcommand = new ExecuteCommand(param => FeedMeal(param), true));
            }
        }

        /// <summary>
        /// Feed command
        /// </summary>
        public void FeedMeal(object param)
        {
            MyTamagotchi.Hunger.HungerLevel = Models.Emotions.Base.LEVELMIN;
            MyTamagotchi.Hunger.FullnessLevel = Models.Emotions.Base.GetValueFromPercent(100);
        }

        private ICommand _feedsnackcommand;
        public ICommand FeedSnackCommand
        {
            get
            {
                return _feedsnackcommand ?? (_feedsnackcommand = new ExecuteCommand(param => FeedSnack(param), true));
            }
        }

        /// <summary>
        /// Feed command
        /// </summary>
        public void FeedSnack(object param)
        {
            // decrease hunger level by 50%
            MyTamagotchi.Hunger.HungerLevel = MyTamagotchi.Hunger.HungerLevel - Models.Emotions.Base.GetValueFromPercent(50);

            // increase fullness level by 50%
            MyTamagotchi.Hunger.FullnessLevel = MyTamagotchi.Hunger.FullnessLevel + Models.Emotions.Base.GetValueFromPercent(50);
        }

        private ICommand _sleepcommand;
        public ICommand SleepCommand
        {
            get
            {
                return _sleepcommand ?? (_sleepcommand = new ExecuteCommand(param => Sleep(param), true));
            }
        }

        /// <summary>
        /// Sleep command
        /// </summary>
        public void Sleep(object param)
        {
            MyTamagotchi.Tiredness.Level = Models.Emotions.Base.LEVELMIN;
        }

        private ICommand _playcommand;
        public ICommand PlayCommand
        {
            get
            {
                return _playcommand ?? (_playcommand = new ExecuteCommand(param => Play(param), true));
            }
        }

        /// <summary>
        /// Play command
        /// </summary>
        public void Play(object param)
        {
            MyTamagotchi.Tiredness.Level = Models.Emotions.Base.GetValueFromPercent(100);
            MyTamagotchi.Happiness.Level = Models.Emotions.Base.GetValueFromPercent(100);
        }

        private ICommand _poopcommand;
        public ICommand PoopCommand
        {
            get
            {
                return _poopcommand ?? (_poopcommand = new ExecuteCommand(param => Poop(param), true));
            }
        }

        /// <summary>
        /// Poop command
        /// </summary>
        public void Poop(object param)
        {
            MyTamagotchi.Hunger.FullnessLevel = Models.Emotions.Base.LEVELMIN;
        }

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
