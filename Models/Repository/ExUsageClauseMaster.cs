using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExUsageClauseMaster
    {
        public int? Cid { get; set; }
        public string Clause { get; set; }
        public int? Isblackout { get; set; }
        public string Status { get; set; }
        public string Userlognid { get; set; }
        public DateTime? Entrystamp { get; set; }
        public string Lastupdatedby { get; set; }
        public DateTime? Lastupdatedon { get; set; }
    }
}
