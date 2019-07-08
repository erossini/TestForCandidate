using System;
using System.Collections.Generic;
using System.Text;

namespace RunnersGamblingGame
{
    public class RunnerFactory
    {
        public Runner CreaterRunner(string runnerType)
        {
            try
            {
                if (runnerType.Equals("HORSE"))
                {
                    return new RacingHorse();
                }
                else
                {
                    throw new Exception("UNKNOWN RUNNER TYPE");
                }
            }
            catch (Exception ex)
            {
                Logger.Log(message: ex.Message, stacktrace: ex.StackTrace);
                return null;
            }
        }
    }
}
