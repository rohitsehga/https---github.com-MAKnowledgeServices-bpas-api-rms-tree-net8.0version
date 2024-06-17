using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class AmbTtphasemap
    {
        public string TtCode { get; set; }
        public string PhCode { get; set; }
        public string Projtype { get; set; }
        public string TtBillable { get; set; }
        public string TtRole { get; set; }
        public short? TtStatus { get; set; }
    }
}
