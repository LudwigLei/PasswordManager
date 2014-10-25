using PasswordManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.ViewModels
{
    class UserViewModel
    {
        private User _user;

        public User User
        {
            get
            {
                return _user;
            }
            set
            {
                _user = value;
            }
        }

        public string Username
        {
            get
            {
                return _user.Username;
            }
            set
            {
                _user.Username = value;
            }
        }

        public string Email
        {
            get
            {
                return _user.Email;
            }
            set
            {
                _user.Email = value;
            }
        }

        public string Password
        {
            get
            {
                return _user.Password;
            }
            set
            {
                _user.Password = value;
            }
        }

        public string Firstname
        {
            get
            {
                return _user.Firstname;
            }
            set
            {
                _user.Firstname = value;
            }
        }

        public string Lastname
        {
            get
            {
                return _user.Lastname;
            }
            set
            {
                _user.Lastname = value;
            }
        }
        
    }
}
