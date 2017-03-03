namespace _420Project.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<_420Project.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(_420Project.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var advisors = new List<Advisor>
            {
                new Advisor{FirstName="Alexander",LastName="Smith",Title="Test",
                    TitleDescription ="TestDescription",Office="Test",Email="test@gmail.com",ContactNumber="555-555-5555"},
                new Advisor{FirstName="Alexander",LastName="Smith",Title="Test",
                    TitleDescription ="TestDescription",Office="Test",Email="test@gmail.com",ContactNumber="555-555-5555"},
                new Advisor{FirstName="Alexander",LastName="Smith",Title="Test",
                    TitleDescription ="TestDescription",Office="Test",Email="test@gmail.com",ContactNumber="555-555-5555"},
                new Advisor{FirstName="Alexander",LastName="Smith",Title="Test",
                    TitleDescription ="TestDescription",Office="Test",Email="test@gmail.com",ContactNumber="555-555-5555"},
                new Advisor{FirstName="Alexander",LastName="Smith",Title="Test",
                    TitleDescription ="TestDescription",Office="Test",Email="test@gmail.com",ContactNumber="555-555-5555"}
            };

            var campus = new List<Campus>
            {
                new Campus {CampusName="SON",Address="1234 Test",City="Lousiville",State="KY",ZipCode="40228",PhoneNumber="Test" },
                new Campus {CampusName="SON",Address="1234 Test",City="Lousiville",State="KY",ZipCode="40228",PhoneNumber="Test" },
                new Campus {CampusName="SON",Address="1234 Test",City="Lousiville",State="KY",ZipCode="40228",PhoneNumber="Test" }
            };

            var compliance = new List<Compliance>
            {
                new Compliance {Name="Flu Shot"},
                new Compliance {Name="HIPPA"}
            };

            var course = new List<Course>
            {
                new Course {Number="400",DepartmentId=1,Title="Advanced Nursing",Description="Test Description",ClassHours=3,PassGrade="A",CampusId="1" },
                new Course {Number="400",DepartmentId=1,Title="Advanced Nursing",Description="Test Description",ClassHours=3,PassGrade="A",CampusId="1" }
            };

            var department = new List<Department>
            {
                new Department {Name="NURS"},
                new Department {Name="ENG" }
            };

            var enrollment = new List<Enrollment>
            {
                new Enrollment {StudentId=1,CourseId=1,SemesterId=1,Grade="A" }
            };

            var events = new List<Event>
            {
                new Event {Name="Test",Description="Event description",Location="Location",IsRecruitmentEvent=false },
            };


            var petition = new List<Petition>
            {
                new Petition {Name="Complaint"},
            };

            var program = new List<Program>
            {
                new Program {Name="BSN"},
            };

            var programcourse = new List<ProgramCourse>
            {
                new ProgramCourse { ProgramId=1,CourseId=1,SemesterId=1},
            };

            var semester = new List<Semester>
            {
                new Semester { Year=2016,Season="Fall" },
                new Semester { Year=2016,Season="Spring" },
                new Semester { Year=2016,Season="Summer" },
            };

            var student = new List<Student>
            {
                new Student { FirstName="John",LastName="Smith",MiddleName="Alex",Email="test@gmail.com",PhoneNumber="555-555-5555",Address="1234 Apple Lane",AdvisorId=1,ProgramId=1,HasGraduated=false,Standing="Enrolled",Year="Junior"},
                new Student { FirstName="John",LastName="Smith",MiddleName="Alex",Email="test@gmail.com",PhoneNumber="555-555-5555",Address="1234 Apple Lane",AdvisorId=1,ProgramId=1,HasGraduated=false,Standing="Enrolled",Year="Junior"},
                new Student { FirstName="John",LastName="Smith",MiddleName="Alex",Email="test@gmail.com",PhoneNumber="555-555-5555",Address="1234 Apple Lane",AdvisorId=1,ProgramId=1,HasGraduated=false,Standing="Enrolled",Year="Junior"},
                new Student { FirstName="John",LastName="Smith",MiddleName="Alex",Email="test@gmail.com",PhoneNumber="555-555-5555",Address="1234 Apple Lane",AdvisorId=1,ProgramId=1,HasGraduated=false,Standing="Enrolled",Year="Junior"},
                new Student { FirstName="John",LastName="Smith",MiddleName="Alex",Email="test@gmail.com",PhoneNumber="555-555-5555",Address="1234 Apple Lane",AdvisorId=1,ProgramId=1,HasGraduated=false,Standing="Enrolled",Year="Junior"}
            };

            var studentcompliance = new List<StudentCompliance>
            {
                new StudentCompliance { ExpirationDate=DateTime.Parse("2015-09-01"),SubmissionDate=DateTime.Parse("2005-09-01"),ComplianceId=1,StudentId=1 }
            };

            var studentpetition = new List<StudentPetition>
            {
                new StudentPetition { Status="Pending",SubmitDate=DateTime.Parse("2015-09-01"),StudentID=1,PetitionID=1}
            };

            var studentprogram = new List<StudentProgram>
            {
                new StudentProgram {StudentId=1,ProgramId=1,Status="Enrolled"}
            };

            var todos = new List<To_Do>
            {
                new To_Do {Description="Test"}
            };





        }
    }
}
