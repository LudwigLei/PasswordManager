using PasswordManager.Models;
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
using System.Linq;
using PWManager.ViewModels;


namespace PWManager
{
    /// <summary>
    /// Interaction logic for NewAccountScreen.xaml
    /// </summary>
    public partial class NewAccountScreen : UserControl
    {
        private Guid userId;
        private AccountViewModel account = new AccountViewModel();

        public NewAccountScreen(Guid id)
        {
            userId = id;
            this.InitializeComponent();

        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (FormValidation())
            {
                bool success = AccountViewModel.CreateAccount(new AccountViewModel
                    {
                        AccountId = Guid.NewGuid(),
                        Comments = Comments.Text,
                        Link = Link.Text,
                        LoginName = AccountUsername.Text,
                        LoginPassword = AccountPassword.Text,
                        Name = AccountName.Text

                    }, userId);
                if (success)
                {
                    Navigator.Navigate(new AccountScreen(userId));
                }
                else { PromptError("Account creation not successful. Use back button to get to the Account screen."); }
            }
        }

        private void BackBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Navigator.Navigate(new LoginScreen());
        }

        private bool FormValidation()
        {
            return true;
        }

        private void PromptError(string msg)
        {
            const string caption = "Error";
            MessageBoxImage icon = MessageBoxImage.Error;
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBox.Show(msg, caption, button, icon);
        }

        private void PromptInfo(string msg)
        {
            const string caption = "Info";
            MessageBoxImage icon = MessageBoxImage.Information;
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBox.Show(msg, caption, button, icon);
        }
    }        
}