namespace _420Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixs : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.StudentCompliances");
            DropColumn("dbo.StudentCompliances", "Id");
            CreateTable(
                "dbo.ToDoes",
                c => new
                    {
                        ToDoID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        DueDate = c.DateTime(nullable: false),
                        GroupID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ToDoID);
            
            AddColumn("dbo.StudentCompliances", "SCId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.StudentCompliances", "SCId");

        }
        
        public override void Down()
        {
            AddColumn("dbo.StudentCompliances", "Id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.StudentCompliances");
            DropColumn("dbo.StudentCompliances", "SCId");
            DropTable("dbo.ToDoes");
            AddPrimaryKey("dbo.StudentCompliances", "Id");
        }
    }
}
