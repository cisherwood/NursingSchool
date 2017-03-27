namespace _420Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelsUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProgramCourses", "SemesterNumber", c => c.Int(nullable: false));
            AlterColumn("dbo.Campus", "CampusName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Campus", "Address", c => c.String(maxLength: 150));
            AlterColumn("dbo.Enrollments", "Grade", c => c.String(maxLength: 3));
            AlterColumn("dbo.Programs", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Petitions", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.StudentPetitions", "Status", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.StudentPetitions", "SubmitDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ToDoes", "Description", c => c.String(nullable: false, maxLength: 200));
            CreateIndex("dbo.StudentPetitions", "StudentID");
            CreateIndex("dbo.StudentPetitions", "PetitionID");
            AddForeignKey("dbo.StudentPetitions", "PetitionID", "dbo.Petitions", "PetitionID", cascadeDelete: true);
            AddForeignKey("dbo.StudentPetitions", "StudentID", "dbo.Students", "StudentId", cascadeDelete: true);
            DropColumn("dbo.ProgramCourses", "SemesterId");
            DropColumn("dbo.ToDoes", "GroupID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ToDoes", "GroupID", c => c.Int(nullable: false));
            AddColumn("dbo.ProgramCourses", "SemesterId", c => c.Int(nullable: false));
            DropForeignKey("dbo.StudentPetitions", "StudentID", "dbo.Students");
            DropForeignKey("dbo.StudentPetitions", "PetitionID", "dbo.Petitions");
            DropIndex("dbo.StudentPetitions", new[] { "PetitionID" });
            DropIndex("dbo.StudentPetitions", new[] { "StudentID" });
            AlterColumn("dbo.ToDoes", "Description", c => c.String(maxLength: 50));
            AlterColumn("dbo.StudentPetitions", "SubmitDate", c => c.DateTime());
            AlterColumn("dbo.StudentPetitions", "Status", c => c.String());
            AlterColumn("dbo.Petitions", "Name", c => c.String(maxLength: 50));
            AlterColumn("dbo.Programs", "Name", c => c.String());
            AlterColumn("dbo.Enrollments", "Grade", c => c.String());
            AlterColumn("dbo.Campus", "Address", c => c.String(maxLength: 50));
            AlterColumn("dbo.Campus", "CampusName", c => c.String(maxLength: 50));
            DropColumn("dbo.ProgramCourses", "SemesterNumber");
        }
    }
}
