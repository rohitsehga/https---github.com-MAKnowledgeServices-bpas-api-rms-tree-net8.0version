using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class HcDatum
    {
        public int? Id { get; set; }
        public DateTime? RecordDate { get; set; }
        public string Field { get; set; }
        public string Rating { get; set; }
        public string Link { get; set; }
        public DateTime? EntryStamp { get; set; }
    }
}
