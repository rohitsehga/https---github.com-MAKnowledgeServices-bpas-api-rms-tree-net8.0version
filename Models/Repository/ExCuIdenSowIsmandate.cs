using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExCuIdenSowIsmandate
    {
        public int CuIden { get; set; }
        public bool Issowmandate { get; set; }
        public DateTime? Startdate { get; set; }
        public DateTime? Enddate { get; set; }
        public string Status { get; set; }
        public string Userlognid { get; set; }
        public DateTime? Entrystamp { get; set; }
        public string Updatedby { get; set; }
        public DateTime? Updatedon { get; set; }
    }
}
