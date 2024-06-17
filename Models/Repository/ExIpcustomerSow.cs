using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExIpcustomerSow
    {
        public int Sl { get; set; }
        public int CuIden { get; set; }
        public int? ProjId { get; set; }
        public string PeLogn { get; set; }
        public DateTime KickOff { get; set; }
        public DateTime? DateOfMove { get; set; }
        public DateTime SowStartdt { get; set; }
        public DateTime? SowEnddate { get; set; }
        public string Sow { get; set; }
        public int? Usageclauseid { get; set; }
        public int? Blackout { get; set; }
        public string Status { get; set; }
        public DateTime Entrystamp { get; set; }
        public string Userlognid { get; set; }
        public DateTime? EnddateStamp { get; set; }
        public string EnddateUserlognid { get; set; }
    }
}
