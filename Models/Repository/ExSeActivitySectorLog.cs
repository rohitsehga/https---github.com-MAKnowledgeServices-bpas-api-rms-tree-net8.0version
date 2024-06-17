using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExSeActivitySectorLog
    {
        public int PrIden { get; set; }
        public int AcIden { get; set; }
        public string PeLogn { get; set; }
        public DateTime DeDate { get; set; }
        public int? SeId { get; set; }
        public int? IndId { get; set; }
        public int? CatId { get; set; }
        public int? RegId { get; set; }
        public int? NoSector { get; set; }
        public DateTime EntryStamp { get; set; }
    }
}
