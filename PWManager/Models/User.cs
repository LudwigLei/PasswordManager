
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Models
{
    public class User
    {
        public User()
        {
            _id = Guid.NewGuid();           
        }

        #region Members
        private Guid _id;
        private string _username;
        private string _email;
        private string _password;        
        private string _firstName;
        private string _lastname;
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

        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
            }
        }      

        public string Firstname
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
            }
        }

        public string Lastname
        {
            get
            {
                return _lastname;
            }
            set
            {
                _lastname = value;
            }
        }

        public virtual ICollection<Account> Accounts { get; set; }
        #endregion
    }
}

