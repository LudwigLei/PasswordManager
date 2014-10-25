using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Models
{
    public class PasswordManagerContext : DbContext 
    {
        public PasswordManagerContext()
            : base("SQLCompact")
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<User> Users { get; set; }       
    }
}
