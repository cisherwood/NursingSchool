namespace _420Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class passworduseradviso : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Advisors", "Password", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Advisors", "ConfirmPassword", c => c.String());
            AddColumn("dbo.Students", "Password", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Students", "ConfirmPassword", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "ConfirmPassword");
            DropColumn("dbo.Students", "Password");
            DropColumn("dbo.Advisors", "ConfirmPassword");
            DropColumn("dbo.Advisors", "Password");
        }
    }
}
