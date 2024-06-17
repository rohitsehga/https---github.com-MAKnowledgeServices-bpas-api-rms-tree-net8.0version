using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class HcMaster
    {
        public int? Id { get; set; }
        public int? CuIden { get; set; }
        public string PeLogn { get; set; }
        public DateTime? StartDate { get; set; }
        public string ClientAnal { get; set; }
        public string Service { get; set; }
        public DateTime? HcDate { get; set; }
        public string HcTrigger { get; set; }
        public string HcKeyOb { get; set; }
    }
}
