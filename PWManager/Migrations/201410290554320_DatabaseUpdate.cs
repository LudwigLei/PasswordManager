namespace PWManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Accounts", "Name", c => c.String(nullable: false, maxLength: 80));
            AlterColumn("dbo.Accounts", "LoginName", c => c.String(nullable: false, maxLength: 80));
            AlterColumn("dbo.Accounts", "LoginPassword", c => c.String(nullable: false, maxLength: 4000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Accounts", "LoginPassword", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Accounts", "LoginName", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Accounts", "Name", c => c.String(nullable: false, maxLength: 20));
        }
    }
}
