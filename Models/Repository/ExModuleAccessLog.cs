using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExModuleAccessLog
    {
        public string PeLogn { get; set; }
        public int? ModuleId { get; set; }
        public DateTime? EntryStamp { get; set; }
    }
}
