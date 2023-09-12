using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Subject
    {
        public Subject()
        {
            Courses = new HashSet<Course>();
        }

        public string SubjectCode { get; set; } = null!;
        public string? SubjectDescription { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
