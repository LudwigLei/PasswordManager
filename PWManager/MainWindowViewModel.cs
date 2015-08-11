using PWManager.Accounts;
using PWManager.Models;
using PWManager.Services;
using PWManager.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWManager
{
    /// <summary>
    /// 
    /// </summary>
    public class MainWindowViewModel : BindableBase
    {

        private AccountViewModel _accountViewModel;
        private UserViewModel _userViewModel = new UserViewModel();        
        public RelayCommand<string> NavigationCommand { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public MainWindowViewModel()
        {
            NavigationCommand = new RelayCommand<string>(OnNavigation);
        }

        private void NavigateToAccountView(User usr)
        {
            _accountViewModel = new AccountViewModel(usr);
            CurrentViewModel = _accountViewModel;            
        }

        /// <summary>
        /// 
        /// </summary>
        private BindableBase _currentViewModel;
        public BindableBase CurrentViewModel
        {
            get { return _currentViewModel; }
            set { SetProperty(ref _currentViewModel, value); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="destination"></param>
        private void OnNavigation(string destination)
        {
            switch (destination)
            {
                case "accounts":
                    CurrentViewModel = _accountViewModel;
                    break;               
                case "register":
                    CurrentViewModel = _userViewModel;
                    break;              
            }
        }


    }
}
