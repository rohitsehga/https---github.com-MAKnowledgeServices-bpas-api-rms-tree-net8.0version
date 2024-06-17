using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExIpcustomerEngagementtype
    {
        public int CuIden { get; set; }
        public int EngagementtypeId { get; set; }
        public string Clientgroup { get; set; }
        public DateTime? Startdt { get; set; }
        public DateTime? Enddate { get; set; }
        public string Status { get; set; }
        public DateTime Entrystamp { get; set; }
        public string Userlognid { get; set; }
        public string LastupdatedBy { get; set; }
        public DateTime? LastupdatedOn { get; set; }
    }
}
