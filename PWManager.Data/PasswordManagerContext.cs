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
# region Using
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace PWManager.Models
{

    public partial class PWManagerContext : DbContext
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public PWManagerContext() : base("PWManagerContext") { }       

        /// <summary>
        /// Data set representaing the 'Account' entities.
        /// </summary>
        public DbSet<Account> Accounts { get; set; }

        /// <summary>
        /// Data set representing the 'User'entities
        /// </summary>
        public DbSet<User> Users { get; set; }       

        /// <summary>
        /// Overriden for more detailed error messages
        /// </summary>
        /// <returns></returns>
        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }

        }
    }
}