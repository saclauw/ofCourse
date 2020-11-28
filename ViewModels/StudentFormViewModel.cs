using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ofCourse.Models;

namespace ofCourse.ViewModels
{
    public class StudentFormViewModel
    {
        public IEnumerable<Course> Courses { get; set; }

        public IEnumerable<EnrollmentType> EnrollmentTypes { get; set; }

        public IEnumerable<CourseStatusType> CourseStatusTypes { get; set; }
        public Student Student { get; set; }
    }
}