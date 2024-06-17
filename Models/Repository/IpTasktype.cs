using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class IpTasktype
    {
        public string TtCode { get; set; }
        public string TtName { get; set; }
        public string TtEnvr { get; set; }
        public string TtPhse { get; set; }
        public int? TtNote { get; set; }
        public string TtArch { get; set; }
    }
}
