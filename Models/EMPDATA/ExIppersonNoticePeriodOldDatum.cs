using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.EMPDATA
{
    public partial class ExIppersonNoticePeriodOldDatum
    {
        public string PeLogn { get; set; }
        public int? ExitReason { get; set; }
        public DateTime? ResignDate { get; set; }
        public DateTime? ExitDate { get; set; }
        public string Status { get; set; }
        public DateTime? EntryStamp { get; set; }
        public string UserLogn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
    }
}
