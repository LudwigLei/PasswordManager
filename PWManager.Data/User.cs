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
    /// <summary>
    /// Definition for the 'User' entity
    /// </summary>
    public class User
    {   
        /// <summary>
        /// Columns and their attributes.
        /// </summary>
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
   
        /// <summary>
        /// Relationship to 'Account' entity
        /// </summary>
        public virtual ICollection<Account> Accounts { get; set; }        
    }
}

