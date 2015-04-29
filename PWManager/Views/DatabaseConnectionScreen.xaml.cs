using PWManager.Utilities;
using PWManager.ViewModels;
using System;
using System.Collections.Generic;
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
        private DatabaseConectionViewModel db = new DatabaseConectionViewModel();

        

		public DatabaseConnectionScreen()
		{
			this.InitializeComponent();
		}      

        /// <summary>
        /// Event for saving new database connections
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Server.Text.Equals(String.Empty)
                && Database.Text.Equals(String.Empty)
                && Username.Text.Equals(String.Empty)
                && Password.Password.Equals(String.Empty))
            {
                MessageDialog.PromptError("Please fill out all fields.");
            }
            else
            {
                db.Name = Name.Text;
                db.Server = Server.Text;
                db.Database = Database.Text;
                db.UserName = Username.Text;
                db.Password = Password.Password;
                db.ConnectionString = db.ToString();
                bool success = db.CreateDatabaseConnection(db);
                if (success)
                {
                    MessageDialog.PromptInfo("Database connection saved.");
                    Navigator.Navigate(new UserScreen(db));
                }
                else
                {
                    MessageDialog.PromptError("Connection to database failed");
                }
            }
        }

        /// <summary>
        /// Navigate back to previous page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigator.Navigate(new UserScreen());
        }
        

	}
}