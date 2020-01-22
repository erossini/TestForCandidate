using System;

namespace ConnectFour.Tests
{
    public static class Helper
    {
        public static void InvokeSixTimes(Action a)
        {
            for (var i = 0; i < 6; i++)
            {
                a.Invoke();
            }
        }
    }
}