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

namespace PWManager
{
	/// <summary>
	/// Interaction logic for AccountScreen.xaml
	/// </summary>
	public partial class AccountScreen : UserControl
	{
        private Guid _userId;
        private List<Account> _accountList;

		public AccountScreen(Guid userId)
		{
            _userId = userId;
            _accountList = GetDataContext(userId);
            this.DataContext = _accountList;
			this.InitializeComponent();
		}

        private void SignOUtBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigator.Navigate(new LoginScreen());
        }

        private List<Account> GetDataContext(Guid userId)
        {
            using (var context = new PasswordManagerContext())
            {
                User usr = context.Users.Where(x => x.Id.Equals(userId)).Single();
                return usr.Accounts.ToList();
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem item = sender as MenuItem;
            if (item.Header.Equals("New Account"))
            {
                Navigator.Navigate(new NewAccountScreen(_userId));
            }

        }

        private void UpdateBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	Navigator.Navigate(new UserScreen(_userId));
        }

        private void AccountListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                ListBox items = sender as ListBox;
                Account acc = _accountList.Where(x => x.AccountName.Equals(items.SelectedItem.ToString())).Single();
                AccountNameTextBox.Text = acc.AccountName;
                AccountPasswordTextBox.Text = acc.AccountPassword;
                AccountUsernameTextBox.Text = acc.AccountUserName;
                AccountCommentsTextBox.Text = acc.Comments;
                AccountLinkTextBox.Text = acc.Link;
            }
            catch (Exception ex)
            {
                PromptError(ex.Message);
            }

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