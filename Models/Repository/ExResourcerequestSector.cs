using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExResourcerequestSector
    {
        public int? ReqId { get; set; }
        public long? Rolesl { get; set; }
        public long? Sl { get; set; }
        public int? SectorId { get; set; }
        public int? IndId { get; set; }
        public int? CatId { get; set; }
        public int? RegionId { get; set; }
        public string Userlognid { get; set; }
        public DateTime? Entrystamp { get; set; }
    }
}
