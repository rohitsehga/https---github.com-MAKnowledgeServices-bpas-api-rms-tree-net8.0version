using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.CustomerFeedback
{
    public partial class ExAssesmentReminderLog
    {
        public int? AssesmentId { get; set; }
        public string Userid { get; set; }
        public DateTime? Reminderdaretime { get; set; }
        public string Createdby { get; set; }
        public DateTime? Createdon { get; set; }
    }
}
