using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ProjRequestStatus
    {
        public string CuComp { get; set; }
        public int Id { get; set; }
        public string Rt { get; set; }
        public int? Sl { get; set; }
        public string Status { get; set; }
        public string Comment { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Userlogn { get; set; }
        public DateTime Entrystamp { get; set; }
    }
}
