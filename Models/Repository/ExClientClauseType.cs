using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExClientClauseType
    {
        public int CuIden { get; set; }
        public int ClauseId { get; set; }
        public int ClauseSubid { get; set; }
        public int ClauseTypeId { get; set; }
        public string EntryBy { get; set; }
        public DateTime? Entrystamp { get; set; }
        public string Status { get; set; }
    }
}
