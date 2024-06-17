using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExSlalevelMaster
    {
        public int? LevelId { get; set; }
        public string LevelName { get; set; }
        public string LevelDesc { get; set; }
        public int? LevelOrder { get; set; }
        public string Status { get; set; }
        public string UserLognId { get; set; }
        public DateTime? EntryStamp { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
