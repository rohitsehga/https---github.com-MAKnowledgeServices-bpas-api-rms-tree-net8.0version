using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExResourceassignmentTran
    {
        public int Id { get; set; }
        public int Sl { get; set; }
        public int Tranid { get; set; }
        public string PeLogn { get; set; }
        public int CuIden { get; set; }
        public int ProjId { get; set; }
        public DateTime KickOff { get; set; }
        public string Group { get; set; }
        public string Role { get; set; }
        public string Reason { get; set; }
        public DateTime? Startdate { get; set; }
        public decimal? Allocation { get; set; }
        public string ChangeType { get; set; }
        public string Comments { get; set; }
        public DateTime Entrystamp { get; set; }
        public string Userlognid { get; set; }
        public string Status { get; set; }
        public string Oldvalue { get; set; }
        public string Newvalue { get; set; }
        public string ApproverComments { get; set; }
        public string Approvedby { get; set; }
        public DateTime? Approvedon { get; set; }
    }
}
