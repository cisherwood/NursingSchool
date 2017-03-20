namespace _420Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelsupdate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Advisors",
                c => new
                    {
                        AdvisorId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Title = c.String(),
                        TitleDescription = c.String(),
                        Office = c.String(),
                        UserId = c.Int(nullable: false),
                        Email = c.String(),
                        ContactNumber = c.String(),
                    })
                .PrimaryKey(t => t.AdvisorId);
            
            CreateTable(
                "dbo.Campus",
                c => new
                    {
                        CampusID = c.Int(nullable: false, identity: true),
                        CampusName = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.CampusID);
            
            CreateTable(
                "dbo.Compliances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Location = c.String(),
                        IsRecruitmentEvent = c.Boolean(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Time = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EventId);
            
            CreateTable(
                "dbo.Petitions",
                c => new
                    {
                        PetitionID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.PetitionID);
            
            CreateTable(
                "dbo.StudentCompliances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExpirationDate = c.DateTime(nullable: false),
                        SubmissionDate = c.DateTime(nullable: false),
                        ComplianceId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Compliances", t => t.ComplianceId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.ComplianceId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.StudentPetitions",
                c => new
                    {
                        StudentPetitionID = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                        SubmitDate = c.DateTime(nullable: false),
                        StudentID = c.Int(nullable: false),
                        PetitionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentPetitionID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentCompliances", "StudentId", "dbo.Students");
            DropForeignKey("dbo.StudentCompliances", "ComplianceId", "dbo.Compliances");
            DropIndex("dbo.StudentCompliances", new[] { "StudentId" });
            DropIndex("dbo.StudentCompliances", new[] { "ComplianceId" });
            DropTable("dbo.StudentPetitions");
            DropTable("dbo.StudentCompliances");
            DropTable("dbo.Petitions");
            DropTable("dbo.Events");
            DropTable("dbo.Compliances");
            DropTable("dbo.Campus");
            DropTable("dbo.Advisors");
        }
    }
}
