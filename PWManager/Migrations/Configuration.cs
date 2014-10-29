namespace PWManager.Migrations
{
    using PWManager.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PWManager.Models.PWManagerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "PWManager.Models.PWManagerContext";
        }

        protected override void Seed(PWManager.Models.PWManagerContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //context.Categories.AddOrUpdate(
            //  c => c.Name,
            //  new Category { Name = "Windows", Id = Guid.NewGuid() },
            //  new Category { Name = "Mac", Id = Guid.NewGuid() },
            //  new Category { Name = "Linux", Id = Guid.NewGuid() },
            //  new Category { Name = "Online", Id = Guid.NewGuid() }
            //);            
        }
    }
}
