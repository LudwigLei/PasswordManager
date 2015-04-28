using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PWManager.Utilities
{
    public static class MessageDialog
    {
        public static void PromptError(string msg)
        {
            const string caption = "Error";
            MessageBoxImage icon = MessageBoxImage.Error;
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBox.Show(msg, caption, button, icon);
        }

        public static void PromptInfo(string msg)
        {
            const string caption = "Info";
            MessageBoxImage icon = MessageBoxImage.Information;
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBox.Show(msg, caption, button, icon);
        }
    }
}
