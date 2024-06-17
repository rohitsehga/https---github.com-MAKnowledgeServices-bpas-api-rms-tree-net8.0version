using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExIpprojectTeamAllocation
    {
        public int ProjId { get; set; }
        public int? AllocSlno { get; set; }
        public string PeLogn { get; set; }
        public decimal AllocPercentage { get; set; }
        public DateTime? ProjStartdate { get; set; }
        public DateTime? ProjEnddate { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedTimestamp { get; set; }
        public string Updatedby { get; set; }
        public DateTime? Updatedtimestamp { get; set; }
    }
}
