using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.CustomerFeedback
{
    public partial class ExContributor
    {
        public int Id { get; set; }
        public int AssesmentId { get; set; }
        public string Contributorcategory { get; set; }
        public string PersonName { get; set; }
        public string Designation { get; set; }
        public string Location { get; set; }
        public string MailId { get; set; }
        public string PhoneNo { get; set; }
        public string Status { get; set; }
        public string AssessmentStatus { get; set; }
        public string EnteredBy { get; set; }
        public DateTime? EntryStamp { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? Updatedon { get; set; }
    }
}
