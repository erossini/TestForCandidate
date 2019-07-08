using System;
using System.Collections.Generic;
using System.Text;

namespace RunnersGamblingGame
{
    public abstract class Runner
    {
        public string RunnerName { get; set; }
        /// <summary>
        /// FractionalRepresentation is in the form of "1/2"
        /// </summary>
        public string FractionalRepresentation { get; set; }

        /// <summary>
        /// FractionalValue is numerator divided by denominator and then added one 
        /// </summary>
        public double FractionalValue { get; protected set; }

        public abstract bool IsNameValid(string runnerName);

        public abstract bool IsNameValid();

        public abstract bool IsFractionalOddPriceValid(string numerator, string denominator);

        public abstract bool IsFractionalOddPriceValid();


        public bool SetRunnerName(string runnerName)
        {
            try
            {
                if (IsNameValid(runnerName: runnerName))
                {
                    this.RunnerName = runnerName;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Logger.Log(message: ex.Message, stacktrace: ex.StackTrace);
                return false;
            }
        }


        public virtual bool SetFractionalOddPrice(string numerator, string denominator)
        {
            try
            {
                if (IsFractionalOddPriceValid(numerator, denominator))
                {
                    this.FractionalRepresentation = numerator + "/" + denominator;
                    this.FractionalValue = (double.Parse(numerator) / double.Parse(denominator)) + 1;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Logger.Log(message: ex.Message, stacktrace: ex.StackTrace);
                return false;
            }
        }
        
    }
}
