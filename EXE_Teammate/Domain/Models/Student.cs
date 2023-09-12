using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Student
    {
        public string StudentId { get; set; } = null!;
        public string MajorCode { get; set; } = null!;
        public string GradeCode { get; set; } = null!;
        public string? StudentFullName { get; set; }
        public int StudentPhone { get; set; }
        public string StudentEmail { get; set; } = null!;
        public bool? StudentGender { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Grade GradeCodeNavigation { get; set; } = null!;
        public virtual Major MajorCodeNavigation { get; set; } = null!;
        public virtual StudentInCourse? StudentInCourse { get; set; }
    }
}
