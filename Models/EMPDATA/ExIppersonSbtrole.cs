using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.EMPDATA
{
    public partial class ExIppersonSbtrole
    {
        public string PeLogn { get; set; }
        public string ElCode { get; set; }
        public string CaCode { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime? Enddate { get; set; }
        public int Sl { get; set; }
        public DateTime Entrystamp { get; set; }
        public string Userlognid { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
    }
}
