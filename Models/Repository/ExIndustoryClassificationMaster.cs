using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExIndustoryClassificationMaster
    {
        public int ClassificationId { get; set; }
        public string Classification { get; set; }
        public string EntryBy { get; set; }
        public DateTime? Entrystamp { get; set; }
        public string Status { get; set; }
    }
}
