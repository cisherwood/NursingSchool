namespace _420Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class studentupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Enrollments", "QPts", c => c.Double(nullable: false));
            AddColumn("dbo.Enrollments", "IsTransferCredit", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Enrollments", "IsTransferCredit");
            DropColumn("dbo.Enrollments", "QPts");
        }
    }
}
