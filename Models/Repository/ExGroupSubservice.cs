using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExGroupSubservice
    {
        public string Clientgroup { get; set; }
        public long Maingroupid { get; set; }
        public long Subgroupid { get; set; }
        public string Subgroupdesc { get; set; }
        public DateTime? Entrystamp { get; set; }
        public string Userlognid { get; set; }
        public string Status { get; set; }
    }
}
