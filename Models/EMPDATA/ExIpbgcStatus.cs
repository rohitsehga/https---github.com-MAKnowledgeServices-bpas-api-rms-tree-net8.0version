using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.EMPDATA
{
    public partial class ExIpbgcStatus
    {
        public string BgcstatusId { get; set; }
        public string BgcstatusName { get; set; }
        public string BgcstatusDesc { get; set; }
        public string Status { get; set; }
        public string UserLognId { get; set; }
        public DateTime? EntryStamp { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
    }
}
