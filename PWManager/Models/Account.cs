using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Models
{
    public class Account
    {
        public Account()
        {
            _id = Guid.NewGuid();
        }

        #region Members
        private Guid _id;
        private Guid _userId;
        private User _user;
        private string _accountName;
        private string _accountUserName;
        private string _accountPassword;
        private string _link;
        private string _comments;
        #endregion

        #region Properties
        
        public Guid Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
       
        public Guid UserId 
        { 
            get
            {
                return _userId;
            }
            set
            {
                _userId = value;
            }
        }

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

        public string AccountName
        {
            get
            {
                return _accountName;
            }
            set
            {
                _accountName = value;
            }
        }

        public string AccountUserName
        {
            get
            {
                return _accountUserName;
            }
            set
            {
                _accountUserName = value;
            }
        }

        public string AccountPassword
        {
            get
            {
                return _accountPassword;
            }
            set
            {
                _accountPassword = value;
            }
        }

        public string Link
        {
            get
            {
                return _link;
            }
            set
            {
                _link = value;
            }
        }

        public string Comments
        {
            get
            {
                return _comments;
            }
            set
            {
                _comments = value;
            }
        }

        public override string ToString()
        {
            return this.AccountName;
        }
        #endregion
    }
}
