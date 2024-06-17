using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExClientsowBlackoutperiod
    {
        public int CuIden { get; set; }
        public string ClientGroup { get; set; }
        public int Sl { get; set; }
        public string Contractsowno { get; set; }
        public DateTime Contractsowdate { get; set; }
        public string Blackoutperiod { get; set; }
        public string Blackoutdesc { get; set; }
        public DateTime? StartDt { get; set; }
        public DateTime? EndDate { get; set; }
        public string Status { get; set; }
        public DateTime? EntryStamp { get; set; }
        public string UserLognId { get; set; }
    }
}
