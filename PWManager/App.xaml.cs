using System;
using System.Windows;

namespace PWManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {      

        private void Application_Startup(object sender, StartupEventArgs e)
        {  
            //string setting = Properties.Settings.Default.ConnectionString;
            //if (!ReferenceEquals(setting, null) || !setting.Equals(String.Empty))
            //{
            //    string conn = Security.Security.Decrypt(setting, "DB_Setup");
            //    databaseConnection = conn;
            //}            
        }

        //private static string databaseConnection = String.Empty;
        //public static string DatabaseConnection 
        //{
        //    get { return databaseConnection; }
        //    set { databaseConnection = value; }
        //}
    }
}
