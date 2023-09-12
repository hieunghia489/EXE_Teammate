using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Teammate
    {
        public Teammate()
        {
            Feedbacks = new HashSet<Feedback>();
            TaskParticipants = new HashSet<TaskParticipant>();
        }

        public string TeammateId { get; set; } = null!;
        public string TeamName { get; set; } = null!;
        public int? TeammateRole { get; set; }
        public DateTime? TeammateJoinDate { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Team TeamNameNavigation { get; set; } = null!;
        public virtual StudentInCourse TeammateNavigation { get; set; } = null!;
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<TaskParticipant> TaskParticipants { get; set; }
    }
}
