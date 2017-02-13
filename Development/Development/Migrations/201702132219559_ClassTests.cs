namespace Development.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClassTests : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Campus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zipcode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        text = c.String(),
                        start_date = c.DateTime(nullable: false),
                        end_date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.Courses", "Subject", c => c.String());
            AddColumn("dbo.Courses", "CatalogNumber", c => c.String());
            AddColumn("dbo.Courses", "Credits", c => c.Int(nullable: false));
            AddColumn("dbo.Courses", "ProgramId", c => c.Int(nullable: false));
            AddColumn("dbo.Courses", "CampusId", c => c.Int(nullable: false));
            AddColumn("dbo.Enrollments", "ProgramId", c => c.Int(nullable: false));
            AddColumn("dbo.Students", "MiddleName", c => c.String());
            AddColumn("dbo.Students", "Address", c => c.String());
            AddColumn("dbo.Students", "City", c => c.String());
            AddColumn("dbo.Students", "Zipcode", c => c.Int(nullable: false));
            AddColumn("dbo.Students", "Email", c => c.String());
            AddColumn("dbo.Students", "PhoneNumber", c => c.String());
            AddColumn("dbo.Students", "HasGraduated", c => c.Boolean(nullable: false));
            AddColumn("dbo.Students", "CampusID", c => c.Int(nullable: false));
            CreateIndex("dbo.Enrollments", "ProgramId");
            AddForeignKey("dbo.Enrollments", "ProgramId", "dbo.Programs", "ProgramId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Enrollments", "ProgramId", "dbo.Programs");
            DropIndex("dbo.Enrollments", new[] { "ProgramId" });
            DropColumn("dbo.Students", "CampusID");
            DropColumn("dbo.Students", "HasGraduated");
            DropColumn("dbo.Students", "PhoneNumber");
            DropColumn("dbo.Students", "Email");
            DropColumn("dbo.Students", "Zipcode");
            DropColumn("dbo.Students", "City");
            DropColumn("dbo.Students", "Address");
            DropColumn("dbo.Students", "MiddleName");
            DropColumn("dbo.Enrollments", "ProgramId");
            DropColumn("dbo.Courses", "CampusId");
            DropColumn("dbo.Courses", "ProgramId");
            DropColumn("dbo.Courses", "Credits");
            DropColumn("dbo.Courses", "CatalogNumber");
            DropColumn("dbo.Courses", "Subject");
            DropTable("dbo.Events");
            DropTable("dbo.Campus");
        }
    }
}
