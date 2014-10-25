using PasswordManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.ViewModels
{
    class AccountViewModel
    {
        private Account _account;

        public Account Account
        {
            get
            {
                return _account;
            }
            set
            {
                _account = value;
            }
        }

        public string AccountName
        {
            get
            {
                return _account.AccountName;
            }
            set
            {
                _account.AccountName = value;
            }
        }

        public string AccountUserName
        {
            get
            {
                return _account.AccountUserName;
            }
            set
            {
                _account.AccountUserName = value;
            }
        }

        public string AccountPassword
        {
            get
            {
                return _account.AccountPassword;
            }
            set
            {
                _account.AccountPassword = value;
            }
        }

        public string Link
        {
            get
            {
                return _account.Link;
            }
            set
            {
                _account.Link = value;
            }
        }

        public string Comments
        {
            get
            {
                return _account.Comments;
            }
            set
            {
                _account.Comments = value;
            }
        }
    }
}
