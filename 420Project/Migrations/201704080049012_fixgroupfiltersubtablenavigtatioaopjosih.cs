namespace _420Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixgroupfiltersubtablenavigtatioaopjosih : DbMigration
    {
        public override void Up()
        {
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
            
            AddColumn("dbo.GroupFilters", "FilterByCompliance", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GroupFilterCompliances", "GroupFilterId", "dbo.GroupFilters");
            DropForeignKey("dbo.GroupFilterPrograms", "ProgramId", "dbo.Programs");
            DropForeignKey("dbo.GroupFilterPrograms", "GroupFilterId", "dbo.GroupFilters");
            DropForeignKey("dbo.GroupFilterCompliances", "ComplianceId", "dbo.Compliances");
            DropIndex("dbo.GroupFilterPrograms", new[] { "ProgramId" });
            DropIndex("dbo.GroupFilterPrograms", new[] { "GroupFilterId" });
            DropIndex("dbo.GroupFilterCompliances", new[] { "ComplianceId" });
            DropIndex("dbo.GroupFilterCompliances", new[] { "GroupFilterId" });
            DropColumn("dbo.GroupFilters", "FilterByCompliance");
            DropTable("dbo.GroupFilterPrograms");
            DropTable("dbo.GroupFilterCompliances");
        }
    }
}
