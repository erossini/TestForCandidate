using RunnersGamblingGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HorseRace
{
    public class RaceWinnerCreator
    {

        private IRaceConfiguration RaceConfiguration;
        private RNGCryptoServiceProvider Rand;

        public RaceWinnerCreator(IRaceConfiguration configuration)
        {
            Rand = new RNGCryptoServiceProvider();
            RaceConfiguration = configuration;
        }

        /// <summary>
        /// Creates a winner based on the runners' fractional values 
        /// </summary>
        /// <returns></returns>
        public Runner GetRaceWinner()
        {
            try
            {

                var winningNumber = GetRandomDouble(0, 100);
                if (winningNumber > 100)
                {
                    return null;
                }
                double winningCandidate = 0;

                var totalMargin = RaceConfiguration.GetMaxWinningMargin();

                foreach (var item in RaceConfiguration.GetRunners())
                {
                    winningCandidate += ((100 / item.FractionalValue) / totalMargin) * 100;

                    if (winningNumber < winningCandidate)
                    {
                        return item;
                    }
                }
                Logger.Log(message: "No winner found please reconfigure the race or contact your service provider.");
                return null;
            }
            catch (Exception ex)
            {
                Logger.Log(message: ex.Message, stacktrace: ex.StackTrace);
                return null;
            }
        }

        private double GetRandomDouble(int min, int max)
        {
            try
            {
                uint scale = uint.MaxValue;
                while (scale == uint.MaxValue)
                {
                    byte[] four_bytes = new byte[4];
                    Rand.GetBytes(four_bytes);

                    scale = BitConverter.ToUInt32(four_bytes, 0);
                }

                return (double)(min + (max - min) *
                    (scale / (double)uint.MaxValue));
            }
            catch (Exception ex)
            {
                Logger.Log(message: ex.Message, stacktrace: ex.StackTrace);
                return 101;//this way a winner cannot be defined
            }

        }
    }
}
