namespace _420Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class semesterdates : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Semesters", "StartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Semesters", "EndDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Semesters", "EndDate");
            DropColumn("dbo.Semesters", "StartDate");
        }
    }
}
