using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExDetailedDataLog
    {
        public string PeLogn { get; set; }
        public string CuIden { get; set; }
        public string Group { get; set; }
        public string Role { get; set; }
        public DateTime? KickOffDate { get; set; }
        public DateTime? DateOfMove { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Status { get; set; }
        public string StatusLvl { get; set; }
        public string Reason { get; set; }
        public decimal? Allocation { get; set; }
        public DateTime? BillStart { get; set; }
        public DateTime? BillEnd { get; set; }
        public string ReplaceWith { get; set; }
        public DateTime? TransactionEntryStamp { get; set; }
        public string PeLocn { get; set; }
        public string FinalStatus { get; set; }
        public string ClientType { get; set; }
        public string BillEntity { get; set; }
        public decimal? BillPercent { get; set; }
        public string ForDepartment { get; set; }
        public string ForEntity { get; set; }
        public DateTime? ForTheDate { get; set; }
        public string ForMonth { get; set; }
        public int? ForYear { get; set; }
        public DateTime? EntryStamp { get; set; }
        public string Lobgrouping { get; set; }
    }
}
