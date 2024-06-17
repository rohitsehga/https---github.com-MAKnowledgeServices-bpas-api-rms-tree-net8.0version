using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.EMPDATA
{
    public partial class ExIppersonEmployeeRecord
    {
        public int Sl { get; set; }
        public string PeLogn { get; set; }
        public int DocDescId { get; set; }
        public string DocTitle { get; set; }
        public string DocName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Status { get; set; }
        public DateTime? EntryStamp { get; set; }
        public string UserLognId { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime? LastUpdaetdOn { get; set; }
        public string ApproveStatus { get; set; }
        public string ApprovedBy { get; set; }
        public DateTime? ApprovedOn { get; set; }
    }
}
