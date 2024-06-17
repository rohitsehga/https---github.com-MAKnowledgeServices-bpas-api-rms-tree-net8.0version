using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.EMPDATA
{
    public partial class ExIppersonLatesthiredate
    {
        public string PeLogn { get; set; }
        public DateTime? Startdate { get; set; }
        public DateTime? Enddate { get; set; }
        public string Recordsource { get; set; }
        public string Userlognid { get; set; }
        public DateTime? Entrystamp { get; set; }
    }
}
