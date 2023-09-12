using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class StudentInCourse
    {
        public string Sicid { get; set; } = null!;
        public string CourseCode { get; set; } = null!;
        public bool? IsInTeam { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Course CourseCodeNavigation { get; set; } = null!;
        public virtual Student Sic { get; set; } = null!;
        public virtual Teammate? Teammate { get; set; }
    }
}
