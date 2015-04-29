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
using PWManager.Utilities;

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
            ProgressBAr.Visibility = Visibility.Visible;
            if (UserViewModel.ValidateUserLogin(UsernameInput.Text, PasswordInput.Password))
            {
                Navigator.Navigate(new AccountScreen(UserViewModel.GetUserId(UsernameInput.Text)));
                ProgressBAr.Visibility = Visibility.Hidden;
            }
            else 
            { 
                MessageDialog.PromptError("Login error. The username or password is incorrect.");
                ProgressBAr.Visibility = Visibility.Hidden;
            }           
        }

       

        private void RegisterBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	Navigator.Navigate(new UserScreen());
        }

        private void ResetPasswordBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog.PromptInfo("Not implemented yet");
            // TODO: Implement resetting the password via email.
            //Navigator.Navigate(new ResetPasswordScreen()); 
        }       

        private void PasswordInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (UsernameInput.Text.Equals(String.Empty))
            {
                MessageDialog.PromptInfo("The username field cannot be empty");
            }
            else
            {
                if (e.Key.Equals(Key.Enter))
                {
                    ProgressBAr.Visibility = Visibility.Visible;
                    if (UserViewModel.ValidateUserLogin(UsernameInput.Text, PasswordInput.Password))
                    {
                        Navigator.Navigate(new AccountScreen(UserViewModel.GetUserId(UsernameInput.Text)));
                    }
                    else 
                    { 
                        MessageDialog.PromptError("Login error. The username or password is incorrect.");
                        ProgressBAr.Visibility = Visibility.Hidden;
                    }
                }
            }
        }
        
	}
}