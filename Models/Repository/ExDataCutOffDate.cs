using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExDataCutOffDate
    {
        public int Id { get; set; }
        public int? ForMonth { get; set; }
        public int? ForYear { get; set; }
        public DateTime? CutOffDate { get; set; }
        public string Status { get; set; }
        public string UserLognId { get; set; }
        public DateTime? EntryStamp { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
