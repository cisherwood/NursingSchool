namespace _420Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FIXES : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "DOB", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "DOB", c => c.DateTime(nullable: false));
        }
    }
}
