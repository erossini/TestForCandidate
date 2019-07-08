using System;
using System.Collections.Generic;
using System.Text;

namespace RunnersGamblingGame
{
    public interface IRaceConfiguration
    {
        int GetMaximumRunners();
        int GetMinimumRunners();
        void InitializeRunners();
        List<Runner> GetRunners();
        /// <summary>
        /// Returns the race margin as calculated by the runners' fractional values
        /// </summary> 
        /// <returns></returns>
        double GetMaxWinningMargin();

        /// <summary>
        /// Returns the lower possible total race margin 
        /// </summary>
        /// <returns></returns>
        double GetMinWinningMargin();

        bool IsNumberOfParticipantsValid();
        bool IsRaceMarginValid();
        /// <summary>
        /// Checks if everything is set and ready for the race to start.
        /// </summary>
        /// <returns></returns>
        bool IsRaceConfigured();

        bool AddRunner(string name, string fractionalValue);

        bool AddRunner(Runner horse);

        bool RemoverRunner(string name);

    }
}
