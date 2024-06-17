using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExIpcustomerEngagement
    {
        public int CuIden { get; set; }
        public int Engagement { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime? Enddate { get; set; }
        public string Status { get; set; }
        public string UserLogn { get; set; }
        public DateTime? Entrystamp { get; set; }
        public DateTime? Lastupdatedon { get; set; }
        public string Lastupdatedby { get; set; }
    }
}
