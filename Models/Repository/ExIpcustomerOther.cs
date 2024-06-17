using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExIpcustomerOther
    {
        public int Sl { get; set; }
        public int CuIden { get; set; }
        public int? ProjId { get; set; }
        public string PeLogn { get; set; }
        public string Role { get; set; }
        public int? Geo { get; set; }
        public string Clientgeo { get; set; }
        public string Clientgroup { get; set; }
        public DateTime Startdt { get; set; }
        public DateTime? Enddate { get; set; }
        public string Status { get; set; }
        public DateTime? Entrystamp { get; set; }
        public string Userlognid { get; set; }
        public int? Mailstatus { get; set; }
        public string LastupdatedBy { get; set; }
        public DateTime? LastupdatedOn { get; set; }
    }
}
