namespace _420Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixesforadvising : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "Program_ProgramId", "dbo.Programs");
            DropIndex("dbo.Students", new[] { "Program_ProgramId" });
            DropColumn("dbo.Students", "Program_ProgramId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "Program_ProgramId", c => c.Int());
            CreateIndex("dbo.Students", "Program_ProgramId");
            AddForeignKey("dbo.Students", "Program_ProgramId", "dbo.Programs", "ProgramId");
        }
    }
}
