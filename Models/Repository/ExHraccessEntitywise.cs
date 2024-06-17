using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExHraccessEntitywise
    {
        public string PeLogn { get; set; }
        public int? CntrlEntityid { get; set; }
        public string Status { get; set; }
        public string Userlognid { get; set; }
        public DateTime? Entrystamp { get; set; }
        public string Lastupdatedby { get; set; }
        public DateTime? Lastupdatedon { get; set; }
    }
}
