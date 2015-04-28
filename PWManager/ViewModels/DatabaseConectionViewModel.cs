using PWManager.DAL;
using PWManager.Models;
using PWManager.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWManager.ViewModels
{
    public class DatabaseConectionViewModel : ViewModelBase
    {
        private DbStatus status;       

        #region Properties
        private Guid id;
        public Guid Id
        {
            get
            {
                return id;
            }
            set
            {
                if (id == value) { return; }
                id = value;
                RaisePropertyChanged("Id");
            }
        }
        private string server = String.Empty;
        public string Server
        {
            get
            {
                return server;
            }
            set
            {
                if (server == value) { return; }
                server = value;
                RaisePropertyChanged("Server");
            }
        }

        private string userName = String.Empty;
        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                if (userName == value) { return; }
                userName = value;
                RaisePropertyChanged("UserName");
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

        private string database = String.Empty;
        public string Database
        {
            get
            {
                return database;
            }
            set
            {
                if (database == value) { return; }
                database = value;
                RaisePropertyChanged("Database");
            }
        }       
        #endregion

        #region CRUD
        public bool CreateDatabaseConnection(DatabaseConectionViewModel db)
        {
            try
            {
                using (PWManagerContext context = new PWManagerContext(db.ToString()))
                {
                    context.DatabaseConections.Add(new DatabaseConnection
                        {
                            Id = Guid.NewGuid(),
                            Server = db.Server,
                            Database = db.Database,
                            Username = db.UserName,
                            Password = db.Password
                        });
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void UpdateDatabaseConnection(Guid accountId, Guid user_id)
        {
            
        }

        public void DeleteDatabaseConnection(Guid userId, Guid accountId)
        {
            
        }       
        #endregion

        public static DatabaseConectionViewModel GetDatabaseConnectionByName(Guid id, string name)
        {
            return null;
        }       

        /// <summary>
        /// Return the connection string of this object.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format("Data Source={0};Initial Catalog={1};User Id={2};Password={3}", this.Server, this.Database, this.UserName, this.Password);
        }
    }    
}
