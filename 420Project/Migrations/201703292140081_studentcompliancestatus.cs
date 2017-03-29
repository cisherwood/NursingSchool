namespace _420Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class studentcompliancestatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StudentCompliances", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.StudentCompliances", "Status");
        }
    }
}
