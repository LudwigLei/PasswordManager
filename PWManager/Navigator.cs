using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PWManager
{
    public static class Navigator
    {
        public static MainWindow mainWindow;

        public static void Navigate(UserControl page)
        {
            mainWindow.Navigate(page);
        }
    }
}
