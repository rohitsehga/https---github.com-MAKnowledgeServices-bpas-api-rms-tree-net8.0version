using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExResourceassignmentstatus
    {
        public int? Sl { get; set; }
        public int? Tranid { get; set; }
        public string PeLogn { get; set; }
        public int CuIden { get; set; }
        public int? ProjId { get; set; }
        public string Group { get; set; }
        public string Role { get; set; }
        public DateTime KickOff { get; set; }
        public DateTime? DateOfMove { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime? Enddate { get; set; }
        public DateTime? BillStart { get; set; }
        public DateTime? BillEnd { get; set; }
        public string Status { get; set; }
        public int? StatusLevelId { get; set; }
        public DateTime Entrystamp { get; set; }
        public string Userlognid { get; set; }
        /// <summary>
        /// To Save the Approve Status P=Pending,A=Approved,R=Rejected
        /// </summary>
        public string ApproveStatus { get; set; }
        public string OffboardStatus { get; set; }
        public DateTime? OffboardStamp { get; set; }
        public string OffboardUserlognid { get; set; }
        public string Reason { get; set; }
        public string OffboardReason { get; set; }
        public string FinStatus { get; set; }
        public DateTime? BillpauseStartdate { get; set; }
        public DateTime? BillpauseEnddate { get; set; }
    }
}
