namespace _420Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddManualData : DbMigration
    {
        public override void Up()
        {
            //Add Semesters
            Sql("INSERT INTO Semesters (Year, Season) VALUES (2016, 'Spring')");
            Sql("INSERT INTO Semesters (Year, Season) VALUES (2016, 'Summer')");
            Sql("INSERT INTO Semesters (Year, Season) VALUES (2016, 'Fall')");
            Sql("INSERT INTO Semesters (Year, Season) VALUES (2017, 'Spring')");
            //Add Students
            Sql("INSERT INTO Students (FirstName, LastName) VALUES ('John', 'Doe')");
            Sql("INSERT INTO Students (FirstName, LastName) VALUES ('Sam', 'Winchester')");
            Sql("INSERT INTO Students (FirstName, LastName) VALUES ('Mary', 'Williams')");
            Sql("INSERT INTO Students (FirstName, LastName) VALUES ('Angela', 'Gavins')");
            Sql("INSERT INTO Students (FirstName, LastName) VALUES ('Larry', 'Smith')");
            Sql("INSERT INTO Students (FirstName, LastName) VALUES ('Jane', 'Doe')");
        }

        public override void Down()
        {
        }
    }
}
