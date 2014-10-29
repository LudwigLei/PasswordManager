﻿using PWManager.Models;
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
using PWManager.DAL;


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
        private DbStatus status = new DbStatus();

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
                if (isUpdate)
                {
                    account.Name = AccountName.Text;
                    account.Comments = Comments.Text;
                    account.Link = Link.Text;
                    account.LoginName = AccountUsername.Text;
                    account.LoginPassword = AccountPassword.Text;
                    status = AccountViewModel.UpdateAccount(account, userId);
                }
                else
                {
                    status = AccountViewModel.CreateAccount(new AccountViewModel
                        {
                            AccountId = Guid.NewGuid(),
                            Comments = Comments.Text,
                            Link = Link.Text,
                            LoginName = AccountUsername.Text,
                            LoginPassword = AccountPassword.Text,
                            Name = AccountName.Text

                        }, userId);                    
                }
                if (status.Success && isUpdate)
                {
                    PromptInfo("Account updated.");
                    Navigator.Navigate(new AccountScreen(userId));
                }
                else if (!status.Success && isUpdate) { PromptError(status.ErrorMessage); }
                else if (!status.Success && !isUpdate) { PromptError(status.ErrorMessage); }
                else if (status.Success) { Navigator.Navigate(new AccountScreen(userId)); }
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