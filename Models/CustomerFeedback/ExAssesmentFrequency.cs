using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.CustomerFeedback
{
    public partial class ExAssesmentFrequency
    {
        public int? FormFrequencyId { get; set; }
        public int? AssesmentId { get; set; }
        public int? FrequencyId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Status { get; set; }
    }
}
