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

        public int SubjectId { get; set; }
        public string? SubjectCode { get; set; }
        public string? SubjectDescription { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
