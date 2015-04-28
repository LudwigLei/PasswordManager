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
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWManager.Models
{
    /// <summary>
    /// Definition for the 'Account' entity
    /// </summary>
    public class Account
    {
        /// <summary>
        /// Columns and their attributes.
        /// </summary>
        [Required, Key]
        public Guid Id { get; set; }        
        public Guid UserId { get; set; }        
        public User User { get; set; }
        [Required, StringLength(20)]
        public string Name { get; set; }
        [Required, StringLength(80)]
        public string LoginName { get; set; }
        [Required, StringLength(4000)]
        public string LoginPassword { get; set; }
        [StringLength(255)]
        public string Link { get; set; }
        [StringLength(4000)]
        public string Comments { get; set; }


        /// <summary>
        /// String representation of this object instance.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Name;
        }
    }
}
