using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class HcTrigger
    {
        public int? Id { get; set; }
        public string Type { get; set; }
        public string Trigger { get; set; }
        public int? CuIden { get; set; }
        public string Group { get; set; }
        public string PeLogn { get; set; }
        public DateTime? RecordDate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? CsatDate { get; set; }
        public string CdhLogn { get; set; }
        public string CdhComments { get; set; }
        public string DmLogn { get; set; }
        public string DmStatus { get; set; }
        public string AuditDmStatus { get; set; }
        public string Status { get; set; }
        public string ClosureStatus { get; set; }
        public DateTime? EntryStamp { get; set; }
        public string UserId { get; set; }
        public DateTime? ClosureEntryStamp { get; set; }
        public string ClosureLogn { get; set; }
    }
}
