namespace _420Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class somefixes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Students", "IsEnrolled", c => c.Boolean(nullable: false));
            AddColumn("dbo.Enrollments", "StudentProgramId", c => c.Int(nullable: false));
            CreateIndex("dbo.Enrollments", "StudentProgramId");
            AddForeignKey("dbo.Enrollments", "StudentProgramId", "dbo.StudentPrograms", "StudentProgramId", cascadeDelete: false);
            DropColumn("dbo.Students", "HasGraduated");
            DropColumn("dbo.Students", "Standing");
            DropColumn("dbo.Students", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "Status", c => c.String());
            AddColumn("dbo.Students", "Standing", c => c.String(maxLength: 5));
            AddColumn("dbo.Students", "HasGraduated", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.Enrollments", "StudentProgramId", "dbo.StudentPrograms");
            DropIndex("dbo.Enrollments", new[] { "StudentProgramId" });
            DropColumn("dbo.Enrollments", "StudentProgramId");
            DropColumn("dbo.Students", "IsEnrolled");
            DropColumn("dbo.Students", "UserId");
        }
    }
}
