using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExResourcerequestSkill
    {
        public int? ReqId { get; set; }
        public long? Rolesl { get; set; }
        public long? Sl { get; set; }
        public string Skillscode { get; set; }
        public string Skills { get; set; }
        public string Skilllevel { get; set; }
        public string Userlognid { get; set; }
        public DateTime? Entrystamp { get; set; }
        public decimal Id { get; set; }
    }
}
