namespace PWManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeColumnProperty : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Accounts", "Link", c => c.String(maxLength: 255));
            AlterColumn("dbo.Accounts", "Comments", c => c.String(maxLength: 4000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Accounts", "Comments", c => c.String(nullable: false, maxLength: 4000));
            AlterColumn("dbo.Accounts", "Link", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
