using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExResourcebillpercentLog
    {
        public int Sl { get; set; }
        public int CuIden { get; set; }
        public string PeLogn { get; set; }
        public int? ProjId { get; set; }
        public DateTime KickOff { get; set; }
        public DateTime? DateOfMove { get; set; }
        public DateTime BillpercentStartdt { get; set; }
        public DateTime? BillpercentEnddt { get; set; }
        public decimal? Billpercent { get; set; }
        public string Userlognid { get; set; }
        public DateTime Entrystamp { get; set; }
        public string Status { get; set; }
        public string FinStatus { get; set; }
        public string FinComments { get; set; }
        public string FinLogn { get; set; }
        public DateTime? FinEntrystamp { get; set; }
        public DateTime? EnddateStamp { get; set; }
        public string EnddateUserlognid { get; set; }
        public string UpdateUserlognid { get; set; }
        public DateTime? UpdateEntrystamp { get; set; }
        public string Comments { get; set; }
        public string LogUserlognid { get; set; }
        public DateTime? LogEntrystamp { get; set; }
    }
}
