/*
||  Copyright 2014 Daniel Hamacher
|| 
||  Licensed under the Apache License, Version 2.0 (the "License");
||  you may not use this file except in compliance with the License.
||  You may obtain a copy of the License at
||
||      http://www.apache.org/licenses/LICENSE-2.0
||
||  Unless required by applicable law or agreed to in writing, software
||  distributed under the License is distributed on an "AS IS" BASIS,
||  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
||  See the License for the specific language governing permissions and
||  limitations under the License.
*/
using PWManager.Models;
using PWManager.Services;
using PWManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PWManager
{
    /// <summary>
    /// Interaction logic for DatabaseConnectionScreen.xaml
    /// </summary>
    public partial class DatabaseConnectionScreen : UserControl
    {
        public DatabaseConnectionScreen()
        {
            this.InitializeComponent();
        }

    //    /// <summary>
    //    /// Event for saving new database connection
    //    /// </summary>
    //    /// <param name="sender"></param>
    //    /// <param name="e"></param>
    //    private void SaveBtn_Click(object sender, RoutedEventArgs e)
    //    {
    //        bool success = false;
    //        if (Server.Text.Equals(String.Empty)
    //            && Database.Text.Equals(String.Empty)
    //            && Username.Text.Equals(String.Empty)
    //            && Password.Password.Equals(String.Empty))
    //        {
    //            MessageDialog.PromptError("Please fill out all fields.");
    //        }
    //        else
    //        {
    //            bool configSaved = AddDatabaseToAppConfig();
    //            if (configSaved) { success = TestConnection(); }
    //            if (success)
    //            {
    //                AddDatabaseToAppConfig();
    //                MessageDialog.PromptInfo("Database connection saved.");                    
    //                Navigator.Navigate(new UserScreen());
    //            }
    //            else
    //            {
    //                MessageDialog.PromptError("Connection to database failed");
    //            }
    //        }
    //    }

    //    private bool AddDatabaseToAppConfig()
    //    {           
    //        string isInitialSetup = Security.Security.Encrypt("false", "DB");
    //        string cryptedConnString = Security.Security.Encrypt(this.ToString(), "DB");
    //        Properties.Settings.Default.ConnectionString = cryptedConnString;
    //        Properties.Settings.Default.isInitialSetup = isInitialSetup;
    //        Properties.Settings.Default.Save();
    //        Properties.Settings.Default.Upgrade();
    //        App.DatabaseConnection = this.ToString();
    //        return true;
    //    }

    //    private bool TestConnection()
    //    {
    //        try
    //        {
    //            using (PWManagerContext context = new PWManagerContext())
    //            {
    //                if (context.Database.Exists())
    //                {
    //                    return true;
    //                }
    //                else
    //                {
    //                    context.Database.Create();
    //                }
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            MessageDialog.PromptError(ex.Message);
    //            return false;
    //        }
    //        return false;
    //    }

    //    /// <summary>
    //    /// Navigate back to previous page
    //    /// </summary>
    //    /// <param name="sender"></param>
    //    /// <param name="e"></param>
    //    private void BackBtn_Click(object sender, RoutedEventArgs e)
    //    {
    //        Navigator.Navigate(new UserScreen());
    //    }

    //    /// <summary>
    //    /// Return the connection string of this object.
    //    /// </summary>
    //    /// <returns></returns>
    //    public override string ToString()
    //    {
    //        return String.Format("Data Source={0};Initial Catalog={1};User Id={2};Password={3}", Server.Text, Database.Text, Username.Text, Password.Password);
    //    }
    }
}