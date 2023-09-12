using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Course
    {
        public Course()
        {
            StudentInCourses = new HashSet<StudentInCourse>();
        }

        public string CourseCode { get; set; } = null!;
        public string SubjectCode { get; set; } = null!;
        public string SemesterCode { get; set; } = null!;
        public DateTime? CourseStartDate { get; set; }
        public DateTime? CourseEndDate { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Semester SemesterCodeNavigation { get; set; } = null!;
        public virtual Subject SubjectCodeNavigation { get; set; } = null!;
        public virtual ICollection<StudentInCourse> StudentInCourses { get; set; }
    }
}
