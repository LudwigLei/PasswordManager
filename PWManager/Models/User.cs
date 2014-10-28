using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace PWManager.Models
{
    public class User
    {      
        [Key, Required]
        public Guid Id { get; set; }
        [Required, StringLength(20)]
        public string Username { get; set; }       
        [Required, StringLength(80)]
        public string Email { get; set; }
        [Required, StringLength(4000)]
        public string Password { get; set; }
        [Required, StringLength(20)]
        public string Firstname { get; set; }
        [Required, StringLength(20)]
        public string Lastname { get; set; }        
        public virtual ICollection<Account> Accounts { get; set; }        
    }
}

