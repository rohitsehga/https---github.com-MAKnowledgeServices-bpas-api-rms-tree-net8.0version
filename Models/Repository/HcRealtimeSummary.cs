using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class HcRealtimeSummary
    {
        public DateTime? Period { get; set; }
        public string PeLogn { get; set; }
        public int? CuIden { get; set; }
        public int? ProjId { get; set; }
        public string Group { get; set; }
        public string Role { get; set; }
        public DateTime? KickOff { get; set; }
        public DateTime? DateOfMove { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? BillStart { get; set; }
        public DateTime? BillEnd { get; set; }
        public decimal? Allocn { get; set; }
        public string Status { get; set; }
        public int? StatusLvl { get; set; }
        public string Reason { get; set; }
        public string OffBoardReason { get; set; }
        public int? PeLocn { get; set; }
        public string FinalStatus { get; set; }
        public decimal? BillPercent { get; set; }
        public int? Sl { get; set; }
        public string UtilBench { get; set; }
        public string Sow { get; set; }
        public string UsageClause { get; set; }
        public string BlackOut { get; set; }
        public string Geo { get; set; }
        public string ClientType { get; set; }
        public string Lob { get; set; }
        public string Sbt { get; set; }
        public string MainBillingStatus { get; set; }
        public string BillingStatus { get; set; }
        public string OverallBillingStatus { get; set; }
        public DateTime? Entrystamp { get; set; }
    }
}
