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
using PWManager.Services;
using System.Collections.ObjectModel;

namespace PWManager
{
	/// <summary>
	/// Interaction logic for LoginScreen.xaml
	/// </summary>
	public partial class AccountView : UserControl
	{
		private AccountViewModel _accounts;
        private UserViewModel _user;

		public AccountView(User user)
		{
            _user = new UserViewModel();
            _user.CurrentUser = user;
            _accounts = new AccountViewModel(user);
			this.DataContext = _accounts;      
			this.InitializeComponent();            
		}

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigator.Navigate(new UserScreen(_user));
        }		
	}
}