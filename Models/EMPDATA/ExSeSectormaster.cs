using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.EMPDATA
{
    public partial class ExSeSectormaster
    {
        public int SectorId { get; set; }
        public string SeName { get; set; }
        public DateTime EntryStamp { get; set; }
        public string UserId { get; set; }
        public string Status { get; set; }
    }
}
