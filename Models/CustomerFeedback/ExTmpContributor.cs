using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.CustomerFeedback
{
    public partial class ExTmpContributor
    {
        public int Id { get; set; }
        public int? Cuiden { get; set; }
        public string PersonName { get; set; }
        public string Role { get; set; }
        public string MailId { get; set; }
        public string PhoneNo { get; set; }
        public string EnteredBy { get; set; }
        public DateTime? EntryStamp { get; set; }
    }
}
