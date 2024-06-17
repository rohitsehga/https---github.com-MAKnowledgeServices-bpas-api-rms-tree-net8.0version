using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExIpcustomerBusinessProcessMaster
    {
        public int CuIden { get; set; }
        public int BpId { get; set; }
        public string BpName { get; set; }
        public string BpDesc { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? EntryStamp { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
