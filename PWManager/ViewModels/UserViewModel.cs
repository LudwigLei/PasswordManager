using PWManager.Models;
using PWManager.Security;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWManager.ViewModels
{
    public class UserViewModel : ViewModelBase
    {
        #region Properties
        private Guid userId;
        public Guid UserId
        {
            get
            {
                return userId;
            }
            set
            {
                if (userId == value) { return; }
                userId = value;
                RaisePropertyChanged("UserId");
            }
        }

        private string username = String.Empty;
        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                if (username == value) { return; }
                username = value;
                RaisePropertyChanged("Username");
            }
        }

        private string email = String.Empty;
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                if (email == value) { return; }
                email = value;
                RaisePropertyChanged("Email");
            }
        }

        private string password = String.Empty;
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                if (password == value) { return; }
                password = value;
                RaisePropertyChanged("Password");
            }
        }

        private string firstname = String.Empty;
        public string Firstname
        {
            get
            {
                return firstname;
            }
            set
            {
                if (firstname == value) { return; }
                firstname = value;
                RaisePropertyChanged("Firstname");
            }
        }

        private string lastname = String.Empty;
        public string Lastname
        {
            get
            {
                return lastname;
            }
            set
            {
                if (lastname == value) { return; }
                lastname = value;
                RaisePropertyChanged("Lastname");
            }
        }

        private ObservableCollection<AccountViewModel> accounts;
        public ObservableCollection<AccountViewModel> Accounts
        {
            get
            {
                return accounts;
            }
            set
            {
                accounts = value;
                RaisePropertyChanged("Accounts");
            }
        }
        #endregion

        #region CRUD
        public bool CreateUser(UserViewModel user)
        {
            try
            {
                using (PWManagerContext db = new PWManagerContext())
                {
                    db.Users.Add(new User
                        {
                            Id = Guid.NewGuid(),
                            Email = user.Email,
                            Firstname = user.Firstname,
                            Lastname = user.Lastname,
                            Password = Security.Security.EncryptPassword(user.Password),
                            Username = user.Username
                        });
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {

            }
            return false;
        }

        public static UserViewModel GetUser(Guid userId)
        {
            try
            {
                using (PWManagerContext db = new PWManagerContext())
                {
                    var result = db.Users.Where(x => x.Id.Equals(userId)).Single();
                    var user = new UserViewModel
                    {
                        Email = result.Email,
                        Username = result.Username,
                        Firstname = result.Firstname,
                        Lastname = result.Lastname,
                        UserId = result.Id,
                        Password = result.Password
                    };
                    return user;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }

        public bool DeleteUser(Guid userId)
        {
            try
            {
                using (PWManagerContext db = new PWManagerContext())
                {
                    db.Users.Remove(db.Users.Where(x => x.Id.Equals(userId)).Single());
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {

            }
            return false;
        }

        public static bool UpdateUser(UserViewModel user)
        {
            try
            {
                using (PWManagerContext db = new PWManagerContext())
                {
                    var result = db.Users.Where(x => x.Id.Equals(user.UserId)).Single();
                    result.Email = user.Email;
                    result.Username = user.Username;
                    result.Firstname = user.Firstname;
                    result.Lastname = user.Lastname;
                    result.Id = user.UserId;
                    result.Password = user.Password;
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {

            }
            return false;
        }

        public static ObservableCollection<AccountViewModel> GetUserAccounts(Guid userId)
        {
            try
            {
                ObservableCollection<AccountViewModel> list = new ObservableCollection<AccountViewModel>();
                using (PWManagerContext db = new PWManagerContext())
                {
                    var result = db.Accounts.Where(x => x.UserId.Equals(userId)).ToList();
                    foreach (var account in result)
                    {
                        list.Add(new AccountViewModel
                            {
                                AccountId = account.Id,
                                Comments = account.Comments,
                                Link = account.Link,
                                LoginName = account.LoginName,
                                LoginPassword = account.LoginPassword,
                                Name = account.Name
                            });
                    }
                    return list;
                }
            }
            catch (Exception e) { }
            return new ObservableCollection<AccountViewModel>();
        }

        public static bool ValidateUserLogin(string username, string password)
        {
            try
            {
                using (PWManagerContext db = new PWManagerContext())
                {
                    var user = db.Users.Where(x => x.Username.Equals(username)).Single();
                    if (Security.Security.PasswordValdation(password, user.Password))
                    {
                        return true;
                    }
                    else { return false; }
                }
            }
            catch (Exception e) { }
            return false;

        }

        public static Guid GetUserId(string username)
        {
            try
            {
                using (PWManagerContext db = new PWManagerContext())
                {
                    var user = db.Users.Where(x => x.Username.Equals(username)).Single();
                    return user.Id;
                }
            }
            catch (Exception e) { }
            return new Guid();
        }
        #endregion       
    }
}
