namespace _420Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MichaelsModels : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Compliances", "Name", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Compliances", "Name", c => c.String(maxLength: 100));
        }
    }
}
