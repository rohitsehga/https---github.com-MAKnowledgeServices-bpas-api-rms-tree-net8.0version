using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExRiskSymptomMaster
    {
        public int Rsid { get; set; }
        public string Rsname { get; set; }
        public long? RcatId { get; set; }
        public string UserLognId { get; set; }
        public DateTime? EntryStamp { get; set; }
        public string Status { get; set; }
    }
}
