using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExEscalationMatrix
    {
        public int? ProductId { get; set; }
        public int? EventId { get; set; }
        public int? LevelId { get; set; }
        public int? RoleId { get; set; }
        public int? HowManyTimesToNotify { get; set; }
        public string Status { get; set; }
        public string UserLognId { get; set; }
        public DateTime? EntryStamp { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int? EscalationInDays { get; set; }
    }
}
