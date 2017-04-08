namespace _420Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixstudenttryoblivion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "NeedCompliance", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "NeedCompliance");
        }
    }
}
