using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExResourceassignmentlog
    {
        public int? Sl { get; set; }
        public int? CuIden { get; set; }
        public string PeLogn { get; set; }
        public int? ProjId { get; set; }
        public string Group { get; set; }
        public DateTime? KickOff { get; set; }
        public DateTime? DateOfMove { get; set; }
        public DateTime? EffectiveFrom { get; set; }
        public DateTime? EffectiveTo { get; set; }
        public string Reason { get; set; }
        public DateTime? Entrystamp { get; set; }
        public string Userlognid { get; set; }
        public string Status { get; set; }
        public string ApproveStatus { get; set; }
        public string RepValognid { get; set; }
    }
}
