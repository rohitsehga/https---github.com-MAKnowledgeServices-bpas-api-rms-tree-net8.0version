using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExRiskcatMaster
    {
        public int RcatId { get; set; }
        public string RiskName { get; set; }
        public string Status { get; set; }
        public string UserLognId { get; set; }
        public DateTime? EntryStamp { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
