using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.EMPDATA
{
    public partial class ExSeIndustrymaster
    {
        public int SectorId { get; set; }
        public int IndId { get; set; }
        public string IndName { get; set; }
        public DateTime EntryStamp { get; set; }
        public string UserId { get; set; }
        public string Status { get; set; }
    }
}
