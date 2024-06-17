using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class RfpBugCapture
    {
        public decimal Id { get; set; }
        public string BugDesc { get; set; }
        public string EmailId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string CreBy { get; set; }
        public DateTime CreDate { get; set; }
        public string IsBug { get; set; }
    }
}
