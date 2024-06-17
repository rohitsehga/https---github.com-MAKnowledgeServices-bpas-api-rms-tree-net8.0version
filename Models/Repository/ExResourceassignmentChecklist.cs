using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExResourceassignmentChecklist
    {
        public int Slno { get; set; }
        public string ChecklistType { get; set; }
        public int? ChecklistId { get; set; }
        public int? OnOff { get; set; }
        public int? Id { get; set; }
        public int? Sl { get; set; }
        public int? OffId { get; set; }
        public string YesNoInd { get; set; }
        public string Comments { get; set; }
        public string Status { get; set; }
    }
}
