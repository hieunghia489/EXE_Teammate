using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Feedback
    {
        public int FeedbackId { get; set; }
        public string TeammateId { get; set; } = null!;
        public string TeammateFeedbackId { get; set; } = null!;
        public int? Score1 { get; set; }
        public int? Score2 { get; set; }
        public int? Score3 { get; set; }
        public string? Comment { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Teammate Teammate { get; set; } = null!;
    }
}
