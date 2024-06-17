using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.ServiceManagement
{
    public partial class ExRequesttran
    {
        public int TranId { get; set; }
        public int ProjId { get; set; }
        public int ReqTypeId { get; set; }
        public int? PriorityId { get; set; }
        public string TranDesc { get; set; }
        public string TranComments { get; set; }
        public string TranAttachFileName { get; set; }
        public string TranRequestor { get; set; }
        public DateTime? TranRaiseOn { get; set; }
        public string TranRequestStatus { get; set; }
        public string TranActionBy { get; set; }
        public DateTime? TranActionOn { get; set; }
        public string EngineerComments { get; set; }
        public string TranUpdateBy { get; set; }
        public DateTime? TranUpdateOn { get; set; }
    }
}
