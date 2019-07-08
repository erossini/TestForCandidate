using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace RunnersGamblingGame
{
    public class RacingHorse : Runner
    {
        public RacingHorse()
        {
            RunnerName = String.Empty;
            FractionalRepresentation = String.Empty;
            FractionalValue = 0;
        }

        public override bool IsFractionalOddPriceValid(string numerator, string denominator)
        {
            try
            {
                if (String.IsNullOrEmpty(numerator))
                {
                    Logger.Log("Numerator should contain a number > 1");
                    return false;
                }
                else if (String.IsNullOrEmpty(denominator))
                {
                    Logger.Log("Denominator should contain a number > 1");
                    return false;
                }
                else if (!Regex.IsMatch(numerator, @"^[0-9]+$") || !Regex.IsMatch(denominator, @"^[0-9]+$"))
                {
                    Logger.Log("Please use only Numbers");
                    return false;
                }
                int numeratorValue = int.Parse(numerator);
                int denominatorValue = int.Parse(denominator);
                if (numeratorValue >= int.MaxValue)
                {
                    Logger.Log("Please use a smaller number as numerator.");
                    return false;
                }
                if (denominatorValue >= int.MaxValue)
                {
                    Logger.Log("Please use a smaller number as denominator.");
                    return false;
                }
                if (numeratorValue < 1 || denominatorValue < 1)
                {
                    Logger.Log("Both numerator and denominator should be greater than 1.");
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

        public override bool IsFractionalOddPriceValid()
        {
            try
            {
                if (string.IsNullOrEmpty(FractionalRepresentation))
                {
                    Logger.Log("Fractional Representation is not set.");
                    return false;
                }

                var fractionNumbers = FractionalRepresentation.Split('/');
                if (fractionNumbers.Length != 2)
                {
                    Logger.Log("Wrong Fractional Format.");
                    return false;
                }
                if (!IsFractionalOddPriceValid(numerator: fractionNumbers[0], denominator: fractionNumbers[1]))
                {
                    return false;
                }
                //ensure value is up to date
                FractionalValue = 1 + (double.Parse(fractionNumbers[0]) / double.Parse(fractionNumbers[1]));

                return true;

            }
            catch (Exception ex)
            {
                Logger.Log(message: ex.Message, stacktrace: ex.StackTrace);
                return false;
            }
        }

        public override bool IsNameValid(string runnerName)
        {
            try
            {
                if (String.IsNullOrEmpty(runnerName))
                {
                    Logger.Log(message: "Runner's name should be in compliance with British Horseracing Authority");
                    return false;
                }
                if (runnerName.Length > 18)
                {
                    Logger.Log(message: "Runner's name should be in compliance with British Horseracing Authority");
                    return false;
                }
                else if (runnerName.ToCharArray().Any(x => x < 'A' || x > 'Z'))
                {
                    Logger.Log(message: "Runner's name should be in compliance with British Horseracing Authority");
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


        public override bool IsNameValid()
        {
            try
            {
                return IsNameValid(this.RunnerName);
            }
            catch (Exception ex)
            {
                Logger.Log(message: ex.Message, stacktrace: ex.StackTrace);
                return false;
            }
        }
    }
}
