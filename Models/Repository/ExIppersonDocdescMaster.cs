using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExIppersonDocdescMaster
    {
        public int DocDescId { get; set; }
        public int Location { get; set; }
        public string DocDescription { get; set; }
        public string Status { get; set; }
        public DateTime? EntryStamp { get; set; }
        public string UserLognId { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
        public string IsApprovalRequired { get; set; }
    }
}
