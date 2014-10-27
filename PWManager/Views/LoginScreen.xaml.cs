using PasswordManager.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
	/// Interaction logic for LoginScreen.xaml
	/// </summary>
	public partial class LoginScreen : UserControl
	{        
		public LoginScreen()
		{
			this.InitializeComponent();            
		}

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            if (UserViewModel.ValidateUserLogin(UsernameInput.Text, PasswordInput.Password))
            {
                Navigator.Navigate(new AccountScreen(UserViewModel.GetUserId(UsernameInput.Text)));
            }
            else { PromptError("Login error. The username or password is incorrect."); }           
        }

        private void PromptError(string msg)
        {
            const string caption = "Login Error!";
            MessageBoxImage icon = MessageBoxImage.Error;
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBox.Show(msg, caption, button, icon);
        }

        private void RegisterBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	Navigator.Navigate(new UserScreen());
        }

        private void ResetPasswordBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigator.Navigate(new ResetPasswordScreen());
        }
	}
}