using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.EMPDATA
{
    public partial class ExIppersonWorkingoffice
    {
        public string PeLogn { get; set; }
        public string WorkingOffice { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Status { get; set; }
        public DateTime? EntryStamp { get; set; }
        public string UpdatedBy { get; set; }
    }
}
