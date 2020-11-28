using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;

namespace ofCourse.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a Course Name.")]
        [StringLength(255)]
        [Display(Name = "Course Name")]
        public string CourseName { get; set; }

        [Required(ErrorMessage = "Please enter a Course Description.")]
        [StringLength(400)]
        [Display(Name = "Course Description")]
        public string CourseDescription { get; set; }

        [Required(ErrorMessage = "Please enter a Tutor Name.")]
        [StringLength(255)]
        [Display(Name = "Tutor Name")]
        public string TutorName { get; set; }

        [Required(ErrorMessage = "Please enter a Course Rating between 1 and 10.")]
        [Range(1,10)]
        [Display(Name = "Course Rating")]
        public int CourseRating { get; set; }
    }
}