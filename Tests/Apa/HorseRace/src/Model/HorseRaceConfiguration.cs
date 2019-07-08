using System;
using System.Collections.Generic;
using System.Text;

namespace RunnersGamblingGame
{
    public class HorseRaceConfiguration : IRaceConfiguration
    {
        private RunnerFactory RunnerFactory;
        public List<Runner> Runners { get; set; }
        private double WinningMargin { get; set; }

        private int MaximumRunners;
        private int MinimumRunners;
        public double UpperMarginLimit { get; private set; }
        public double LowerMarginLimit { get; private set; }


        public HorseRaceConfiguration()
        {
            Runners = new List<Runner>();
            RunnerFactory = new RunnerFactory();
            MaximumRunners = 16;
            MinimumRunners = 4;
            UpperMarginLimit = 140;
            LowerMarginLimit = 110;
        }

        public HorseRaceConfiguration(int upperLimit, int lowerLimit)
        {
            RunnerFactory = new RunnerFactory();

            Runners = new List<Runner>();
            MaximumRunners = upperLimit;
            MinimumRunners = lowerLimit;
        }

        public void ClearConfiguration()
        {
            Runners = new List<Runner>();
            WinningMargin = 0;
            MaximumRunners = 16;
            MinimumRunners = 4;
            UpperMarginLimit = 140;
            LowerMarginLimit = 110;

        }


        public bool IsNumberOfParticipantsValid()
        {
            try
            {
                if (Runners == null)
                {
                    return false;
                }
                if (Runners.Count < MinimumRunners || Runners.Count > MaximumRunners)
                {
                    Logger.Log("Number of competitors found to be: " + Runners.Count + " . Should be from " + MinimumRunners + " To " + MaximumRunners + " .");
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                Logger.Log(message: ex.Message, stacktrace: ex.StackTrace);
                return false;
            }
        }

        public bool IsRaceMarginValid()
        {
            try
            {
                double margin = 0;
                if (Runners == null)
                {
                    return false;
                }
                foreach (var runner in Runners)
                {
                    if (runner.FractionalValue == 0)
                    {
                        Logger.Log("Fractional Value found to be 0");
                        return false;
                    }
                    margin += 100 / runner.FractionalValue;
                }
                if (margin > UpperMarginLimit || margin < LowerMarginLimit)
                {
                    Logger.Log("Margin found to be : " + margin + " .Margin should be between: " + LowerMarginLimit + "  and : " + UpperMarginLimit);
                    return false;
                }
                WinningMargin = margin;
                return true;

            }
            catch (Exception ex)
            {
                Logger.Log(message: ex.Message, stacktrace: ex.StackTrace);
                return false;
            }
        }
        /// <summary>
        /// Check if everything is set Correctly
        /// </summary>
        /// <returns></returns>
        public bool IsRaceConfigured()
        {
            try
            {
                if (!IsRaceMarginValid() || !IsNumberOfParticipantsValid())
                {
                    return false ;
                }
                foreach (var runner in Runners)
                {
                    if(!runner.IsNameValid() || !runner.IsFractionalOddPriceValid())
                    {
                        return false;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Logger.Log(message: ex.Message, stacktrace: ex.StackTrace);
                return false;
            }
        }

        public bool AddRunner(Runner horse)
        {
            try
            {
                if (horse == null)
                {
                    return false;
                }
                if (!horse.IsFractionalOddPriceValid() || !horse.IsNameValid())
                {
                    return false;
                }
                Runners.Add(horse);
                WinningMargin += 100 / horse.FractionalValue;
                return true;

            }
            catch (Exception ex)
            {
                Logger.Log(message: ex.Message, stacktrace: ex.StackTrace);
                return false;
            }
        }

        public bool AddRunner(string name, string fractionalValue)
        {
            try
            {
                var runner = RunnerFactory.CreaterRunner("HORSE");
                if (!runner.SetRunnerName(name))
                {
                    return false;
                }
                var value = fractionalValue.Split('/');

                if (value.Length != 2)
                {

                    return false;
                }
                if (!runner.SetFractionalOddPrice(numerator: value[0], denominator: value[1]))
                {
                    return false;
                }
                WinningMargin += 100 / runner.FractionalValue;

                Runners.Add(runner);
                return true;

            }
            catch (Exception ex)
            {
                Logger.Log(message: ex.Message, stacktrace: ex.StackTrace);
                return false;
            }
        }

        public bool RemoverRunner(string name)
        {
            throw new NotImplementedException();
        }

        public double GetMaxWinningMargin()
        {
            return WinningMargin;
        }

        public List<Runner> GetRunners()
        {
            return Runners;
        }

        public double GetMinWinningMargin()
        {
            return LowerMarginLimit;
        }

        public void InitializeRunners()
        {
            this.Runners = new List<Runner>();
        }

        public int GetMaximumRunners()
        {
            return MaximumRunners;
        }

        public int GetMinimumRunners()
        {
            return MinimumRunners;
        }

    }
}
