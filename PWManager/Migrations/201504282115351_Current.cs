namespace PWManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Current : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 20),
                        LoginName = c.String(nullable: false, maxLength: 80),
                        LoginPassword = c.String(nullable: false, maxLength: 4000),
                        Link = c.String(maxLength: 255),
                        Comments = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Username = c.String(nullable: false, maxLength: 20),
                        Email = c.String(nullable: false, maxLength: 80),
                        Password = c.String(nullable: false, maxLength: 4000),
                        Firstname = c.String(nullable: false, maxLength: 20),
                        Lastname = c.String(nullable: false, maxLength: 20),
                        DatabaseConnection_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DatabaseConnections", t => t.DatabaseConnection_Id)
                .Index(t => t.DatabaseConnection_Id);
            
            CreateTable(
                "dbo.DatabaseConnections",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 80),
                        Server = c.String(nullable: false, maxLength: 80),
                        Database = c.String(nullable: false, maxLength: 80),
                        Password = c.String(nullable: false, maxLength: 4000),
                        Username = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "DatabaseConnection_Id", "dbo.DatabaseConnections");
            DropForeignKey("dbo.Accounts", "UserId", "dbo.Users");
            DropIndex("dbo.Users", new[] { "DatabaseConnection_Id" });
            DropIndex("dbo.Accounts", new[] { "UserId" });
            DropTable("dbo.DatabaseConnections");
            DropTable("dbo.Users");
            DropTable("dbo.Accounts");
        }
    }
}
