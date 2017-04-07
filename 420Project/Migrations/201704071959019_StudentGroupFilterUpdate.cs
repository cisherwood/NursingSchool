namespace _420Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudentGroupFilterUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GroupFilters", "GroupId", c => c.Int(nullable: false));
            AddColumn("dbo.GroupFilters", "UserType", c => c.String());
            AddColumn("dbo.GroupFilters", "IsFreshman", c => c.Boolean(nullable: false));
            AddColumn("dbo.GroupFilters", "IsSophomore", c => c.Boolean(nullable: false));
            AddColumn("dbo.GroupFilters", "IsJunior", c => c.Boolean(nullable: false));
            AddColumn("dbo.GroupFilters", "IsSenior", c => c.Boolean(nullable: false));
            AddColumn("dbo.GroupFilters", "AdvisorId", c => c.Int(nullable: false));
            AddColumn("dbo.GroupFilters", "GPAMin", c => c.Double(nullable: false));
            AddColumn("dbo.GroupFilters", "GPAMax", c => c.Double(nullable: false));
            AddColumn("dbo.GroupFilters", "CampusId", c => c.Int(nullable: false));
            AddColumn("dbo.GroupFilters", "StatusEnrolled", c => c.Boolean(nullable: false));
            AddColumn("dbo.GroupFilters", "StatusUnEnrolled", c => c.Boolean(nullable: false));
            AddColumn("dbo.GroupFilters", "StatusGraduated", c => c.Boolean(nullable: false));
            AddColumn("dbo.GroupFilters", "Petition", c => c.Boolean(nullable: false));
            DropColumn("dbo.Students", "IsEnrolled");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "IsEnrolled", c => c.Boolean(nullable: false));
            DropColumn("dbo.GroupFilters", "Petition");
            DropColumn("dbo.GroupFilters", "StatusGraduated");
            DropColumn("dbo.GroupFilters", "StatusUnEnrolled");
            DropColumn("dbo.GroupFilters", "StatusEnrolled");
            DropColumn("dbo.GroupFilters", "CampusId");
            DropColumn("dbo.GroupFilters", "GPAMax");
            DropColumn("dbo.GroupFilters", "GPAMin");
            DropColumn("dbo.GroupFilters", "AdvisorId");
            DropColumn("dbo.GroupFilters", "IsSenior");
            DropColumn("dbo.GroupFilters", "IsJunior");
            DropColumn("dbo.GroupFilters", "IsSophomore");
            DropColumn("dbo.GroupFilters", "IsFreshman");
            DropColumn("dbo.GroupFilters", "UserType");
            DropColumn("dbo.GroupFilters", "GroupId");
        }
    }
}
