namespace _420Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Advisors",
                c => new
                    {
                        AdvisorId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        Title = c.String(maxLength: 50),
                        TitleDescription = c.String(maxLength: 250),
                        Office = c.String(maxLength: 50),
                        UserId = c.Int(nullable: false),
                        Email = c.String(maxLength: 100),
                        ContactNumber = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.AdvisorId);
            
            CreateTable(
                "dbo.Campus",
                c => new
                    {
                        CampusID = c.Int(nullable: false, identity: true),
                        CampusName = c.String(maxLength: 50),
                        Address = c.String(maxLength: 50),
                        City = c.String(maxLength: 50),
                        State = c.String(maxLength: 20),
                        ZipCode = c.String(maxLength: 10),
                        PhoneNumber = c.String(maxLength: 15),
                    })
                .PrimaryKey(t => t.CampusID);
            
            CreateTable(
                "dbo.Compliances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        File_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Files", t => t.File_Id)
                .Index(t => t.File_Id);
            
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
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseId = c.Int(nullable: false, identity: true),
                        DepartmentId = c.Int(nullable: false),
                        Number = c.String(),
                        Title = c.String(),
                        Description = c.String(),
                        ClassHours = c.Int(nullable: false),
                        PassGrade = c.String(),
                        CampusId = c.String(),
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
                        Name = c.String(maxLength: 100),
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
                        Grade = c.String(),
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
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        MiddleName = c.String(maxLength: 50),
                        Email = c.String(maxLength: 30),
                        PhoneNumber = c.String(maxLength: 15),
                        Address = c.String(maxLength: 50),
                        AdvisorId = c.Int(nullable: false),
                        ProgramId = c.Int(nullable: false),
                        HasGraduated = c.Boolean(nullable: false),
                        Standing = c.String(maxLength: 5),
                        Year = c.String(maxLength: 50),
                        DOB = c.DateTime(nullable: false),
                        CampusId = c.Int(nullable: false),
                        Status = c.String(),
                        Note = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.StudentId);
            
            CreateTable(
                "dbo.StudentCompliances",
                c => new
                    {
                        SCId = c.Int(nullable: false, identity: true),
                        ExpirationDate = c.DateTime(),
                        SubmissionDate = c.DateTime(),
                        ComplianceId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SCId)
                .ForeignKey("dbo.Compliances", t => t.ComplianceId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.ComplianceId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.ProgramCourses",
                c => new
                    {
                        ProgramCourseId = c.Int(nullable: false, identity: true),
                        ProgramId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        SemesterId = c.Int(nullable: false),
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
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Description = c.String(maxLength: 250),
                        Location = c.String(maxLength: 150),
                        IsRecruitmentEvent = c.Boolean(nullable: false),
                        Date = c.DateTime(),
                    })
                .PrimaryKey(t => t.EventId);
            
            CreateTable(
                "dbo.Petitions",
                c => new
                    {
                        PetitionID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.PetitionID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.StudentPetitions",
                c => new
                    {
                        StudentPetitionID = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                        SubmitDate = c.DateTime(),
                        StudentID = c.Int(nullable: false),
                        PetitionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentPetitionID);
            
            CreateTable(
                "dbo.ToDoes",
                c => new
                    {
                        ToDoID = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 50),
                        CreateDate = c.DateTime(nullable: false),
                        DueDate = c.DateTime(),
                        GroupID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ToDoID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.StudentPrograms", "StudentId", "dbo.Students");
            DropForeignKey("dbo.StudentPrograms", "ProgramId", "dbo.Programs");
            DropForeignKey("dbo.ProgramCourses", "ProgramId", "dbo.Programs");
            DropForeignKey("dbo.ProgramCourses", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Enrollments", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Courses", "Student_StudentId", "dbo.Students");
            DropForeignKey("dbo.StudentCompliances", "StudentId", "dbo.Students");
            DropForeignKey("dbo.StudentCompliances", "ComplianceId", "dbo.Compliances");
            DropForeignKey("dbo.Enrollments", "SemesterId", "dbo.Semesters");
            DropForeignKey("dbo.Enrollments", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Courses", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Compliances", "File_Id", "dbo.Files");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.StudentPrograms", new[] { "ProgramId" });
            DropIndex("dbo.StudentPrograms", new[] { "StudentId" });
            DropIndex("dbo.ProgramCourses", new[] { "CourseId" });
            DropIndex("dbo.ProgramCourses", new[] { "ProgramId" });
            DropIndex("dbo.StudentCompliances", new[] { "StudentId" });
            DropIndex("dbo.StudentCompliances", new[] { "ComplianceId" });
            DropIndex("dbo.Enrollments", new[] { "SemesterId" });
            DropIndex("dbo.Enrollments", new[] { "CourseId" });
            DropIndex("dbo.Enrollments", new[] { "StudentId" });
            DropIndex("dbo.Courses", new[] { "Student_StudentId" });
            DropIndex("dbo.Courses", new[] { "DepartmentId" });
            DropIndex("dbo.Compliances", new[] { "File_Id" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.ToDoes");
            DropTable("dbo.StudentPetitions");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Petitions");
            DropTable("dbo.Events");
            DropTable("dbo.StudentPrograms");
            DropTable("dbo.Programs");
            DropTable("dbo.ProgramCourses");
            DropTable("dbo.StudentCompliances");
            DropTable("dbo.Students");
            DropTable("dbo.Semesters");
            DropTable("dbo.Enrollments");
            DropTable("dbo.Departments");
            DropTable("dbo.Courses");
            DropTable("dbo.Files");
            DropTable("dbo.Compliances");
            DropTable("dbo.Campus");
            DropTable("dbo.Advisors");
        }
    }
}
