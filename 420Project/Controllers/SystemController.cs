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

        //public double GetGPA(int id)
        //{
        //    double totalHours, achievedPoints = 0;

        //    var enrollments = from c in db.Enrollment
        //                      where c.Student.StudentId == id
        //                      select c;

        //    foreach (Enrollment enrollment in enrollments)
        //        totalHours += enrollment.Course.ClassHours;

        //    foreach (Enrollment enrollment in enrollments)
        //        achievedPoints += GetGradePoints(enrollment.Course.ClassHours, enrollment.Grade);

        //}

        //private double GetGradePoints(int hours, string grade)
        //{
        //    switch (grade)
        //    {
        //        case "A+":
        //            return hours * 4;
        //        case "A":
        //            return hours * 4;
        //        case "A-":
        //            return hours * 3.7;
        //        case "B+":
        //            return hours * 3.3;
        //        case "B":
        //            return hours * 3;
        //        case "B-":
        //            return hours * 2.7;
        //        case "C+":
        //            return hours * 2.3;
        //        case "C":
        //            return hours * 2.0;
        //        case "C-":
        //            return hours * 1.7;
        //        case "D+":
        //            return hours * 1.3;
        //        case "D":
        //            return hours * 1;
        //        case "D-":
        //            return hours * .7;
        //        case "F":
        //            return hours * 0;
        //        case default:
        //            return hours * 0;

        //    }


        //}




    }


}