using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class PromotionPanelMember
    {
        public string PeLogn { get; set; }
        public string Department { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string Status { get; set; }
        public string Updatedby { get; set; }
        public DateTime? Entrystamp { get; set; }
        public string ReviewerType { get; set; }
    }
}
