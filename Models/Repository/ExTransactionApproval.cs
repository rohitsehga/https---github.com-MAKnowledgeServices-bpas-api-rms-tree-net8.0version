using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExTransactionApproval
    {
        public int Id { get; set; }
        public string ServiceLine { get; set; }
        public string Status { get; set; }
        public DateTime? LockedOn { get; set; }
        public string LockedBy { get; set; }
        public DateTime? EntryStamp { get; set; }
        public DateTime? UnLockOn { get; set; }
        public string UnLockBy { get; set; }
    }
}
