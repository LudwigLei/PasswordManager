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
using PWManager.Services;
using PWManager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PWManager.Accounts
{
    /// <summary>
    /// Acts on the underlying model, performs CRUD operations for the 'Account' entity
    /// </summary>
    public class AccountViewModel : BindableBase
    {        
        private IAccountRepository _repo = new AccountRepository();        
        public ICommand Save { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand Add { get; set; }
        public ICommand Back { get; set; }


        public AccountViewModel(User user)
        {            
            if (DesignerProperties.GetIsInDesignMode(
                new System.Windows.DependencyObject()))
                return;
            User = user;
            Accounts = new ObservableCollection<Account>(_repo.GetAccountsAsync(user.Id).Result);
            Save = new RelayCommand(AddAccount);
            UpdateCommand = new RelayCommand(Update);
            Back = new RelayCommand(NavBack);
        }

        #region Properties
        private ObservableCollection<Account> _accounts;   
        public ObservableCollection<Account> Accounts
        {
            get
            {
                return _accounts;
            }
            set
            {
                if (_accounts == value) { return; }
                _accounts = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Accounts"));
            }
        }

        private Account _selectedAccount = new Account();
        public Account SelectedAccount
        {
            get
            {
                return _selectedAccount;
            }
            set
            {
                if (_selectedAccount == value) { return; }
                _selectedAccount = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedAccount"));
            }
        }

        private string _accountName;
        public string AccountName
        {
            get { return _accountName; }
            set 
            {
                if (_accountName == value) { return; }
                _accountName = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedAccount"));               
            }
        }

        private string _loginName;
        public string LoginName
        {
            get { return _loginName; }
            set 
            {
                if (_loginName == value) { return; }
                _loginName = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedAccount"));                 
            }
        }

        private string _loginPassword;
        public string LoginPassword
        {
            get { return _loginPassword; }
            set 
            {
                if (_loginPassword == value) { return; }
                _loginPassword = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedAccount"));      
            }
        }

        private string _link;
        public string Link
        {
            get { return _link; }
            set 
            {
                if (_link == value) { return; }
                _link = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedAccount")); 
            }
        }

        private string _comments;                
        public string Comments
        {
            get { return _comments; }
            set 
            {
                if (_comments == value) { return; }
                _comments = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedAccount"));
            }
        }

        private User _user;
        public User User
        {
            get { return _user; }
            set 
            {
                if (_user == value) { return; }
                _user = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedAccount"));                  
            }
        }
        #endregion


        #region Commands
        private void Update()
        {
            Navigator.Navigate(new AccountDetail(this));
        }

        private void NavBack()
        {
            Navigator.Navigate(new AccountView(this.User));
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };  

        private void AddAccount()
        {
            _repo.AddAccountAsync(new Account
            {
                Id = Guid.NewGuid(),
                Name = this.AccountName,
                LoginName = this.LoginName,
                LoginPassword = this.LoginPassword,
                Link = this.Link,
                Comments = this.Comments,
                User = this.User,
                UserId = this.User.Id
            });
            Navigator.Navigate(new AccountView(User));
        }
        #endregion
    }
}