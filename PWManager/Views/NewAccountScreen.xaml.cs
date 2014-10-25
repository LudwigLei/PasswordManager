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
	/// Interaction logic for NewAccountScreen.xaml
	/// </summary>
	public partial class NewAccountScreen : UserControl
	{
        private Guid _userId;

		public NewAccountScreen(Guid userId)
		{
            _userId = userId;
			this.InitializeComponent();
            
		}

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if(FormValidation())
            {
                using (var context = new PasswordManagerContext())
                {
                    User user = context.Users.Where(x => x.Id.Equals(_userId)).Single();
                    string passwordHash = Security.Security.EncryptPassword(AccountPassword.Text);
                    Account acc = new Account
                    {
                        AccountName = AccountName.Text,
                        AccountPassword = AccountPassword.Text,
                        Link = Link.Text,
                        Comments = Comments.Text                       
                    };
                    user.Accounts.Add(acc);
                    context.SaveChanges();                    
                }

            }
        }

        private bool FormValidation()
        {
            return true;
        }

        private void BackBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	Navigator.Navigate(new LoginScreen());
        }
	}
}