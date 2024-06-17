using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class HcCommStatsBenchMark
    {
        public string Type { get; set; }
        public decimal? Calls { get; set; }
        public decimal? Mails { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Status { get; set; }
    }
}
