using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Grade
    {
        public Grade()
        {
            Students = new HashSet<Student>();
        }

        public int GradeId { get; set; }
        public string GradeCode { get; set; } = null!;
        public string? GradeDescription { get; set; }
        public DateTime? GradeStartDate { get; set; }
        public DateTime? GradeEndDate { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
