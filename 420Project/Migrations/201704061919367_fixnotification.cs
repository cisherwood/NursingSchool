namespace _420Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixnotification : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Notifications", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Notifications", "Name", c => c.Int(nullable: false));
        }
    }
}
