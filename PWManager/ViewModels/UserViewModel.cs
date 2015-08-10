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
using PWManager.Models;
using PWManager.Security;
using PWManager.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PWManager.ViewModels
{
    public class UserViewModel : ViewModelBase
    {
        private User _currentUser;
        private string _username;
        private string _password;

        private IUserRepository _repo;
        public ICommand Login { get; set; }
        public ICommand Register { get; set; }

        public UserViewModel()
        {
            Login = new RelayCommand(UserLogin);
            Register = new RelayCommand(UserRegistration);            
        }

        public User CurrentUser
        {
            get
            {
                return _currentUser;
            }
            set
            {
                _currentUser = value;
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
        
        private void UserLogin()
        {
            CurrentUser = _repo.GetValidatedUserAsync(Username, Password).Result;
        }  
        
        private void UserRegistration()
        {

        }


    //    #region CRUD
    //    /// <summary>
    //    /// Creates a new User. 
    //    /// </summary>
    //    /// <param name="firstName"></param>
    //    /// <param name="lastName"></param>
    //    /// <param name="username"></param>
    //    /// <param name="password"></param>
    //    /// <param name="email"></param>
    //    /// <returns></returns>
    //    public bool CreateUser(
    //        string firstName
    //        , string lastName
    //        , string username
    //        , string password
    //        , string email)
    //    {
    //        try
    //        {
    //            using (PWManagerContext db = new PWManagerContext())
    //            {

        //                db.Users.Add(new User
        //                {
        //                    Id = Guid.NewGuid(),
        //                    Email = email,
        //                    Firstname = firstName,
        //                    Lastname = lastName,
        //                    Password = Security.Security.HashPassword(password),
        //                    Username = username
        //                });
        //                db.SaveChanges();
        //                return true;
        //            }
        //        }
        //        catch (Exception e)
        //        {

        //        }
        //        return false;
        //    }

        //    public bool CreateUser(UserViewModel user)
        //    {
        //        try
        //        {
        //            using (PWManagerContext db = new PWManagerContext())
        //            {

        //                db.Users.Add(new User
        //                    {
        //                        Id = Guid.NewGuid(),
        //                        Email = user.Email,
        //                        Firstname = user.Firstname,
        //                        Lastname = user.Lastname,
        //                        Password = Security.Security.HashPassword(user.Password),
        //                        Username = user.Username
        //                    });
        //                db.SaveChanges();
        //                return true;
        //            }
        //        }
        //        catch (Exception e)
        //        {

        //        }
        //        return false;
        //    }

        //    public static UserViewModel GetUser(Guid userId)
        //    {
        //        try
        //        {
        //            using (PWManagerContext db = new PWManagerContext())
        //            {
        //                var result = db.Users.Where(x => x.Id.Equals(userId)).Single();
        //                var user = new UserViewModel
        //                {
        //                    Email = result.Email,
        //                    Username = result.Username,
        //                    Firstname = result.Firstname,
        //                    Lastname = result.Lastname,
        //                    UserId = result.Id,
        //                    Password = result.Password
        //                };
        //                return user;
        //            }
        //        }
        //        catch (Exception e)
        //        {

        //        }
        //        return null;
        //    }


        //    public bool DeleteUser(Guid userId)
        //    {
        //        try
        //        {
        //            using (PWManagerContext db = new PWManagerContext())
        //            {
        //                db.Users.Remove(db.Users.Where(x => x.Id.Equals(userId)).Single());
        //                db.SaveChanges();
        //                return true;
        //            }
        //        }
        //        catch (Exception e)
        //        {

        //        }
        //        return false;
        //    }

        //    public static bool UpdateUser(UserViewModel user)
        //    {
        //        try
        //        {
        //            using (PWManagerContext db = new PWManagerContext())
        //            {
        //                var result = db.Users.Where(x => x.Id.Equals(user.UserId)).Single();
        //                result.Email = user.Email;
        //                result.Username = user.Username;
        //                result.Firstname = user.Firstname;
        //                result.Lastname = user.Lastname;
        //                result.Id = user.UserId;
        //                result.Password = Security.Security.HashPassword(user.Password);
        //                db.SaveChanges();
        //                return true;
        //            }
        //        }
        //        catch (Exception e)
        //        {

        //        }
        //        return false;
        //    }

        //    public static ObservableCollection<AccountViewModel> GetUserAccounts(Guid userId)
        //    {
        //        try
        //        {
        //            ObservableCollection<AccountViewModel> list = new ObservableCollection<AccountViewModel>();
        //            using (PWManagerContext db = new PWManagerContext())
        //            {
        //                var result = db.Accounts.Where(x => x.UserId.Equals(userId)).ToList();
        //                foreach (var account in result)
        //                {
        //                    list.Add(new AccountViewModel
        //                        {
        //                            AccountId = account.Id,
        //                            Comments = account.Comments,
        //                            Link = account.Link,
        //                            LoginName = account.LoginName,
        //                            LoginPassword = account.LoginPassword,
        //                            Name = account.Name
        //                        });
        //                }
        //                return list;
        //            }
        //        }
        //        catch (Exception e) { }
        //        return new ObservableCollection<AccountViewModel>();
        //    }

        //    public static bool ValidateUserLogin(string username, string password)
        //    {
        //        try
        //        {
        //            using (PWManagerContext db = new PWManagerContext())
        //            {
        //                var user = db.Users.Where(x => x.Username.Equals(username)).Single();
        //                if (Security.Security.PasswordValdation(password, user.Password))
        //                {
        //                    return true;
        //                }
        //                else { return false; }
        //            }
        //        }
        //        catch (Exception e) { }
        //        return false;

        //    }

        //    public static Guid GetUserId(string username)
        //    {
        //        try
        //        {
        //            using (PWManagerContext db = new PWManagerContext())
        //            {
        //                var user = db.Users.Where(x => x.Username.Equals(username)).Single();
        //                return user.Id;
        //            }
        //        }
        //        catch (Exception e) { }
        //        return new Guid();
        //    }
        //    #endregion       
    }
}
