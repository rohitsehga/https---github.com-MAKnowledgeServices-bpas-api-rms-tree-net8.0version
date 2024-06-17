using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExSummaryDataLog
    {
        public string FilterType { get; set; }
        public string Filter { get; set; }
        public int? TotalHc { get; set; }
        public decimal? Allocation { get; set; }
        public decimal? Billing { get; set; }
        public decimal? PureBenchHc { get; set; }
        public decimal? PartialBenchHc { get; set; }
        public DateTime? ForTheDate { get; set; }
        public string ForMonth { get; set; }
        public int? ForYear { get; set; }
        public DateTime? EntryStamp { get; set; }
    }
}
