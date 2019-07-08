using HorseRace;
using RunnersGamblingGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RunnersGamblingGame
{
    /// <summary>
    /// Interaction logic for HorseRaceWindow.xaml
    /// </summary>
    public partial class HorseRaceWindow : Window
    {
        RaceConfigurationUserControl HorseRaceConfigurationUserControl;
        private HorseRaceConfiguration HorseRaceConfiguration;
        public HorseRaceWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            HorseRaceConfigurationUserControl = new RaceConfigurationUserControl(new HorseRaceConfiguration());
        }

         private void Button_Configure_Race_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Window window = new Window
                {
                    Title = "Configuration",
                    Content = HorseRaceConfigurationUserControl
                };

                window.ShowDialog();
                this.HorseRaceConfiguration = (HorseRaceConfiguration)HorseRaceConfigurationUserControl.RaceConfiguration;
            }
            catch (Exception ex)
            {
                Logger.Log(message: ex.Message, stacktrace: ex.StackTrace);
            }
        }

        private void Button_Start_Race_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!this.HorseRaceConfiguration.IsRaceConfigured())
                {
                    return;
                }
                var winnerCreator = new RaceWinnerCreator(this.HorseRaceConfiguration);
                var winner = winnerCreator.GetRaceWinner();
                if (winner == null)
                {
                    return;
                }

                string caption = "WE HAVE A WINNER!!!!";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Information;
                MessageBox.Show(owner: this, messageBoxText: "THE WINNER IS :" + winner.RunnerName, caption: caption, button: button,
                    icon: icon, defaultResult: new MessageBoxResult(), options: MessageBoxOptions.RightAlign);

            }
            catch (Exception ex)
            {
                Logger.Log(message: ex.Message, stacktrace: ex.StackTrace);
            }
        }
    }
}
