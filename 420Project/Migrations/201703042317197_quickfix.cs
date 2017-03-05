namespace _420Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class quickfix : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.StudentCompliances", "ExpirationDate", c => c.DateTime());
            AlterColumn("dbo.StudentCompliances", "SubmissionDate", c => c.DateTime());
            AlterColumn("dbo.Events", "Date", c => c.DateTime());
            AlterColumn("dbo.StudentPetitions", "SubmitDate", c => c.DateTime());
            AlterColumn("dbo.ToDoes", "DueDate", c => c.DateTime());
            DropColumn("dbo.Events", "Time");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "Time", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ToDoes", "DueDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.StudentPetitions", "SubmitDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Events", "Date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.StudentCompliances", "SubmissionDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.StudentCompliances", "ExpirationDate", c => c.DateTime(nullable: false));
        }
    }
}
