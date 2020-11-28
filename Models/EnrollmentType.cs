using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ofCourse.Models
{
    public class EnrollmentType
    {
        public byte Id { get; set; }

        public string EnrollmentTypeName { get; set; }

        public short RegistrationCost { get; set; }

        public byte DurationInDays { get; set; }

        public static readonly byte unknown = 0;
        public static readonly byte notEnrolled = 1;
        public static readonly byte enrolledReducedCost = 2;
        public static readonly byte enrolledNormal = 3;
        public static readonly byte enrolledPremium = 4;
    }
}