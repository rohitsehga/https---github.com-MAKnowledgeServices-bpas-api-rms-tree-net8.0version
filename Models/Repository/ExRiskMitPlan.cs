using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExRiskMitPlan
    {
        public int Rid { get; set; }
        public int? Mid { get; set; }
        public int? Sl { get; set; }
        public string MitPlan { get; set; }
        public string AssignPeLogn { get; set; }
        public DateTime? MitigationClosingDate { get; set; }
        public string Createdby { get; set; }
        public DateTime? Entrystamp { get; set; }
        public string Status { get; set; }
        public string Updatedby { get; set; }
        public DateTime? UpdateTimestamp { get; set; }
    }
}
