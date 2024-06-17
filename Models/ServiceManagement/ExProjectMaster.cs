using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.ServiceManagement
{
    public partial class ExProjectMaster
    {
        public int ProjId { get; set; }
        public string ProjName { get; set; }
        public string ProjStatus { get; set; }
        public string ProjCreatedby { get; set; }
        public DateTime? ProjCreatedon { get; set; }
        public string ProjUpdatedby { get; set; }
        public DateTime? ProjUpdatedon { get; set; }
    }
}
