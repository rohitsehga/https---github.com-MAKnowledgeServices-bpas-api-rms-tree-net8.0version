using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.EMPDATA
{
    public partial class ExIppersonEntity
    {
        public string PeLogn { get; set; }
        public int? CntrlCc { get; set; }
        public int? CntrlEntityId { get; set; }
        public int PeLocn { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string UserLognId { get; set; }
        public DateTime? EntryStamp { get; set; }
        public string Status { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
        public string LastUpdatedBy { get; set; }
    }
}
