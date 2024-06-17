using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExGroupMainservice
    {
        public string Clientgroup { get; set; }
        public long Maingroupid { get; set; }
        public string Maingroupdesc { get; set; }
        public DateTime? Entrystamp { get; set; }
        public string Userlognid { get; set; }
        public string Status { get; set; }
    }
}
