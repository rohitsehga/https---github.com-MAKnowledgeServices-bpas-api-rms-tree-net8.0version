using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExCompanyShiftMaster
    {
        public int? ShiftId { get; set; }
        public string ShiftName { get; set; }
        public string ShiftStartTime { get; set; }
        public string ShiftEndTime { get; set; }
        public string Status { get; set; }
        public string UserLognId { get; set; }
        public DateTime? Entrystamp { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
    }
}
