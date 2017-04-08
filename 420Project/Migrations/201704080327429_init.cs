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
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Office = c.String(maxLength: 50),
                        UserId = c.Int(nullable: false),
                        Email = c.String(maxLength: 100),
                        ContactNumber = c.String(maxLength: 20),
                        IsAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AdvisorId);
            
            CreateTable(
                "dbo.Campus",
                c => new
                    {
                        CampusID = c.Int(nullable: false, identity: true),
                        CampusName = c.String(nullable: false, maxLength: 100),
                        Address = c.String(maxLength: 150),
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
                        Name = c.String(nullable: false, maxLength: 100),
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
                "dbo.StudentCompliances",
                c => new
                    {
                        SCId = c.Int(nullable: false, identity: true),
                        ExpirationDate = c.DateTime(),
                        SubmissionDate = c.DateTime(),
                        ComplianceId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.SCId)
                .ForeignKey("dbo.Compliances", t => t.ComplianceId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.ComplianceId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        MiddleName = c.String(maxLength: 50),
                        Email = c.String(maxLength: 30),
                        PhoneNumber = c.String(maxLength: 15),
                        Address = c.String(maxLength: 50),
                        AdvisorId = c.Int(nullable: false),
                        Year = c.String(maxLength: 50),
                        DOB = c.DateTime(),
                        NeedCompliance = c.Boolean(nullable: false),
                        CampusId = c.Int(nullable: false),
                        Note = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.StudentId)
                .ForeignKey("dbo.Advisors", t => t.AdvisorId, cascadeDelete: true)
                .ForeignKey("dbo.Campus", t => t.CampusId, cascadeDelete: true)
                .Index(t => t.AdvisorId)
                .Index(t => t.CampusId);
            
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
                        CampusID = c.String(),
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
                        StudentProgramId = c.Int(nullable: false),
                        Grade = c.String(maxLength: 3),
                    })
                .PrimaryKey(t => t.EnrollmentId)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Semesters", t => t.SemesterId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .ForeignKey("dbo.StudentPrograms", t => t.StudentProgramId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.CourseId)
                .Index(t => t.SemesterId)
                .Index(t => t.StudentProgramId);
            
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
                "dbo.StudentPrograms",
                c => new
                    {
                        StudentProgramId = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        ProgramId = c.Int(nullable: false),
                        Status = c.String(),
                        GPA = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.StudentProgramId)
                .ForeignKey("dbo.Programs", t => t.ProgramId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: false)
                .Index(t => t.StudentId)
                .Index(t => t.ProgramId);
            
            CreateTable(
                "dbo.Programs",
                c => new
                    {
                        ProgramId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ProgramId);
            
            CreateTable(
                "dbo.ProgramCourses",
                c => new
                    {
                        ProgramCourseId = c.Int(nullable: false, identity: true),
                        ProgramId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        SemesterNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProgramCourseId)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Programs", t => t.ProgramId, cascadeDelete: true)
                .Index(t => t.ProgramId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 250),
                        Location = c.String(maxLength: 150),
                        IsRecruitmentEvent = c.Boolean(nullable: false),
                        Date = c.DateTime(),
                    })
                .PrimaryKey(t => t.EventId);
            
            CreateTable(
                "dbo.GroupFilterCompliances",
                c => new
                    {
                        GroupFilterComplianceId = c.Int(nullable: false, identity: true),
                        GroupFilterId = c.Int(nullable: false),
                        ComplianceId = c.Int(nullable: false),
                        CheckCompliance = c.Boolean(nullable: false),
                        IsCompliant = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.GroupFilterComplianceId)
                .ForeignKey("dbo.Compliances", t => t.ComplianceId, cascadeDelete: true)
                .ForeignKey("dbo.GroupFilters", t => t.GroupFilterId, cascadeDelete: true)
                .Index(t => t.GroupFilterId)
                .Index(t => t.ComplianceId);
            
            CreateTable(
                "dbo.GroupFilters",
                c => new
                    {
                        GroupFilterId = c.Int(nullable: false, identity: true),
                        ToDoId = c.Int(nullable: false),
                        GroupId = c.Int(nullable: false),
                        UserType = c.String(),
                        IsFreshman = c.Boolean(nullable: false),
                        IsSophomore = c.Boolean(nullable: false),
                        IsJunior = c.Boolean(nullable: false),
                        IsSenior = c.Boolean(nullable: false),
                        AdvisorId = c.Int(nullable: false),
                        GPAMin = c.Double(nullable: false),
                        GPAMax = c.Double(nullable: false),
                        CampusId = c.Int(nullable: false),
                        StatusEnrolled = c.Boolean(nullable: false),
                        StatusUnEnrolled = c.Boolean(nullable: false),
                        StatusGraduated = c.Boolean(nullable: false),
                        Petition = c.Boolean(nullable: false),
                        FilterByCompliance = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.GroupFilterId);
            
            CreateTable(
                "dbo.GroupFilterPrograms",
                c => new
                    {
                        GroupFilterProgramId = c.Int(nullable: false, identity: true),
                        GroupFilterId = c.Int(nullable: false),
                        ProgramId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GroupFilterProgramId)
                .ForeignKey("dbo.GroupFilters", t => t.GroupFilterId, cascadeDelete: true)
                .ForeignKey("dbo.Programs", t => t.ProgramId, cascadeDelete: true)
                .Index(t => t.GroupFilterId)
                .Index(t => t.ProgramId);
            
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        NotificationId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.NotificationId);
            
            CreateTable(
                "dbo.Petitions",
                c => new
                    {
                        PetitionID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
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
                        Status = c.String(nullable: false, maxLength: 30),
                        SubmitDate = c.DateTime(nullable: false),
                        StudentID = c.Int(nullable: false),
                        PetitionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentPetitionID)
                .ForeignKey("dbo.Petitions", t => t.PetitionID, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.StudentID)
                .Index(t => t.PetitionID);
            
            CreateTable(
                "dbo.ToDoes",
                c => new
                    {
                        ToDoID = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 200),
                        CreateDate = c.DateTime(nullable: false),
                        DueDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ToDoID);
            
            CreateTable(
                "dbo.UserEvents",
                c => new
                    {
                        UserEventId = c.Int(nullable: false, identity: true),
                        EventId = c.Int(nullable: false),
                        UserId = c.String(),
                    })
                .PrimaryKey(t => t.UserEventId);
            
            CreateTable(
                "dbo.UserNotifications",
                c => new
                    {
                        UserNotificationId = c.Int(nullable: false, identity: true),
                        NotificationId = c.Int(nullable: false),
                        UserId = c.String(),
                        isComplete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserNotificationId);
            
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
            
            CreateTable(
                "dbo.UserToDoes",
                c => new
                    {
                        UserToDoId = c.Int(nullable: false, identity: true),
                        ToDoId = c.Int(nullable: false),
                        UserId = c.String(),
                        isComplete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserToDoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.StudentPetitions", "StudentID", "dbo.Students");
            DropForeignKey("dbo.StudentPetitions", "PetitionID", "dbo.Petitions");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.GroupFilterCompliances", "GroupFilterId", "dbo.GroupFilters");
            DropForeignKey("dbo.GroupFilterPrograms", "ProgramId", "dbo.Programs");
            DropForeignKey("dbo.GroupFilterPrograms", "GroupFilterId", "dbo.GroupFilters");
            DropForeignKey("dbo.GroupFilterCompliances", "ComplianceId", "dbo.Compliances");
            DropForeignKey("dbo.Courses", "Student_StudentId", "dbo.Students");
            DropForeignKey("dbo.Enrollments", "StudentProgramId", "dbo.StudentPrograms");
            DropForeignKey("dbo.StudentPrograms", "StudentId", "dbo.Students");
            DropForeignKey("dbo.StudentPrograms", "ProgramId", "dbo.Programs");
            DropForeignKey("dbo.ProgramCourses", "ProgramId", "dbo.Programs");
            DropForeignKey("dbo.ProgramCourses", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Enrollments", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Enrollments", "SemesterId", "dbo.Semesters");
            DropForeignKey("dbo.Enrollments", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Courses", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.StudentCompliances", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Students", "CampusId", "dbo.Campus");
            DropForeignKey("dbo.Students", "AdvisorId", "dbo.Advisors");
            DropForeignKey("dbo.StudentCompliances", "ComplianceId", "dbo.Compliances");
            DropForeignKey("dbo.Compliances", "File_Id", "dbo.Files");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.StudentPetitions", new[] { "PetitionID" });
            DropIndex("dbo.StudentPetitions", new[] { "StudentID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.GroupFilterPrograms", new[] { "ProgramId" });
            DropIndex("dbo.GroupFilterPrograms", new[] { "GroupFilterId" });
            DropIndex("dbo.GroupFilterCompliances", new[] { "ComplianceId" });
            DropIndex("dbo.GroupFilterCompliances", new[] { "GroupFilterId" });
            DropIndex("dbo.ProgramCourses", new[] { "CourseId" });
            DropIndex("dbo.ProgramCourses", new[] { "ProgramId" });
            DropIndex("dbo.StudentPrograms", new[] { "ProgramId" });
            DropIndex("dbo.StudentPrograms", new[] { "StudentId" });
            DropIndex("dbo.Enrollments", new[] { "StudentProgramId" });
            DropIndex("dbo.Enrollments", new[] { "SemesterId" });
            DropIndex("dbo.Enrollments", new[] { "CourseId" });
            DropIndex("dbo.Enrollments", new[] { "StudentId" });
            DropIndex("dbo.Courses", new[] { "Student_StudentId" });
            DropIndex("dbo.Courses", new[] { "DepartmentId" });
            DropIndex("dbo.Students", new[] { "CampusId" });
            DropIndex("dbo.Students", new[] { "AdvisorId" });
            DropIndex("dbo.StudentCompliances", new[] { "StudentId" });
            DropIndex("dbo.StudentCompliances", new[] { "ComplianceId" });
            DropIndex("dbo.Compliances", new[] { "File_Id" });
            DropTable("dbo.UserToDoes");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.UserNotifications");
            DropTable("dbo.UserEvents");
            DropTable("dbo.ToDoes");
            DropTable("dbo.StudentPetitions");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Petitions");
            DropTable("dbo.Notifications");
            DropTable("dbo.GroupFilterPrograms");
            DropTable("dbo.GroupFilters");
            DropTable("dbo.GroupFilterCompliances");
            DropTable("dbo.Events");
            DropTable("dbo.ProgramCourses");
            DropTable("dbo.Programs");
            DropTable("dbo.StudentPrograms");
            DropTable("dbo.Semesters");
            DropTable("dbo.Enrollments");
            DropTable("dbo.Departments");
            DropTable("dbo.Courses");
            DropTable("dbo.Students");
            DropTable("dbo.StudentCompliances");
            DropTable("dbo.Files");
            DropTable("dbo.Compliances");
            DropTable("dbo.Campus");
            DropTable("dbo.Advisors");
        }
    }
}
