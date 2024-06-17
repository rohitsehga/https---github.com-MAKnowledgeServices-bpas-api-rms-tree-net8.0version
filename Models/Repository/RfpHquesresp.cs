using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class RfpHquesresp
    {
        public decimal QuesId { get; set; }
        public string Question { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsActive { get; set; }
        public int QuesStatus { get; set; }
        public string CreBy { get; set; }
        public DateTimeOffset CreDate { get; set; }
        public string UpdBy { get; set; }
        public DateTimeOffset UpdDate { get; set; }
    }
}
