using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExIppersonTeamname
    {
        public string PeLogn { get; set; }
        public string TnCode { get; set; }
        public DateTime Startdt { get; set; }
        public DateTime? Enddate { get; set; }
        public string Lognid { get; set; }
        public string Status { get; set; }
        public DateTime Entrystamp { get; set; }
    }
}
