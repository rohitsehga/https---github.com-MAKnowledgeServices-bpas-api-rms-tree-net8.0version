using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExResourceProjectsStatus
    {
        public string PeLogn { get; set; }
        public short? PrIden { get; set; }
        public int? CuIden { get; set; }
        public DateTime? PrStartdate { get; set; }
        public DateTime? PrEnddate { get; set; }
        public string PrStatus { get; set; }
        public DateTime? Entrystamp { get; set; }
        public string Status { get; set; }
    }
}
