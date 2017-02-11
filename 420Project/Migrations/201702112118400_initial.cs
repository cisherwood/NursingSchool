namespace _420Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseId = c.Int(nullable: false, identity: true),
                        DepartmentId = c.Int(nullable: false),
                        Number = c.String(),
                        Title = c.String(),
                        Description = c.String(),
                        Student_StudentId = c.Int(),
                    })
                .PrimaryKey(t => t.CourseId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.Student_StudentId)
                .Index(t => t.DepartmentId)
                .Index(t => t.Student_StudentId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Enrollments",
                c => new
                    {
                        EnrollmentId = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        SemesterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EnrollmentId)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Semesters", t => t.SemesterId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.CourseId)
                .Index(t => t.SemesterId);
            
            CreateTable(
                "dbo.Semesters",
                c => new
                    {
                        SemesterId = c.Int(nullable: false, identity: true),
                        Year = c.Int(nullable: false),
                        Season = c.String(),
                    })
                .PrimaryKey(t => t.SemesterId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.StudentId);
            
            CreateTable(
                "dbo.ProgramCourses",
                c => new
                    {
                        ProgramCourseId = c.Int(nullable: false, identity: true),
                        ProgramId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        Semester = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProgramCourseId)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Programs", t => t.ProgramId, cascadeDelete: true)
                .Index(t => t.ProgramId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.Programs",
                c => new
                    {
                        ProgramId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ProgramId);
            
            CreateTable(
                "dbo.StudentPrograms",
                c => new
                    {
                        StudentProgramId = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        ProgramId = c.Int(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.StudentProgramId)
                .ForeignKey("dbo.Programs", t => t.ProgramId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.ProgramId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentPrograms", "StudentId", "dbo.Students");
            DropForeignKey("dbo.StudentPrograms", "ProgramId", "dbo.Programs");
            DropForeignKey("dbo.ProgramCourses", "ProgramId", "dbo.Programs");
            DropForeignKey("dbo.ProgramCourses", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Enrollments", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Courses", "Student_StudentId", "dbo.Students");
            DropForeignKey("dbo.Enrollments", "SemesterId", "dbo.Semesters");
            DropForeignKey("dbo.Enrollments", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Courses", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.StudentPrograms", new[] { "ProgramId" });
            DropIndex("dbo.StudentPrograms", new[] { "StudentId" });
            DropIndex("dbo.ProgramCourses", new[] { "CourseId" });
            DropIndex("dbo.ProgramCourses", new[] { "ProgramId" });
            DropIndex("dbo.Enrollments", new[] { "SemesterId" });
            DropIndex("dbo.Enrollments", new[] { "CourseId" });
            DropIndex("dbo.Enrollments", new[] { "StudentId" });
            DropIndex("dbo.Courses", new[] { "Student_StudentId" });
            DropIndex("dbo.Courses", new[] { "DepartmentId" });
            DropTable("dbo.StudentPrograms");
            DropTable("dbo.Programs");
            DropTable("dbo.ProgramCourses");
            DropTable("dbo.Students");
            DropTable("dbo.Semesters");
            DropTable("dbo.Enrollments");
            DropTable("dbo.Departments");
            DropTable("dbo.Courses");
        }
    }
}
