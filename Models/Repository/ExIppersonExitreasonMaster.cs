using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExIppersonExitreasonMaster
    {
        public int ReasonId { get; set; }
        public string ReasonDesc { get; set; }
        public string ReasonStatus { get; set; }
        public string EnteredBy { get; set; }
        public DateTime? Entrystamp { get; set; }
    }
}
