using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ofCourse.Models
{
    public class Min18YearsStudent : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var student = (Student)validationContext.ObjectInstance;

            /*if(!student.isEnrolled)
                return ValidationResult.Success;*/

            if(student.Birthdate == null)
                return new ValidationResult("Birthday is required.");

            var age = DateTime.Today.Year - student.Birthdate.Value.Year;
            return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult("Student should be at least 18 years old to enroll.");
        }
    }
}