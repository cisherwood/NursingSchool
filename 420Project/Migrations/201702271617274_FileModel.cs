namespace _420Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class FileModel : DbMigration
    {
        public override void Up()
        {
            RenameColumn("dbo.Courses", "CourseId", "Id");
            DropForeignKey("dbo.Enrollments", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.ProgramCourses", "CourseId", "dbo.Courses");
            CreateTable(
                "dbo.Files",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    FileName = c.String(maxLength: 255),
                    ContentType = c.String(maxLength: 100),
                    FileType = c.Int(nullable: false),
                    Content = c.Binary(),
                })
                .PrimaryKey(t => t.Id);

            AddColumn("dbo.Compliances", "File_Id", c => c.Int());
            AlterColumn("dbo.Compliances", "Name", c => c.String(maxLength: 100));
            CreateIndex("dbo.Compliances", "File_Id");
            AddForeignKey("dbo.Compliances", "File_Id", "dbo.Files", "Id");
            AddForeignKey("dbo.Enrollments", "CourseId", "dbo.Courses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProgramCourses", "CourseId", "dbo.Courses", "Id", cascadeDelete: true);

        }

        public override void Down()
        {
            AddColumn("dbo.Courses", "CourseId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.ProgramCourses", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Enrollments", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Compliances", "File_Id", "dbo.Files");
            DropIndex("dbo.Compliances", new[] { "File_Id" });
            DropPrimaryKey("dbo.Courses");
            AlterColumn("dbo.Compliances", "Name", c => c.String());
            DropColumn("dbo.Courses", "Id");
            DropColumn("dbo.Compliances", "File_Id");
            DropTable("dbo.Files");
            AddPrimaryKey("dbo.Courses", "CourseId");
            AddForeignKey("dbo.ProgramCourses", "CourseId", "dbo.Courses", "CourseId", cascadeDelete: true);
            AddForeignKey("dbo.Enrollments", "CourseId", "dbo.Courses", "CourseId", cascadeDelete: true);
        }
    }
}
