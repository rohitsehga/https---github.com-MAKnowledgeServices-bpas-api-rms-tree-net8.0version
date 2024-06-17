using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class QReportName
    {
        public int ReportId { get; set; }
        public string ReportName { get; set; }
        public string ReportDesc { get; set; }
        public string Status { get; set; }
        public string UserLognId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
