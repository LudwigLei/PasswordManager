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
    public partial class ManageAccountScreen : UserControl
    {
        private Guid userId;
        private Guid accountId;
        private AccountViewModel account = new AccountViewModel();
        private bool isUpdate;

        public ManageAccountScreen(Guid id)
        {
            userId = id;
            this.InitializeComponent();
        }

        public ManageAccountScreen(Guid userId, Guid accountId)
        {
            this.InitializeComponent();
            this.userId = userId;
            this.accountId = accountId;
            account = AccountViewModel.GetAccount(accountId);
            isUpdate = true;            
            ScreenTitle.Content = "Update Account";
            SaveBtn.Content = "Update";
            PrefillForm();
        }

        private void PrefillForm()
        {
            AccountViewModel account = AccountViewModel.GetAccount(accountId);
            AccountName.Text = account.Name;
            AccountUsername.Text = account.LoginName;
            AccountPassword.Text = account.LoginPassword;
            Link.Text = account.Link;
            Comments.Text = account.Comments;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (FormValidation())
            {
                bool success = false;
                if (isUpdate)
                {
                    account.Name = AccountName.Text;
                    account.Comments = Comments.Text;
                    account.Link = Link.Text;
                    account.LoginName = AccountUsername.Text;
                    account.LoginPassword = AccountPassword.Text;
                    success = AccountViewModel.UpdateAccount(account);
                }
                else
                {
                    success = AccountViewModel.CreateAccount(new AccountViewModel
                        {
                            AccountId = Guid.NewGuid(),
                            Comments = Comments.Text,
                            Link = Link.Text,
                            LoginName = AccountUsername.Text,
                            LoginPassword = AccountPassword.Text,
                            Name = AccountName.Text

                        }, userId);                    
                }
                if (success && isUpdate)
                {
                    PromptInfo("Account updated.");
                    Navigator.Navigate(new AccountScreen(userId));
                }
                else if (!success && isUpdate) { PromptError("Account update not successful. Use back button to get to the Account screen."); }
                else if (!success && !isUpdate) { PromptError("Account creation not successful. Use back button to get to the Account screen."); }
                else if (success) { Navigator.Navigate(new AccountScreen(userId)); }
            }
        }

        private void BackBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {            
            Navigator.Navigate(new AccountScreen(userId));
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