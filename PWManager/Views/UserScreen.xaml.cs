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
using PWManager.Security;
using System.Linq;
using PWManager.ViewModels;
using PWManager.Services;

namespace PWManager
{
    /// <summary>
    /// Interaction logic for UserScreen.xaml
    /// </summary>
    public partial class UserScreen : UserControl
    {        
        
        //public UserScreen()
        //{
        //    this.InitializeComponent();
        //    UserScreenTitle.Content = "Register New User";            
        //    isUpdate = false;                       
        //}

        //public UserScreen(Guid userId)
        //{
        //    this.InitializeComponent();
        //    UserScreenTitle.Content = "Update User";
        //    RegisterBtn.Content = "Update";
        //    isUpdate = true;
        //    user = UserViewModel.GetUser(userId);
        //    PrefillForm();
        //}        

        //private void BackBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        //{
        //    if (!isUpdate)
        //    {
        //        Navigator.Navigate(new LoginScreen());
        //    }
        //    else
        //    {
        //        Navigator.Navigate(new AccountView(user.UserId));
        //    }
        //}

        //private void RegisterBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        //{
        //    try
        //    {
        //        if (!isUpdate)
        //        {

        //            if (FormValidation())
        //            {
        //                UserViewModel usr = new UserViewModel
        //                {
        //                    Firstname = Firstname.Text,
        //                    Lastname = Lastname.Text,
        //                    Email = Email.Text,
        //                    Username = Username.Text,
        //                    Password = Password.Password

        //                };
        //                bool success = user.CreateUser(usr);
        //                if (success)
        //                {
        //                    MessageDialog.PromptInfo("User successfully created");
        //                    Navigator.Navigate(new LoginScreen());
        //                }
        //                else
        //                {
        //                    MessageDialog.PromptError("User creation failed.");
        //                }
        //            }
        //            else { MessageDialog.PromptInfo("The data in the form is invalid. Please verify the information you have typed in"); }
        //        }
        //        else
        //        {
        //            if (FormValidation())
        //            {
        //                user.Firstname = Firstname.Text;
        //                user.Lastname = Lastname.Text;
        //                user.Email = Email.Text;
        //                user.Username = Username.Text;
        //                user.Password = Password.Password;
        //                UserViewModel.UpdateUser(user);
        //                Navigator.Navigate(new LoginScreen());
        //            }
        //            else
        //            {
        //                MessageDialog.PromptInfo("The data in the form is invalid. Please verify the information you have typed in");
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageDialog.PromptError(ex.Message);
        //    }            
        //}

        //private void PrefillForm()
        //{              
        //            Firstname.Text = user.Firstname;
        //            Lastname.Text = user.Lastname;
        //            Email.Text = user.Email;
        //            Username.Text = user.Username;
        //            Password.Password = user.Password;
                
        //}        

        //private bool FormValidation()
        //{
        //    try
        //    {
        //        if (Firstname.Text.Equals(String.Empty)
        //            && Lastname.Text.Equals(String.Empty)
        //            && Email.Text.Equals(String.Empty)
        //            && Username.Text.Equals(String.Empty)
        //            && Password.Password.Equals(String.Empty))
        //        {
        //            return false;
        //        }
        //        else
        //        {
        //            if (PasswordValidationPolicy(Password.Password)
        //                && EmailAddressVerification.VerifyAddress(Email.Text))
        //            {
        //                return true;
        //            }
        //            return false;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        MessageDialog.PromptError(e.Message);
        //    }
        //    return false;
        //}

        //private bool EmailAddressValidation(string p)
        //{
        //    return true;
        //}

        //private bool PasswordValidationPolicy(string p)
        //{
        //    return true;
        //}       

        //private void DatabaseConnectionComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    Navigator.Navigate(new DatabaseConnectionScreen());            
        //}
    }
}