using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExBenchreporting
    {
        public int? IpLocn { get; set; }
        public string Dept { get; set; }
        public string Mngrlognid { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Status { get; set; }
        public DateTime? Entrystamp { get; set; }
        public string UserLognId { get; set; }
    }
}
