using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExModuleMaster
    {
        public int? ModuleId { get; set; }
        public string ModuleName { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public int? ApplicationId { get; set; }
        public string Status { get; set; }
    }
}
