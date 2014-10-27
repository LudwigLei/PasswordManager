using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Models
{
    public class Account
    {
        [Required, Key]
        public Guid Id { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public User User { get; set; }
        [Required, StringLength(20)]
        public string Name { get; set; }
        [Required, StringLength(20)]
        public string LoginName { get; set; }
        [Required, StringLength(4000)]
        public string LoginPassword { get; set; }
        [Required, StringLength(255)]
        public string Link { get; set; }
        [Required, StringLength(4000)]
        public string Comments { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
