using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExEventMaster
    {
        public int? EventId { get; set; }
        public string EventName { get; set; }
        public string EventDesc { get; set; }
        public int? StartEscalationCondition { get; set; }
        public bool? IsAutoApprove { get; set; }
        public string Status { get; set; }
        public string UserLognId { get; set; }
        public DateTime? EntryStamp { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
