using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Task
    {
        public Task()
        {
            TaskParticipants = new HashSet<TaskParticipant>();
        }

        public int TaskId { get; set; }
        public int TeamId { get; set; }
        public string? TaskName { get; set; }
        public string? TaskDescription { get; set; }
        public DateTime? TaskStartDate { get; set; }
        public DateTime? TaskEndDate { get; set; }
        public string? ProductLink { get; set; }
        public int? Status { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Team Team { get; set; } = null!;
        public virtual ICollection<TaskParticipant> TaskParticipants { get; set; }
    }
}
