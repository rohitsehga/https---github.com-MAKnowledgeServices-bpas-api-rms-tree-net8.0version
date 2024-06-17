using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExSysReleaseUpdate
    {
        public int? Id { get; set; }
        public int? ModuleId { get; set; }
        public string Heading { get; set; }
        public string Brief { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? Enddate { get; set; }
        public string Status { get; set; }
        public string UserLogn { get; set; }
        public DateTime? EntryStamp { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
