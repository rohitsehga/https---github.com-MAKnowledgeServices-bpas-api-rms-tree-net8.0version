using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExStatusdesc
    {
        public int? Sl { get; set; }
        public int? StatusLevelId { get; set; }
        public string Level { get; set; }
        public string StatusIndicator { get; set; }
        public string StatusShortDesc { get; set; }
        public string StatusDesc { get; set; }
        public string Status { get; set; }
        public DateTime? Entrystamp { get; set; }
        public string Userlognid { get; set; }
        public int? OnOff { get; set; }
        public string Type { get; set; }
        public string Bill { get; set; }
    }
}
