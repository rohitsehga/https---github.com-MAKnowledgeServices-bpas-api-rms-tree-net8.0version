using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.EMPDATA
{
    public partial class ExPoolMapping
    {
        public int? CuIden { get; set; }
        public string PeLogn { get; set; }
        public int? PoolId { get; set; }
        public int? ClientAnal { get; set; }
        public string LeadLogn { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? Allocation { get; set; }
        public DateTime? EntryStamp { get; set; }
        public string UserId { get; set; }
        public string Status { get; set; }
    }
}
