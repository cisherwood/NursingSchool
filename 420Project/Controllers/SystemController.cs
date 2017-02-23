using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _420Project.Models;

namespace _420Project.Controllers
{
    public class SystemController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //Method that will be take a student's Id, retrieve their enrollments, and then calculate their GPA.
        //Pre-Condition: Provide a valid Id number.
        //Post-Conition: The student's GPA will be returned as a string formatted to two decimal places.
        public string GetGPA(int id)
        {
            double totalHours = 0;
            double achievedPoints = 0;

            var enrollments = from c in db.Enrollment
                              where c.Student.StudentId == id
                              select c;

            foreach (Enrollment enrollment in enrollments)
            {
                if (!string.IsNullOrWhiteSpace(enrollment.Grade)) //Done to ensure that only graded enrollment records are included.
                    totalHours += enrollment.Course.ClassHours;
            }

            foreach (Enrollment enrollment in enrollments)
            {
                if (!string.IsNullOrWhiteSpace(enrollment.Grade))
                    achievedPoints += GetGradePoints(enrollment.Course.ClassHours, enrollment.Grade);
            }
            return string.Format($"{Math.Round(achievedPoints / totalHours,2):N2}"); //Return calculated gpa as a string, rounded to two decimal places.
        }
        //Helper method that will determine the grade points achieved at a certain grade.
        //Pre-Condition: Class Hours and Grade achieved are passed.
        //Post-Condition: GradePoints earned are returned.
        private double GetGradePoints(int hours, string grade)
        {
            switch (grade)
            {
                case "A+":
                    return hours * 4;
                case "A":
                    return hours * 4;
                case "A-":
                    return hours * 3.7;
                case "B+":
                    return hours * 3.3;
                case "B":
                    return hours * 3;
                case "B-":
                    return hours * 2.7;
                case "C+":
                    return hours * 2.3;
                case "C":
                    return hours * 2.0;
                case "C-":
                    return hours * 1.7;
                case "D+":
                    return hours * 1.3;
                case "D":
                    return hours * 1;
                case "D-":
                    return hours * .7;
                case "F":
                    return hours * 0;
                default:
                    return hours * 0;
            }


        }




    }


}