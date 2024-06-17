using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.CustomerFeedback
{
    public partial class ExExternalperson
    {
        public int? Id { get; set; }
        public string PersonName { get; set; }
        public string Designation { get; set; }
        public string Location { get; set; }
        public string MailId { get; set; }
        public string PhoneNo { get; set; }
        public string Level { get; set; }
        public string EnteredBy { get; set; }
        public DateTime? EntryStamp { get; set; }
        public int? ClientId { get; set; }
    }
}
