using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.CustomerFeedback
{
    public partial class ExUserScoring
    {
        public string PeLogn { get; set; }
        public int Sl { get; set; }
        public string Score { get; set; }
        public int? CategoryId { get; set; }
        public string DateTime { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedOn { get; set; }
    }
}
