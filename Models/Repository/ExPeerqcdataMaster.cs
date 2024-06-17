using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExPeerqcdataMaster
    {
        public DateTime PostingDate { get; set; }
        public int? CuIden { get; set; }
        public string CuCode { get; set; }
        public string AnalystLogn { get; set; }
        public DateTime? Qcdate { get; set; }
        public string Category { get; set; }
        public string Assignment { get; set; }
        public long? AsgSl { get; set; }
        public string TaskType { get; set; }
        public string PeerOrVp { get; set; }
        public int? Grade1Rating { get; set; }
        public int? Grade2Rating { get; set; }
        public int? Grade3Rating { get; set; }
        public int? Grade4Rating { get; set; }
        public int? Grade5Rating { get; set; }
        public int? Grade6Rating { get; set; }
        public int? Grade7Rating { get; set; }
        public string Issues1 { get; set; }
        public string Issues2 { get; set; }
        public string Issues3 { get; set; }
        public string Issues4 { get; set; }
        public string Issues5 { get; set; }
        public string Issues6 { get; set; }
        public string Issues7 { get; set; }
        public string Suggestions1 { get; set; }
        public string Suggestions2 { get; set; }
        public string Suggestions3 { get; set; }
        public string Suggestions4 { get; set; }
        public string Suggestions5 { get; set; }
        public string Suggestions6 { get; set; }
        public string Suggestions7 { get; set; }
        public string UserLognId { get; set; }
        public DateTime? EntryStamp { get; set; }
        public string Status { get; set; }
        public string Qcnumber { get; set; }
        public string ClosedBy { get; set; }
        public DateTime? ClosedOn { get; set; }
        public string ReopenedBy { get; set; }
        public DateTime? ReopenedOn { get; set; }
        public decimal? Score { get; set; }
        public int? Grade8Rating { get; set; }
        public int? Grade9Rating { get; set; }
        public int? Grade10Rating { get; set; }
        public string Issues8 { get; set; }
        public string Issues9 { get; set; }
        public string Issues10 { get; set; }
        public string Suggestions8 { get; set; }
        public string Suggestions9 { get; set; }
        public string Suggestions10 { get; set; }
    }
}
