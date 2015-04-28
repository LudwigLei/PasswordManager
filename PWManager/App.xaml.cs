using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Data.Entity;
using PWManager.Models;
using PWManager.Utilities;

namespace PWManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //public string DB_STRING = Security.Security.Decrypt(ConfigurationManager.AppSettings["ConnectionString"], "DB_Setup");

        private void Application_Startup(object sender, StartupEventArgs e)
        { 
            //if (DB_STRING == String.Empty || DB_STRING == null)
            //{
            //    MessageDialog.PromptError("Shit hits the fan at App.xaml.cs");
            //}
            
        }
    }
}
