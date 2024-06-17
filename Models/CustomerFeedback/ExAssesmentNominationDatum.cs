using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.CustomerFeedback
{
    public partial class ExAssesmentNominationDatum
    {
        public int? SessionId { get; set; }
        public string PeLogn { get; set; }
        public int? CuIden { get; set; }
        public int? AssesmentQbId { get; set; }
        public string Status { get; set; }
        public string Createdby { get; set; }
        public DateTime? Createdon { get; set; }
        public string Modifiedby { get; set; }
        public DateTime? Modifiedon { get; set; }
    }
}
