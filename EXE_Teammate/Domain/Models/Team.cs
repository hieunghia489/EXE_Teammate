using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Team
    {
        public Team()
        {
            Tasks = new HashSet<Task>();
            Teammates = new HashSet<Teammate>();
        }

        public int TeamId { get; set; }
        public string TeamName { get; set; } = null!;
        public int LeaderId { get; set; }
        public DateTime? CreateDate { get; set; }
        public int NumberOfMembers { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
        public virtual ICollection<Teammate> Teammates { get; set; }
    }
}
