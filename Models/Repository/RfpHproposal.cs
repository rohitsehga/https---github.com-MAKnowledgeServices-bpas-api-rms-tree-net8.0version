using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class RfpHproposal
    {
        public decimal Id { get; set; }
        public string ProjName { get; set; }
        public int ClientId { get; set; }
        public int ExpiryCount { get; set; }
        public string Comments { get; set; }
        public short? ProjStatus { get; set; }
        public bool IsEngagement { get; set; }
        public string Config { get; set; }
        public int? IsClientEnv { get; set; }
        public string InvestmentDetails { get; set; }
        public string EngagementDetails { get; set; }
        public string DraftData { get; set; }
        public string CreBy { get; set; }
        public DateTime CreDate { get; set; }
        public string UpdBy { get; set; }
        public DateTime? UpdDate { get; set; }
        public bool? IsActive { get; set; }
        public short? ProDomain { get; set; }
    }
}
