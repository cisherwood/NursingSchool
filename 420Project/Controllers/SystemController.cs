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

        private string[] gradeList = new string[] { "F", "D-", "D", "D+", "C-", "C", "C+", "B-", "B", "B+", "A-", "A", "A+" };
        private double[] gradePointList = new double[] { 0, .7, 1, 1.3, 1.7, 2, 2.3, 2.7, 3, 3.3, 3.7, 4, 4 };

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
            return string.Format($"{Math.Round(achievedPoints / totalHours, 2):N2}"); //Return calculated gpa as a string, rounded to two decimal places.
        }
        //Helper method that will determine the grade points achieved at a certain grade.
        //Pre-Condition: Class Hours and Grade achieved are passed.
        //Post-Condition: GradePoints earned are returned.
        private double GetGradePoints(int hours, string grade)
        {
            int count = gradeList.Length - 1;
            for (int i = 0; i < count; i++)
            {
                if (grade == gradeList[i])
                    return gradePointList[i] * hours;
            }
            return 0; //----> Make to throw exception or error if there is an issue. <----
        }
    }
}


