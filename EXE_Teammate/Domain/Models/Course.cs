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

        public int CourseId { get; set; }
        public string CourseCode { get; set; } = null!;
        public int SubjectId { get; set; }
        public int SemesterId { get; set; }
        public DateTime? CourseStartDate { get; set; }
        public DateTime? CourseEndDate { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Semester Semester { get; set; } = null!;
        public virtual Subject Subject { get; set; } = null!;
        public virtual ICollection<StudentInCourse> StudentInCourses { get; set; }
    }
}
