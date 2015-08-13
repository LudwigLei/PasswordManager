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
using PWManager.Services;



namespace PWManager.Accounts
{
    /// <summary>
    /// Interaction logic for NewAccountScreen.xaml
    /// </summary>
    public partial class AccountDetail : UserControl
    {
        public AccountDetail(AccountViewModel account)
        {
            this.InitializeComponent();
            this.DataContext = account;            
        }

        //public ManageAccountScreen(Guid userId, Guid accountId)
        //{
        //    this.InitializeComponent();
        //    this.userId = userId;
        //    this.accountId = accountId;
        //    account = AccountViewModel.GetAccount(accountId, userId);
        //    isUpdate = true;            
        //    ScreenTitle.Content = "Update Account";
        //    SaveBtn.Content = "Update";
        //    PrefillForm();
        //}

        //private void PrefillForm()
        //{
        //    AccountViewModel account = AccountViewModel.GetAccount(accountId, userId);
        //    AccountName.Text = account.Name;
        //    AccountUsername.Text = account.LoginName;
        //    AccountPassword.Text = account.LoginPassword;
        //    Link.Text = account.Link;
        //    Comments.Text = account.Comments;
        //}

        //private void SaveBtn_Click(object sender, RoutedEventArgs e)
        //{            
        //    if (FormValidation())
        //    {                
        //        if (isUpdate)
        //        {
        //            account.Name = AccountName.Text;
        //            account.Comments = Comments.Text;
        //            account.Link = Link.Text;
        //            account.LoginName = AccountUsername.Text;
        //            account.LoginPassword = AccountPassword.Text;
        //            status = AccountViewModel.UpdateAccount(account, userId);
        //        }
        //        else
        //        {
        //            status = AccountViewModel.CreateAccount(new AccountViewModel
        //                {
        //                    AccountId = Guid.NewGuid(),
        //                    Comments = Comments.Text,
        //                    Link = Link.Text,
        //                    LoginName = AccountUsername.Text,
        //                    LoginPassword = AccountPassword.Text,
        //                    Name = AccountName.Text

        //                }, userId);                    
        //        }
        //        if (status.Success && isUpdate)
        //        {
        //            MessageDialog.PromptInfo("Account updated.");
        //            Navigator.Navigate(new AccountView(userId));
        //        }
        //        else if (!status.Success && isUpdate) { MessageDialog.PromptError(status.ErrorMessage); }
        //        else if (!status.Success && !isUpdate) { MessageDialog.PromptError(status.ErrorMessage); }
        //        else if (status.Success) { Navigator.Navigate(new AccountView(userId)); }
        //    }
        //}

        //private void BackBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        //{            
        //    Navigator.Navigate(new AccountView(userId));
        //}

        //private bool FormValidation()
        //{
        //    return true;
        //}       
    }        
}