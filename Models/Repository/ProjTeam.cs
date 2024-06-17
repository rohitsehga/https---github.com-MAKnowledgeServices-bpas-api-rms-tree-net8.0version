using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ProjTeam
    {
        public int Id { get; set; }
        public int? Sl { get; set; }
        public string Role { get; set; }
        public string PeLogn { get; set; }
        public DateTime? StartDt { get; set; }
        public DateTime? EndDate { get; set; }
        public string Status { get; set; }
        public DateTime? EntryStamp { get; set; }
        public string UserLognId { get; set; }
    }
}
