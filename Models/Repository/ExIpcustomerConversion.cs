using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExIpcustomerConversion
    {
        public int Sl { get; set; }
        public string PeLogn { get; set; }
        public int CuIden { get; set; }
        public int? ProjId { get; set; }
        public string Group { get; set; }
        public string Role { get; set; }
        public DateTime KickOff { get; set; }
        public DateTime? Startdate { get; set; }
        public DateTime? Enddate { get; set; }
        public DateTime? BillStart { get; set; }
        public DateTime? BillEnd { get; set; }
        public DateTime Entrystamp { get; set; }
        public string Userlognid { get; set; }
        public string CurrentReason { get; set; }
        public string Reason { get; set; }
        public string RepLogn { get; set; }
        public string FinStatus { get; set; }
        public DateTime? FinEntrystamp { get; set; }
        public string FinUsrlogn { get; set; }
        public string FinComments { get; set; }
    }
}
