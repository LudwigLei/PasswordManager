using PWManager.DAL;
using PWManager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWManager.ViewModels
{
    public class AccountViewModel : ViewModelBase
    {
        private ObservableCollection<Account> accountList = new ObservableCollection<Account>();
        private static DbStatus status = new DbStatus();

        #region Properties
        private Guid accountId;
        public Guid AccountId
        {
            get
            {
                return accountId;
            }
            set
            {
                if (accountId == value) { return; }
                accountId = value;
                RaisePropertyChanged("AccountId");
            }
        }
        private string name = String.Empty;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (name == value) { return; }
                name = value;
                RaisePropertyChanged("Name");
            }
        }

        private string loginName = String.Empty;
        public string LoginName
        {
            get
            {
                return loginName;
            }
            set
            {
                if (loginName == value) { return; }
                loginName = value;
                RaisePropertyChanged("LoginName");
            }
        }

        private string loginPassword = String.Empty;
        public string LoginPassword
        {
            get
            {
                return loginPassword;
            }
            set
            {
                if (loginPassword == value) { return; }
                loginPassword = value;
                RaisePropertyChanged("LoginPassword");
            }
        }

        private string link = String.Empty;
        public string Link
        {
            get
            {
                return link;
            }
            set
            {
                if (link == value) { return; }
                link = value;
                RaisePropertyChanged("Link");
            }
        }

        private string comments = String.Empty;
        public string Comments
        {
            get
            {
                return comments;
            }
            set
            {
                if (comments == value) { return; }
                comments = value;
                RaisePropertyChanged("Comments");
            }
        }
        #endregion

        #region CRUD
        public static DbStatus CreateAccount(AccountViewModel account, Guid userId)
        {
            try
            {
                using (PWManagerContext db = new PWManagerContext())
                {
                    var user = db.Users.Where(x => x.Id.Equals(userId)).Single();
                    if (user.Accounts.Where(x => x.Name.Equals(account.Name, StringComparison.InvariantCultureIgnoreCase)).ToList().Count != 0)
                    {
                        status.Success = false;
                        status.ErrorMessage = "Account with the name " + account.Name + " already exists.";
                        return status;
                    }
                    Account acc = new Account
                    {
                        Id = Guid.NewGuid(),
                        Name = account.Name,
                        LoginName = account.LoginName,
                        LoginPassword = account.LoginPassword, //Unable to decrypt the password to its plain form Security.Security.EncryptPassword(account.LoginPassword),
                        Link = account.Link,
                        Comments = account.Comments,                        
                    };
                    user.Accounts.Add(acc);
                    db.SaveChanges();
                    status.Success = true;
                    return status;
                }
            }
            catch (Exception e)
            {
                status.Success = false;
                status.ErrorMessage = "Excpetion occured: " + e.Message;
                return status;
            }           
        }

        public static AccountViewModel GetAccount(Guid accountId)
        {
            try
            {
                using (PWManagerContext db = new PWManagerContext())
                {
                    var acc = db.Accounts.Where(x => x.Id.Equals(accountId)).Single();
                    var account = new AccountViewModel
                    {
                        Name = acc.Name,
                        LoginName = acc.LoginName,
                        LoginPassword = acc.LoginPassword,
                        Link = acc.Link,
                        Comments = acc.Comments,
                    };
                    return account;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }

        public static bool DeleteAccount(Guid userId, Guid accountId)
        {
            try
            {
                using (PWManagerContext db = new PWManagerContext())
                {
                    var user = db.Users.Where(x => x.Id.Equals(userId)).Single();
                    var account = user.Accounts.Where(x => x.Id.Equals(accountId)).Single();
                    db.Accounts.Remove(account);                   
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {

            }
            return false;
        }

        public static DbStatus UpdateAccount(AccountViewModel account, Guid userId)
        {
            try
            {
                using (PWManagerContext db = new PWManagerContext())
                {
                    if (!IsDuplicate(account.name, userId))
                    {
                        var result = db.Accounts.Where(x => x.Name.Equals(account.Name) && x.UserId.Equals(userId)).Single();
                        result.Name = account.Name;
                        result.LoginName = account.LoginName;
                        result.LoginPassword = account.LoginPassword;
                        result.Link = account.Link;
                        result.Comments = account.Comments;
                        db.SaveChanges();
                        status.Success = true;
                        return status;
                    }
                    else { throw new Exception("Account with the name " + account.Name + " already exists."); }
                }
            }
            catch (Exception e)
            {
                status.Success = false;
                status.ErrorMessage = "Exception occured: " + e.Message;
                return status;
            }          
        }
        #endregion

        public static AccountViewModel GetAccountByName(Guid userId, string name) 
        {
            try
            {
                using (PWManagerContext db = new PWManagerContext())
                {
                    var result = db.Accounts.Where(x => x.UserId.Equals(userId) && x.Name.Equals(name)).Single();
                    var account = new AccountViewModel
                    {
                        AccountId = result.Id,
                        Comments = result.Comments,
                        Link = result.Link,
                        LoginName = result.LoginName,
                        LoginPassword = result.LoginPassword,
                        Name = result.Name
                    };
                    return account;
                }
            }
            catch (Exception e) { }
            return null;
        }

        private static bool IsDuplicate(string name, Guid userId)
        {
            try
            {
                using (PWManagerContext db = new PWManagerContext())
                {
                    var user = db.Users.Where(x => x.Id.Equals(userId)).Single();
                    List<Account> list = user.Accounts.ToList();
                    Account acc = list.Where(x => x.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase)).Single();
                    if (!acc.Id.Equals(user.Accounts.Where(x => x.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase)).Select(x => x.Id)))
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e) { }
            return true;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}