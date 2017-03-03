namespace _420Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seeds : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255),
                        ContentType = c.String(maxLength: 100),
                        FileType = c.Int(nullable: false),
                        Content = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Compliances", "File_Id", c => c.Int());
            AlterColumn("dbo.Compliances", "Name", c => c.String(maxLength: 100));
            CreateIndex("dbo.Compliances", "File_Id");
            AddForeignKey("dbo.Compliances", "File_Id", "dbo.Files", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Compliances", "File_Id", "dbo.Files");
            DropIndex("dbo.Compliances", new[] { "File_Id" });
            AlterColumn("dbo.Compliances", "Name", c => c.String());
            DropColumn("dbo.Compliances", "File_Id");
            DropTable("dbo.Files");
        }
    }
}
