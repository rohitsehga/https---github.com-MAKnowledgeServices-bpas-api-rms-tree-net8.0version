using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExClientClauseMasterCommunicateto
    {
        public string Id { get; set; }
        public string CaCode { get; set; }
        public string CommunicateTo { get; set; }
        public string EntryBy { get; set; }
        public DateTime? Entrystamp { get; set; }
        public string Status { get; set; }
        public string RelatedTo { get; set; }
    }
}
