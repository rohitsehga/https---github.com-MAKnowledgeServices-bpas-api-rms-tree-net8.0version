using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExResourceTentativeLongLeave
    {
        public string PeLogn { get; set; }
        public DateTime? LeaveStartDate { get; set; }
        public DateTime? LeaveEndDate { get; set; }
        public string Status { get; set; }
        public string Userlognid { get; set; }
        public DateTime? Entrystamp { get; set; }
        public string Updatedby { get; set; }
        public DateTime? Updatedon { get; set; }
    }
}
