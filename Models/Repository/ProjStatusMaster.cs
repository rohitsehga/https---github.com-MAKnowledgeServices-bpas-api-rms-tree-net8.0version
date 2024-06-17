using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ProjStatusMaster
    {
        public int Id { get; set; }
        public string StatusId { get; set; }
        public string Status { get; set; }
        public DateTime? Entrystamp { get; set; }
        public string Userlogn { get; set; }
        public string Type { get; set; }
    }
}
