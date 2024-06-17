using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExHrmodulemaster
    {
        public int? ModuleId { get; set; }
        public int? ApplicationId { get; set; }
        public string ModuleName { get; set; }
        public string Status { get; set; }
        public string UserLognId { get; set; }
        public DateTime? EntryStamp { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
    }
}
