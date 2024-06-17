using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExResourceallocationLog
    {
        public int Sl { get; set; }
        public int CuIden { get; set; }
        public string PeLogn { get; set; }
        public int? ProjId { get; set; }
        public DateTime KickOff { get; set; }
        public DateTime? DateOfMove { get; set; }
        public DateTime AllocStartdt { get; set; }
        public DateTime? AllocEnddate { get; set; }
        public decimal? Allocation { get; set; }
        public string Userlognid { get; set; }
        public DateTime Entrystamp { get; set; }
        public string Status { get; set; }
        public string CheadStatus { get; set; }
        public string CheadComments { get; set; }
        public string CheadLogn { get; set; }
        public DateTime? CheadEntrystamp { get; set; }
        public DateTime? EnddateStamp { get; set; }
        public string EnddateUserlognid { get; set; }
        public DateTime? UpdatedEntrystamp { get; set; }
        public string PostStatus { get; set; }
        public string UpdateUserlognid { get; set; }
        public DateTime? UpdateEntrystamp { get; set; }
        public string Comments { get; set; }
        public string LogUserlognid { get; set; }
        public DateTime? LogEntrystamp { get; set; }
    }
}
