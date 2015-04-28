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
using PWManager.Utilities;

namespace PWManager
{
    /// <summary>
    /// Interaction logic for UserScreen.xaml
    /// </summary>
    public partial class UserScreen : UserControl
    {
        private bool isUpdate;
        private UserViewModel user = new UserViewModel();
        private DatabaseConectionViewModel database = new DatabaseConectionViewModel();

        public UserScreen()
        {
            this.InitializeComponent();
            UserScreenTitle.Content = "Register New User";            
            isUpdate = false;
            DatabaseConnection.Items.Add("New Connection...");             
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

        public UserScreen(DatabaseConectionViewModel db)
        {
            this.InitializeComponent();
            UserScreenTitle.Content = "Register New User";
            isUpdate = false;
            database = db;
            FetchComboBoxItems();
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
                            Navigator.Navigate(new LoginScreen());
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
                        Navigator.Navigate(new LoginScreen());
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
        }

        private void PrefillForm()
        {              
                    Firstname.Text = user.Firstname;
                    Lastname.Text = user.Lastname;
                    Email.Text = user.Email;
                    Username.Text = user.Username;
                    Password.Password = user.Password;
                
        }

        private List<string> FetchComboBoxItems()
        {
            try
            {
                using (PWManagerContext db = new PWManagerContext(database.ToString()))
                {
                    List<DatabaseConnection> list = db.DatabaseConections.ToList();
                    List<string> collection = new List<string>();
                    if (list.Count == 0) 
                    {
                        collection.Add("New Connection...");
                        return collection; 
                    }
                    foreach (var obj in list)
                    {
                        collection.Add(String.Format("{0} on {1}", obj.Database, obj.Server));
                    }
                    return collection;
                }
            }
            catch (Exception e)
            {
                MessageDialog.PromptError(e.Message);
            }
            return null;
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
                        && EmailAddressVerification.VerifyAddress(Email.Text))
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

        private void DatabaseConnectionComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Navigator.Navigate(new DatabaseConnectionScreen());            
        }
    }
}