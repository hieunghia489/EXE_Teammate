using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Major
    {
        public Major()
        {
            Students = new HashSet<Student>();
        }

        public int MajorId { get; set; }
        public string MajorCode { get; set; } = null!;
        public string MajorName { get; set; } = null!;
        public string? MajorDescription { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
