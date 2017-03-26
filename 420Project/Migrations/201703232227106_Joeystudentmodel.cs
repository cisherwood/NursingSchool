namespace _420Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Joeystudentmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Program_ProgramId", c => c.Int());
            AlterColumn("dbo.Advisors", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Advisors", "LastName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Students", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Students", "LastName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Events", "Name", c => c.String(nullable: false, maxLength: 50));
            CreateIndex("dbo.Students", "AdvisorId");
            CreateIndex("dbo.Students", "CampusId");
            CreateIndex("dbo.Students", "Program_ProgramId");
            AddForeignKey("dbo.Students", "AdvisorId", "dbo.Advisors", "AdvisorId", cascadeDelete: true);
            AddForeignKey("dbo.Students", "CampusId", "dbo.Campus", "CampusID", cascadeDelete: true);
            AddForeignKey("dbo.Students", "Program_ProgramId", "dbo.Programs", "ProgramId");
            DropColumn("dbo.Students", "ProgramId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "ProgramId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Students", "Program_ProgramId", "dbo.Programs");
            DropForeignKey("dbo.Students", "CampusId", "dbo.Campus");
            DropForeignKey("dbo.Students", "AdvisorId", "dbo.Advisors");
            DropIndex("dbo.Students", new[] { "Program_ProgramId" });
            DropIndex("dbo.Students", new[] { "CampusId" });
            DropIndex("dbo.Students", new[] { "AdvisorId" });
            AlterColumn("dbo.Events", "Name", c => c.String(maxLength: 50));
            AlterColumn("dbo.Students", "LastName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Students", "FirstName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Advisors", "LastName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Advisors", "FirstName", c => c.String(maxLength: 50));
            DropColumn("dbo.Students", "Program_ProgramId");
        }
    }
}
