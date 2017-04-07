namespace _420Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class useridtostring : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserEvents", "UserId", c => c.String());
            AlterColumn("dbo.UserNotifications", "UserId", c => c.String());
            AlterColumn("dbo.UserToDoes", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserToDoes", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.UserNotifications", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.UserEvents", "UserId", c => c.Int(nullable: false));
        }
    }
}
