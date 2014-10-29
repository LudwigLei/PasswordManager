namespace PWManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ColumnLengthChange1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Accounts", "Name", c => c.String(nullable: false, maxLength: 80));
            AlterColumn("dbo.Accounts", "LoginPassword", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Accounts", "LoginPassword", c => c.String(nullable: false, maxLength: 4000));
            AlterColumn("dbo.Accounts", "Name", c => c.String(nullable: false, maxLength: 20));
        }
    }
}
