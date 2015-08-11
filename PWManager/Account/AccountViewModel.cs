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
        private IAccountRepository _repository = new AccountRepository();        
        private ObservableCollection<Account> _accounts;
        private Account _selectedAccount;
        public ICommand SaveCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand Add { get; set; }

        public AccountViewModel() { }


        public AccountViewModel(PWManager.Models.User user)
        {
            if (DesignerProperties.GetIsInDesignMode(
                new System.Windows.DependencyObject()))
                return;           
            Accounts = new ObservableCollection<Account>(_repository.GetAccountsAsync(user.Id).Result);
            SaveCommand = new RelayCommand(AddAccount);
            UpdateCommand = new RelayCommand(Update);            
        }   
        
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
        
        public 

        private void Update()
        {
            //Navigator.Navigate(new ManageAccountScreen(userId, account.AccountId));
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };  

        public void AddAccount()
        {
            _repository.AddAccountAsync(this.SelectedAccount);
        }
    }
}