namespace _420Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserTodos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserToDoes",
                c => new
                    {
                        UserToDoId = c.Int(nullable: false, identity: true),
                        ToDoId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        isComplete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserToDoId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserToDoes");
        }
    }
}
