using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExCsatHelpdeskLink
    {
        public int? ReqId { get; set; }
        public string PeLogn { get; set; }
        public string Links { get; set; }
        public string Status { get; set; }
        public string Userlognid { get; set; }
        public DateTime? Entrystamp { get; set; }
    }
}
