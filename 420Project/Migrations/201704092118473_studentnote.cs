namespace _420Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class studentnote : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentNotes",
                c => new
                    {
                        StudentNoteId = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        AdvisorId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.StudentNoteId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.StudentNotes");
        }
    }
}
