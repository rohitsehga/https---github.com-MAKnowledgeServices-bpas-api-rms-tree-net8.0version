using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.EMPDATA
{
    public partial class ExIppersonLocation
    {
        public string PeLogn { get; set; }
        public int? PeLocn { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string UserLognId { get; set; }
        public DateTime? Entrystamp { get; set; }
        public string Status { get; set; }
        public string PeEmId { get; set; }
    }
}
