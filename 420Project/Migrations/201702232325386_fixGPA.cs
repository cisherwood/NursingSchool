namespace _420Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixGPA : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "ClassHours", c => c.Int(nullable: false));
            AddColumn("dbo.Courses", "PassGrade", c => c.String());
            AddColumn("dbo.Courses", "CampusId", c => c.String());
            AddColumn("dbo.Enrollments", "Grade", c => c.String());
            AddColumn("dbo.Students", "MiddleName", c => c.String());
            AddColumn("dbo.Students", "Email", c => c.String());
            AddColumn("dbo.Students", "PhoneNumber", c => c.String());
            AddColumn("dbo.Students", "Address", c => c.String());
            AddColumn("dbo.Students", "AdvisorId", c => c.Int(nullable: false));
            AddColumn("dbo.Students", "ProgramId", c => c.Int(nullable: false));
            AddColumn("dbo.Students", "HasGraduated", c => c.Boolean(nullable: false));
            AddColumn("dbo.Students", "Standing", c => c.String());
            AddColumn("dbo.Students", "Year", c => c.String());
            AddColumn("dbo.Students", "DOB", c => c.DateTime(nullable: false));
            AddColumn("dbo.Students", "CampusId", c => c.Int(nullable: false));
            AddColumn("dbo.Students", "Status", c => c.String());
            AddColumn("dbo.Students", "Note", c => c.String());
            AddColumn("dbo.ProgramCourses", "SemesterId", c => c.Int(nullable: false));
            DropColumn("dbo.ProgramCourses", "Semester");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProgramCourses", "Semester", c => c.Int(nullable: false));
            DropColumn("dbo.ProgramCourses", "SemesterId");
            DropColumn("dbo.Students", "Note");
            DropColumn("dbo.Students", "Status");
            DropColumn("dbo.Students", "CampusId");
            DropColumn("dbo.Students", "DOB");
            DropColumn("dbo.Students", "Year");
            DropColumn("dbo.Students", "Standing");
            DropColumn("dbo.Students", "HasGraduated");
            DropColumn("dbo.Students", "ProgramId");
            DropColumn("dbo.Students", "AdvisorId");
            DropColumn("dbo.Students", "Address");
            DropColumn("dbo.Students", "PhoneNumber");
            DropColumn("dbo.Students", "Email");
            DropColumn("dbo.Students", "MiddleName");
            DropColumn("dbo.Enrollments", "Grade");
            DropColumn("dbo.Courses", "CampusId");
            DropColumn("dbo.Courses", "PassGrade");
            DropColumn("dbo.Courses", "ClassHours");
        }
    }
}
