using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExOffboardsDocumentation
    {
        public string PeLogn { get; set; }
        public int CuIden { get; set; }
        public int Id { get; set; }
        public int Sl { get; set; }
        public string Timesheet { get; set; }
        public string CkmsDb { get; set; }
        public string LeaveYettoapprove { get; set; }
        public string LeaveProcessed { get; set; }
        public string Clearance { get; set; }
        public string Comments { get; set; }
        public string Status { get; set; }
        public DateTime? Entrystamp { get; set; }
        public string UpdatedBy { get; set; }
    }
}
