using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.EMPDATA
{
    public partial class ExEditorialAllocation
    {
        public string PeLogn { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? Allocation { get; set; }
        public decimal? Cnt { get; set; }
        public DateTime? EntryStamp { get; set; }
        public string UserId { get; set; }
    }
}
