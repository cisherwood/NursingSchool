namespace _420Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class useridadvisor : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Advisors", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Advisors", "UserId", c => c.Int(nullable: false));
        }
    }
}
