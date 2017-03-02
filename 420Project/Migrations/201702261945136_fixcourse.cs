namespace _420Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixcourse : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Compliances", "Name", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Compliances", "Name", c => c.String());
        }
    }
}
