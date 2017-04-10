namespace _420Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class navropuesrtal : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.UserEvents", "EventId");
            CreateIndex("dbo.UserNotifications", "NotificationId");
            CreateIndex("dbo.UserToDoes", "ToDoId");
            AddForeignKey("dbo.UserEvents", "EventId", "dbo.Events", "EventId", cascadeDelete: true);
            AddForeignKey("dbo.UserNotifications", "NotificationId", "dbo.Notifications", "NotificationId", cascadeDelete: true);
            AddForeignKey("dbo.UserToDoes", "ToDoId", "dbo.ToDoes", "ToDoID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserToDoes", "ToDoId", "dbo.ToDoes");
            DropForeignKey("dbo.UserNotifications", "NotificationId", "dbo.Notifications");
            DropForeignKey("dbo.UserEvents", "EventId", "dbo.Events");
            DropIndex("dbo.UserToDoes", new[] { "ToDoId" });
            DropIndex("dbo.UserNotifications", new[] { "NotificationId" });
            DropIndex("dbo.UserEvents", new[] { "EventId" });
        }
    }
}
