using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExIpcustomerLocationNew
    {
        public decimal Id { get; set; }
        public int CuIden { get; set; }
        public string CuCode { get; set; }
        public int Sl { get; set; }
        public string Clientgeo { get; set; }
        public string Clienttype { get; set; }
        public DateTime? Startdt { get; set; }
        public DateTime? Enddt { get; set; }
        public string Clientgroup { get; set; }
        public DateTime? Entrystamp { get; set; }
        public string Status { get; set; }
        public string Userlognid { get; set; }
        public int? Mailstatus { get; set; }
        public string LastupdatedBy { get; set; }
        public DateTime? LastupdatedOn { get; set; }
    }
}
