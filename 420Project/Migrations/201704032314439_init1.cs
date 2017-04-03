namespace _420Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Advisors", "IsAdmin", c => c.Boolean(nullable: false));
            DropColumn("dbo.Advisors", "Title");
            DropColumn("dbo.Advisors", "TitleDescription");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Advisors", "TitleDescription", c => c.String(maxLength: 250));
            AddColumn("dbo.Advisors", "Title", c => c.String(maxLength: 50));
            DropColumn("dbo.Advisors", "IsAdmin");
        }
    }
}
