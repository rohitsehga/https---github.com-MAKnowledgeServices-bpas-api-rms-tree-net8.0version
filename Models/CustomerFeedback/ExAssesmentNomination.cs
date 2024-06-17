using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.CustomerFeedback
{
    public partial class ExAssesmentNomination
    {
        public int? AssesmentId { get; set; }
        public string AssesmentLocation { get; set; }
        public string AssesmentDepartment { get; set; }
        public string AssesmentDesignation { get; set; }
        public string Status { get; set; }
        public string Createdby { get; set; }
        public DateTime? Createdon { get; set; }
        public string Modifiedby { get; set; }
        public DateTime? Modifiedon { get; set; }
    }
}
