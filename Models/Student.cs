using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Web;
using ofCourse.Controllers;

namespace ofCourse.Models
{
    public class Student
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter student's first name.")]
        [StringLength(255)]
        [Display(Name = "Student First Name")]
        public string FirstName { get; set; }

        [StringLength(255)]
        [Display(Name = "Student Last Name")]
        public string LastName  { get; set; }

        [Display(Name = "Enroll in Course")]
        [EnrolledStudentCheck]
        public bool isEnrolled { get; set;  }

        public EnrollmentType EnrollmentType { get; set; }

        [Display(Name = "Registration Options")]
        public byte EnrollmentTypeId { get; set; }

        public Course Courses { get; set; }

        [Display(Name = "Course Selection")]
        public int CourseId { get; set; }

        [Required]
        [Display(Name = "Date of Enrollment")]
        public DateTime? EnrolledInCourseDate { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        [Min18YearsStudent]
        public DateTime? Birthdate { get; set; }

        public CourseStatusType CourseStatusType { get; set; }

        [Required]
        [Display(Name = "Course Status")]
        public byte CourseStatusTypeId { get; set; }

        [Required]
        public string Grade { get; set; }
    }
}