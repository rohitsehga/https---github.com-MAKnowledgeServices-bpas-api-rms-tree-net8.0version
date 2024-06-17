using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.EMPDATA
{
    public partial class ExPersonIdAllocation
    {
        public string LastPersonId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? Createdon { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
