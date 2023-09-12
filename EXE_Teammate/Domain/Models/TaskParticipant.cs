using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class TaskParticipant
    {
        public int Tpid { get; set; }
        public string TeammateId { get; set; } = null!;
        public int TaskId { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Task Task { get; set; } = null!;
        public virtual Teammate Teammate { get; set; } = null!;
    }
}
