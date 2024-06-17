using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExResourcePhaseHour
    {
        public string PeLogn { get; set; }
        public int? CuIden { get; set; }
        public string Phase { get; set; }
        public DateTime? RecordDate { get; set; }
        public decimal? Hrs { get; set; }
        public decimal? Shrs { get; set; }
        public decimal? Percnt { get; set; }
    }
}
