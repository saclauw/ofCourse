using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ofCourse.Models
{
    public class EnrolledStudentCheck : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var student = (Student)validationContext.ObjectInstance;

            if(student.EnrollmentTypeId == EnrollmentType.notEnrolled && student.isEnrolled == false ||
               student.EnrollmentTypeId == EnrollmentType.unknown && student.isEnrolled == false)
                return ValidationResult.Success;

            if (student.EnrollmentTypeId == EnrollmentType.enrolledReducedCost && student.isEnrolled == false ||
                student.EnrollmentTypeId == EnrollmentType.enrolledNormal && student.isEnrolled == false ||
                student.EnrollmentTypeId == EnrollmentType.enrolledPremium && student.isEnrolled == false)
                return new ValidationResult("Student must be enrolled if they're registered as Reduced Cost, Semester, or Premium");
            return ValidationResult.Success;
        }

        

    }
}