using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for RaceConfigurationUserControl.xaml
    /// </summary>
    public partial class RaceConfigurationUserControl : UserControl
    {
        private RunnerFactory RunnerFactory;
        public Window ParentControl { get; set; }
        public IRaceConfiguration RaceConfiguration { get; private set; }
        private List<Runner> Runners;
        public RaceConfigurationUserControl(IRaceConfiguration raceConfiguration)
        {
            InitializeComponent();
            RaceConfiguration = raceConfiguration;
            RunnerFactory = new RunnerFactory();


        }


        private void Button_Save_Configuration_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var oldValues = RaceConfiguration.GetRunners();
                RaceConfiguration.InitializeRunners();
                foreach (var runner in Runners)
                {

                    if (String.IsNullOrEmpty(runner.FractionalRepresentation) && String.IsNullOrEmpty(runner.RunnerName))
                    {
                        continue;//ignore empty rows
                    }
                    if (!RaceConfiguration.AddRunner(runner))
                    {
                        return;
                    }
                }


                if (!RaceConfiguration.IsRaceConfigured())
                {
                    return;
                }
                Window.GetWindow(this).Close();

            }
            catch (Exception ex)
            {
                Logger.Log(message: ex.Message, stacktrace: ex.StackTrace);
            }

        }

        private void UserControl_Configuration_Loaded(object sender, RoutedEventArgs e)
        {
            if (RaceConfiguration.GetRunners().Count > 0)
            {
                Runners = RaceConfiguration.GetRunners();
            }
            else
            {
                Runners = new List<Runner>();
                for (int i = 0; i < RaceConfiguration.GetMaximumRunners(); i++)
                {
                    var dummyRunner = RunnerFactory.CreaterRunner("HORSE"); ;

                    Runners.Add(dummyRunner);
                }
            }

            DataGrid_Configuration.ItemsSource = Runners;
            // Runners.Remove(dummyRunner);
        }

        private void Button_Reset_Configuration_Click(object sender, RoutedEventArgs e)
        {
            InitializeRunnersList();
            DataGrid_Configuration.ItemsSource = Runners;

        }

        /// <summary>
        /// WPF seems to have a bug in adding Rows to the datagrid this is a workaround
        /// </summary>
        private void InitializeRunnersList()
        {
            Runners = new List<Runner>();
            for (int i = 0; i < RaceConfiguration.GetMaximumRunners(); i++)
            {
                var dummyRunner = RunnerFactory.CreaterRunner("HORSE");
                Runners.Add(dummyRunner);
            }

        }
    }
}
