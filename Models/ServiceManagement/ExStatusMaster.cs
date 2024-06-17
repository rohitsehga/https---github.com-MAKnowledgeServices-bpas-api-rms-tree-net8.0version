using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.ServiceManagement
{
    public partial class ExStatusMaster
    {
        public int StatusId { get; set; }
        public string TranStatus { get; set; }
        public string Status { get; set; }
        public string Createdby { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string Updateby { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
