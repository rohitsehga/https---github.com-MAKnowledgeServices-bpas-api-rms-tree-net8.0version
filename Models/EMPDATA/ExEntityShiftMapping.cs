using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.EMPDATA
{
    public partial class ExEntityShiftMapping
    {
        public int? CntrlEntityId { get; set; }
        public int? ShiftId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Status { get; set; }
        public string UserLognId { get; set; }
        public DateTime? EntryStamp { get; set; }
        public string EndUserLognId { get; set; }
        public DateTime? EndEntryStamp { get; set; }
    }
}
