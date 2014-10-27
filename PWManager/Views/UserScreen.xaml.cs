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

namespace PWManager
{
    /// <summary>
    /// Interaction logic for UserScreen.xaml
    /// </summary>
    public partial class UserScreen : UserControl
    {
        private bool isUpdate;
        private UserViewModel user = new UserViewModel();

        public UserScreen()
        {
            this.InitializeComponent();
            UserScreenTitle.Content = "Register New User";
            isUpdate = false;
        }

        public UserScreen(Guid userId)
        {
            this.InitializeComponent();
            UserScreenTitle.Content = "Update User";
            RegisterBtn.Content = "Update";
            isUpdate = true;
            user = UserViewModel.GetUser(userId);
            PrefillForm();
        }

        private void BackBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (!isUpdate)
            {
                Navigator.Navigate(new LoginScreen());
            }
            else
            {
                Navigator.Navigate(new AccountScreen(user.UserId));
            }
        }

        private void RegisterBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                if (!isUpdate)
                {

                    if (FormValidation())
                    {
                        UserViewModel usr = new UserViewModel
                        {
                            Firstname = Firstname.Text,
                            Lastname = Lastname.Text,
                            Email = Email.Text,
                            Username = Username.Text,
                            Password = Password.Password

                        };
                        bool success = user.CreateUser(usr);
                        if (success)
                        {
                            PromptInfo("User successfully created");
                        }
                        else
                        {
                            PromptError("User creation failed.");
                        }
                    }
                    else { PromptInfo("The data in the form is invalid. Please verify the information you have typed in"); }
                }
                else
                {
                    if (FormValidation())
                    {
                        user.Firstname = Firstname.Text;
                        user.Lastname = Lastname.Text;
                        user.Email = Email.Text;
                        user.Username = Username.Text;
                        user.Password = Password.Password;
                        UserViewModel.UpdateUser(user);
                    }
                    else
                    {
                        PromptInfo("The data in the form is invalid. Please verify the information you have typed in");
                    }
                }
            }
            catch (Exception ex)
            {
                PromptError(ex.Message);
            }
            Navigator.Navigate(new LoginScreen());
        }

        private void PrefillForm()
        {              
                    Firstname.Text = user.Firstname;
                    Lastname.Text = user.Lastname;
                    Email.Text = user.Email;
                    Username.Text = user.Username;
                    Password.Password = user.Password;
                
        }

        private bool FormValidation()
        {
            try
            {
                if (Firstname.Text.Equals(String.Empty)
                    && Lastname.Text.Equals(String.Empty)
                    && Email.Text.Equals(String.Empty)
                    && Username.Text.Equals(String.Empty)
                    && Password.Password.Equals(String.Empty))
                {
                    return false;
                }
                else
                {
                    if (PasswordValidationPolicy(Password.Password)
                        && EmailAddressValidation(Email.Text))
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                PromptError(e.Message);
            }
            return false;
        }

        private bool EmailAddressValidation(string p)
        {
            return true;
        }

        private bool PasswordValidationPolicy(string p)
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