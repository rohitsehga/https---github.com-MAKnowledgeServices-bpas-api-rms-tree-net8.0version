using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExClientClauseTypeDeptMap
    {
        public int ClauseMapId { get; set; }
        public string ElCode { get; set; }
        public DateTime EffectiveStartDate { get; set; }
        public DateTime? EffectiveEndDate { get; set; }
        public string EntryBy { get; set; }
        public DateTime? Entrystamp { get; set; }
        public string Status { get; set; }
    }
}
