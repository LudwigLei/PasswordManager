using PWManager.DAL;
using PWManager.Models;
using PWManager.Utilities;
using PWManager.Security;
using System;
using System.Collections.Generic;
using System.Configuration;
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

        private string connectionString = String.Empty;
        public string ConnectionString
        {
            get
            {
                return connectionString;
            }
            set
            {
                if (connectionString == value) { return; }
                connectionString = value;
                RaisePropertyChanged("ConnectionString");
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
                    context.DatabaseConnections.Add(new DatabaseConnection
                        {
                            Id = Guid.NewGuid(),
                            Name = db.Name,
                            Server = db.Server,
                            Database = db.Database,
                            Username = db.UserName,
                            Password = db.Password,
                            ConnectionString = db.ToString()
                        });
                    context.SaveChanges();
                    AddInitialDatabaseToAppConfig(db);

                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private void AddInitialDatabaseToAppConfig(DatabaseConectionViewModel db)
        {
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            string isInitialSetup = Security.Security.Encrypt("false", "DB_Setup");
            string cryptedConnString = Security.Security.Encrypt(db.ConnectionString, "DB_setup");
            config.AppSettings.Settings.Add("ConnectionString", cryptedConnString);

            config.AppSettings.Settings.Add("IsInitialSetup", isInitialSetup);
            config.Save();
            ConfigurationManager.RefreshSection("appSettings");
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
