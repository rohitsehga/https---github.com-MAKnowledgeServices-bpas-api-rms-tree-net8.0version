using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExClientClauseDepartment
    {
        public int CuIden { get; set; }
        public int ClauseId { get; set; }
        public int ClauseSubid { get; set; }
        public string ElCode { get; set; }
        public string EntryBy { get; set; }
        public DateTime? Entrystamp { get; set; }
        public string Status { get; set; }
    }
}
