using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExIppersonEmployementtype
    {
        public string PeLogn { get; set; }
        public string PeEmid { get; set; }
        public int? EmploymentType { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string UserLognId { get; set; }
        public DateTime? EntryStamp { get; set; }
        public string Status { get; set; }
    }
}
