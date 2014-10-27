using PasswordManager.Models;
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
        public static bool CreateAccount(AccountViewModel account, Guid userId)
        {
            try
            {
                using (PWManagerContext db = new PWManagerContext())
                {
                    var user = db.Users.Where(x => x.Id.Equals(userId)).Single();
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
                    return true;
                }
            }
            catch (Exception e)
            {

            }
            return false;
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
                    var account = db.Accounts.Where(x => x.Id.Equals(accountId)).Single();
                    user.Accounts.Remove(account);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {

            }
            return false;
        }

        public static bool UpdateAccount(AccountViewModel account)
        {
            try
            {
                using (PWManagerContext db = new PWManagerContext())
                {                    
                    var result = db.Accounts.Where(x => x.Id.Equals(account.AccountId)).Single();
                    result.Name = account.Name;
                    result.LoginName = account.LoginName;
                    result.LoginPassword = account.LoginPassword;
                    result.Link = account.Link;
                    result.Comments = account.Comments;
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {

            }
            return false;
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

        public override string ToString()
        {
            return this.Name;
        }
    }
}