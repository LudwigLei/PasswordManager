using PWManager.Models;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;
using PWManager.Utilities;

namespace PWManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        private bool runInitialSetup = false;

        public MainWindow()
        {
            InitializeComponent();             
            bool runInitialSetup = isFirstTimeRun();
            Navigator.mainWindow = this;
            if (runInitialSetup) { Navigator.Navigate(new DatabaseConnectionScreen()); }
            else { Navigator.Navigate(new LoginScreen()); }
        }

        public void Navigate(UserControl page)
        {
            this.Content = page;
        } 
      
        private bool isFirstTimeRun()
        {
            try
            {
                string decryptBool = Security.Security.Decrypt(ConfigurationManager.AppSettings["IsInitialSetup"], "DB_Setup");
                bool runInitialSetup = Convert.ToBoolean(decryptBool);
                return runInitialSetup;
            }
            catch (Exception e)
            {
                MessageDialog.PromptError("Please setup the initial database connection");
            }
            return true;
        }
    }
}
