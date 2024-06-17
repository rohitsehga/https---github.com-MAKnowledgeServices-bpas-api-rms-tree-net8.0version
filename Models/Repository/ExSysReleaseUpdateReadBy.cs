using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExSysReleaseUpdateReadBy
    {
        public int? ReleaseId { get; set; }
        public DateTime? ReadStamp { get; set; }
        public string ReadBy { get; set; }
    }
}
