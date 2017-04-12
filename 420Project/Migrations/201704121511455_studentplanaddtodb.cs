namespace _420Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class studentplanaddtodb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentPlans",
                c => new
                    {
                        StudentPlanId = c.Int(nullable: false, identity: true),
                        EnrollmentId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        SemesterId = c.Int(nullable: false),
                        ProgramId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentPlanId)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Programs", t => t.ProgramId, cascadeDelete: true)
                .ForeignKey("dbo.Semesters", t => t.SemesterId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.CourseId)
                .Index(t => t.SemesterId)
                .Index(t => t.ProgramId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentPlans", "StudentId", "dbo.Students");
            DropForeignKey("dbo.StudentPlans", "SemesterId", "dbo.Semesters");
            DropForeignKey("dbo.StudentPlans", "ProgramId", "dbo.Programs");
            DropForeignKey("dbo.StudentPlans", "CourseId", "dbo.Courses");
            DropIndex("dbo.StudentPlans", new[] { "ProgramId" });
            DropIndex("dbo.StudentPlans", new[] { "SemesterId" });
            DropIndex("dbo.StudentPlans", new[] { "CourseId" });
            DropIndex("dbo.StudentPlans", new[] { "StudentId" });
            DropTable("dbo.StudentPlans");
        }
    }
}
