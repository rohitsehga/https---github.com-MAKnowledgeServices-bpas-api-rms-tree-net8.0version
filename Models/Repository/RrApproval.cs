using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class RrApproval
    {
        public int CuIden { get; set; }
        public string Group { get; set; }
        public int Locn { get; set; }
        public string PeLogn { get; set; }
        public string Status { get; set; }
    }
}
