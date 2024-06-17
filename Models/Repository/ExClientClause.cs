using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExClientClause
    {
        public int CuIden { get; set; }
        public int ClauseId { get; set; }
        public int ClauseSubid { get; set; }
        public string ClauseDesc { get; set; }
        public DateTime CommenceStartDate { get; set; }
        public DateTime? CommenceEndDate { get; set; }
        public string EntryBy { get; set; }
        public DateTime? Entrystamp { get; set; }
        public string Status { get; set; }
        public string Attachment { get; set; }
    }
}
