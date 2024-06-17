using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExRiskIden
    {
        public int Rid { get; set; }
        public DateTime? Riskdate { get; set; }
        public int? CuIden { get; set; }
        public string PeLognIden { get; set; }
        public int? RcatId { get; set; }
        public int? Pid { get; set; }
        public int? RiskSymptom { get; set; }
        public string Roc { get; set; }
        public DateTime? IdentifiedDate { get; set; }
        public DateTime? ClosingDate { get; set; }
        public string RiskDesc { get; set; }
        public DateTime? RiskCloseDate { get; set; }
        public string RiskCloseComments { get; set; }
        public string RiskCloseBy { get; set; }
        public DateTime? RiskCloseOn { get; set; }
        public DateTime? LastClientCall { get; set; }
        public string MngrComments { get; set; }
        public string Createdby { get; set; }
        public DateTime? Entrystamp { get; set; }
        public string Status { get; set; }
        public string Updatedby { get; set; }
        public DateTime? UpdateTimestamp { get; set; }
    }
}
