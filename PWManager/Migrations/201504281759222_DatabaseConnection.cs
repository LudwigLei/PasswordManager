namespace PWManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseConnection : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DatabaseConnections",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Server = c.String(nullable: false, maxLength: 80),
                        Database = c.String(nullable: false, maxLength: 80),
                        Password = c.String(nullable: false, maxLength: 4000),
                        Username = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Users", "DatabaseConnection_Id", c => c.Guid());
            CreateIndex("dbo.Users", "DatabaseConnection_Id");
            AddForeignKey("dbo.Users", "DatabaseConnection_Id", "dbo.DatabaseConnections", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "DatabaseConnection_Id", "dbo.DatabaseConnections");
            DropIndex("dbo.Users", new[] { "DatabaseConnection_Id" });
            DropColumn("dbo.Users", "DatabaseConnection_Id");
            DropTable("dbo.DatabaseConnections");
        }
    }
}
