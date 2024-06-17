using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExClientcontractBlackoutperiod
    {
        public int CuIden { get; set; }
        public string Clientgroup { get; set; }
        public string Location { get; set; }
        public int Sl { get; set; }
        public string Contractrefno { get; set; }
        public DateTime? Contractrefdate { get; set; }
        public string Blackoutperiod { get; set; }
        public string Blackoutdesc { get; set; }
        public DateTime? Startdt { get; set; }
        public DateTime? Enddate { get; set; }
        public string Status { get; set; }
        public DateTime? Entrystamp { get; set; }
        public string Userlognid { get; set; }
    }
}
