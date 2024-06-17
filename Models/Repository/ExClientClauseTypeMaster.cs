using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExClientClauseTypeMaster
    {
        public int ClauseTypeId { get; set; }
        public string TypeDesc { get; set; }
        public string EntryBy { get; set; }
        public DateTime? Entrystamp { get; set; }
        public string Status { get; set; }
        public int CatId { get; set; }
    }
}
