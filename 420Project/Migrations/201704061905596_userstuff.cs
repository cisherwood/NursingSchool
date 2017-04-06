namespace _420Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userstuff : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GroupFilters",
                c => new
                    {
                        GroupFilterId = c.Int(nullable: false, identity: true),
                        ToDoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GroupFilterId);
            
            CreateTable(
                "dbo.UserEvents",
                c => new
                    {
                        UserEventId = c.Int(nullable: false, identity: true),
                        EventId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserEventId);
            
            CreateTable(
                "dbo.UserNotifications",
                c => new
                    {
                        UserNotificationId = c.Int(nullable: false, identity: true),
                        NotificationId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        isComplete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserNotificationId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserNotifications");
            DropTable("dbo.UserEvents");
            DropTable("dbo.GroupFilters");
        }
    }
}
