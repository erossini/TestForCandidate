using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace RunnersGamblingGame
{
    public static class Logger
    {
        public static void Log(string message)
        {
            string caption = "Message";
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Information;
            MessageBox.Show(message, caption, button, icon);

        }

        public static void Log(string message, string stacktrace)
        {
            string caption = "Error";
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Warning;
            MessageBox.Show("ERROR MESSAGE: " + message + "\n Stacktrace: " + stacktrace, caption, button, icon);
        }

    }

}
