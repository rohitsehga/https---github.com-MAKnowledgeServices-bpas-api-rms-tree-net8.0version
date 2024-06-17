using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ProjRequestDetail
    {
        public int Id { get; set; }
        public string ScopePrjCode { get; set; }
        public string Description { get; set; }
        public string Rt { get; set; }
        public string BilledYn { get; set; }
        public string CuComp { get; set; }
        public string AboutClient { get; set; }
        public string RiskRating { get; set; }
        public string ProjType { get; set; }
        public DateTime? ProjStartDate { get; set; }
        public DateTime? ProjEndDate { get; set; }
        public int? ProjValue { get; set; }
        public string EffortEstimate { get; set; }
        public string Comment { get; set; }
        public DateTime? EntryStamp { get; set; }
        public string UserLogn { get; set; }
        public string Status { get; set; }
        public string Converted { get; set; }
        public string Client { get; set; }
        public string Group { get; set; }
        public string ProjectName { get; set; }
    }
}
