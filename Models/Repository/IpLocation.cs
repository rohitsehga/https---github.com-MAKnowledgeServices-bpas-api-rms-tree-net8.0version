using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class IpLocation
    {
        public short IpLocn { get; set; }
        public string LnName { get; set; }
        public short? LnDblo { get; set; }
        public short? LnCaid { get; set; }
        public short? TmpPeln { get; set; }
    }
}
