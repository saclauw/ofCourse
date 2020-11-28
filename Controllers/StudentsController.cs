using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using ofCourse.Migrations;
using ofCourse.Models;
using ofCourse.ViewModels;

namespace ofCourse.Controllers
{
    [Authorize]
    public class StudentsController : Controller
    {
        private ApplicationDbContext _context;

        public StudentsController()
        {
            _context = new ApplicationDbContext();            
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Students
        [Route("Students")]
        public ActionResult StudentList()
        {
            var students = _context.Students.Include(s => s.EnrollmentType).ToList();

            if (User.IsInRole(RoleName.CanManageStudents))
                return View("StudentList", students);

            return View("ReadOnlyStudentList", students);
        }

        [Route("Students/Detail/{Id}")]
        public ActionResult Detail(int id = 0)
        {
            var students = _context.Students.SingleOrDefault(s => s.Id == id);

            if (students == null)
            {
                return HttpNotFound();
            }

            return View(students);
        }


        public ActionResult New()
        {
            var courseIds = _context.Courses.ToList();
            var enrollmentTypeIds = _context.EnrollmentTypes.ToList();
            var courseStatusTypeIds = _context.CourseStatusTypes.ToList();

            var viewModel = new StudentFormViewModel()
            {
                Courses = courseIds,
                EnrollmentTypes = enrollmentTypeIds,
                CourseStatusTypes = courseStatusTypeIds
            };
            return View("New", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Student student)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new StudentFormViewModel
                {
                    Student = student,
                    Courses = _context.Courses.ToList(),
                    EnrollmentTypes = _context.EnrollmentTypes.ToList(),
                    CourseStatusTypes = _context.CourseStatusTypes.ToList()
                };
                return View("StudentForm", viewModel);
            }

            if (student.Id == 0)
                _context.Students.Add(student);
            else
            {
                var studentInDb = _context.Students.Single(s => s.Id == student.Id);

                studentInDb.FirstName = student.FirstName;
                studentInDb.LastName = student.LastName;
                studentInDb.Birthdate = student.Birthdate;
                studentInDb.CourseId = student.CourseId;
                studentInDb.EnrollmentTypeId = student.EnrollmentTypeId;
                studentInDb.isEnrolled = student.isEnrolled;
                studentInDb.EnrolledInCourseDate = student.EnrolledInCourseDate;
                studentInDb.CourseStatusTypeId = student.CourseStatusTypeId;
                studentInDb.Grade = student.Grade;

            }

            _context.SaveChanges();

            return View("StudentList", _context.Students.Include(s => s.EnrollmentType).ToList());
        }

        public ActionResult Edit(int id)
        {
            var student = _context.Students.SingleOrDefault(s => s.Id == id);

            if (student == null)
                return HttpNotFound();

            var viewModel = new StudentFormViewModel()
            {
                Student = student,
                Courses = _context.Courses.ToList(),
                EnrollmentTypes = _context.EnrollmentTypes.ToList(),
                CourseStatusTypes = _context.CourseStatusTypes.ToList()
            };

            return View("StudentForm", viewModel);
        }

        [Authorize(Roles = RoleName.CanManageStudents)]
        [HttpPost]
        public ActionResult Delete(Student student)
        {
            var studentInDb = _context.Students.Single(s => s.Id == student.Id);
            if (studentInDb == null) 
                    return HttpNotFound(); 
            
            _context.Students.Remove(studentInDb); 
            _context.SaveChanges(); 
            return View("StudentList", _context.Students.Include(s => s.EnrollmentType).ToList());
            
        }

 
    }
}