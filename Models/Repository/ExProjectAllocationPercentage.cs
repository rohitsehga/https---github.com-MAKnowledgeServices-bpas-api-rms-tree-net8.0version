using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExProjectAllocationPercentage
    {
        public int? PrIden { get; set; }
        public string PeLogn { get; set; }
        public int? AllocationPercentage { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string EnteredBy { get; set; }
        public DateTime? EnteredOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int? CuIden { get; set; }
        public DateTime? KickOff { get; set; }
    }
}
