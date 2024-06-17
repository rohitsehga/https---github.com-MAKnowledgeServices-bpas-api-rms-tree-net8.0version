using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.CustomerFeedback
{
    public partial class ExFrequencyMaster
    {
        public int? FrequencyId { get; set; }
        public string FrequencyName { get; set; }
        public string FrequencyDesc { get; set; }
        public string Status { get; set; }
        public DateTime? EntryStamp { get; set; }
        public string UserLognId { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
    }
}
