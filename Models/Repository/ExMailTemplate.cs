using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExMailTemplate
    {
        public int? Id { get; set; }
        public string TemplateName { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime? Createdon { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? Updatedon { get; set; }
        public string Updatedby { get; set; }
        public string Status { get; set; }
    }
}
