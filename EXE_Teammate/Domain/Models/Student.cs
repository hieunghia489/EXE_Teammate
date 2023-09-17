using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Student
    {
        public string StudentId { get; set; } = null!;
        public int MajorId { get; set; }
        public int GradeId { get; set; }
        public string? StudentFullName { get; set; }
        public int StudentPhone { get; set; }
        public string StudentEmail { get; set; } = null!;
        public bool? StudentGender { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Grade Grade { get; set; } = null!;
        public virtual Major Major { get; set; } = null!;
        public virtual StudentInCourse? StudentInCourse { get; set; }
    }
}
