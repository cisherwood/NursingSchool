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

            context.Advisor.AddOrUpdate(new Advisor
            {AdvisorId = 1,FirstName = "Alexander",LastName = "Smith",
                Title = "Test",TitleDescription = "TestDescription",
                Office = "Test",Email = "test@gmail.com",
                ContactNumber = "555-555-5555"
            });

            context.Campus.AddOrUpdate(new Campus { CampusName = "SON", Address = "1234 Test",
                City = "Lousiville", State = "KY", ZipCode = "40228",
                PhoneNumber = "Test" });

            context.Compliance.AddOrUpdate(new Compliance { Id=1,Name = "HIPPA" });

            context.Department.AddOrUpdate(new Department { DepartmentId=1, Name = "NURS" });

            context.Course.AddOrUpdate(new Course { CourseId=1,Number = "400", DepartmentId = 1, Title = "Advanced Nursing", Description = "Test Description", ClassHours = 3, PassGrade = "A", CampusId = "1" });

            context.Student.AddOrUpdate(new Student { StudentId=1,FirstName = "John", LastName = "Smith", MiddleName = "Alex", Email = "test@gmail.com", PhoneNumber = "555-555-5555", Address = "1234 Apple Lane", AdvisorId = 1, ProgramId = 1, HasGraduated = false, Standing = "Enrolled", Year = "Junior", DOB= DateTime.Parse("2015-09-01") });

            context.Semester.AddOrUpdate(new Semester { SemesterId = 1, Year = 2016, Season = "Fall" });
            context.Semester.AddOrUpdate(new Semester { SemesterId = 2, Year = 2016, Season = "Fall" });
            context.Semester.AddOrUpdate(new Semester { SemesterId = 3, Year = 2016, Season = "Fall" });

            context.Enrollment.AddOrUpdate(new Enrollment { StudentId = 1, CourseId = 1, SemesterId = 1, Grade = "A" });

            context.Event.AddOrUpdate(new Event { EventId=1,Name = "Test", Description = "Event description", Location = "Location", IsRecruitmentEvent = false, Date=DateTime.Parse("2005-09-01") });

            context.Petition.AddOrUpdate(new Petition { PetitionID=1,Name = "Complaint" });

            context.Program.AddOrUpdate(new Program { ProgramId=1,Name = "BSN" });

            context.ProgramCourse.AddOrUpdate(new ProgramCourse { ProgramCourseId=1,ProgramId = 1, CourseId = 1, SemesterId = 1 });

            context.StudentCompliance.AddOrUpdate(new StudentCompliance { SCId= 1,ExpirationDate = DateTime.Parse("2015-09-01"), SubmissionDate = DateTime.Parse("2005-09-01"), ComplianceId = 1, StudentId = 1 });

            context.StudentPetition.AddOrUpdate(new StudentPetition { StudentPetitionID=1,Status = "Pending", SubmitDate = DateTime.Parse("2015-09-01"), StudentID = 1, PetitionID = 1 });

            context.StudentProgram.AddOrUpdate(new StudentProgram { StudentProgramId=1,StudentId = 1, ProgramId = 1, Status = "Enrolled" });

            context.To_Dos.AddOrUpdate(new ToDo {ToDoID=1,Description="Test",CreateDate= DateTime.Parse("2005-09-01"), DueDate= DateTime.Parse("2005-09-01")});

            base.Seed(context);






        }
    }
}
