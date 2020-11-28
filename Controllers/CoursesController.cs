using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Protocols;
using ofCourse.Models;
using ofCourse.ViewModels;

namespace ofCourse.Controllers
{
    [Authorize]
    public class CoursesController : Controller
    {
        private ApplicationDbContext _context;

        public CoursesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Courses
        [Route("Courses")]
        public ActionResult CourseList()
        {
            var courses = _context.Courses;

            if (User.IsInRole(RoleName.CanManageStudents))
                return View("CourseList", courses);

            return View("ReadOnlyCourseList", courses);
        }

        [Route("Course/Detail/{Id}")]
        public ActionResult Detail(int id = 0)
        {
            var courses = _context.Courses.SingleOrDefault(c => c.Id == id);
            if (courses == null)
            {
                return HttpNotFound();
            }

            return View(courses);
        }

        public ActionResult New()
        {
            return View("New");
        }

        [HttpPost]
        public ActionResult Save(Course course)
        {
            if (!ModelState.IsValid)
            {
                return View("CourseForm", course);
            }

            if (course.Id == 0)
                _context.Courses.Add(course);
            else
            {
                var courseInDb = _context.Courses.Single(c => c.Id == course.Id);

                courseInDb.CourseName = course.CourseName;
                courseInDb.CourseDescription = course.CourseDescription;
                courseInDb.TutorName = course.TutorName;
                courseInDb.CourseRating = course.CourseRating;

            }

            _context.SaveChanges();

            return View("CourseList", _context.Courses);
        }

        public ActionResult Edit(int id)
        {
            var course = _context.Courses.SingleOrDefault(c => c.Id == id);

            if (course == null)
                return HttpNotFound();

            return View("CourseForm", course);
            }

        public ActionResult Delete(Course course)
        {
            var courseInDb = _context.Courses.Single(c => c.Id == course.Id);
            if (courseInDb == null)
                return HttpNotFound();

            _context.Courses.Remove(courseInDb);
            _context.SaveChanges();
            return View("CourseList", _context.Courses);


        }
    }
}