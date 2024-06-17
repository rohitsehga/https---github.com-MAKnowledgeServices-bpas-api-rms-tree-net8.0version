using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class IpPhase
    {
        public string ElCode { get; set; }
        public string PhCode { get; set; }
        public string PhName { get; set; }
        public short? PhOrdr { get; set; }
    }
}
