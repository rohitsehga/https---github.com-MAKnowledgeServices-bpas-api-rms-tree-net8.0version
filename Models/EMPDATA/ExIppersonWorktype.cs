using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.EMPDATA
{
    public partial class ExIppersonWorktype
    {
        public string PeLogn { get; set; }
        public int? Worktype { get; set; }
        public DateTime? WorktypeStartdt { get; set; }
        public DateTime? WorktypeEnddt { get; set; }
        public string Status { get; set; }
        public DateTime? Entrystamp { get; set; }
        public string Userlognid { get; set; }
        public DateTime? Lastupdatedon { get; set; }
        public string Lastupdatedby { get; set; }
    }
}
