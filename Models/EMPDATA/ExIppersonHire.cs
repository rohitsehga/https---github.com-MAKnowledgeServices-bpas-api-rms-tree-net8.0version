using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.EMPDATA
{
    public partial class ExIppersonHire
    {
        public int? SourceHiringId { get; set; }
        public string PeLogn { get; set; }
        public DateTime? PeJoin { get; set; }
        public DateTime? PeQuit { get; set; }
        public DateTime? ResignationDate { get; set; }
        public DateTime? LastWorkingDate { get; set; }
        public int? QuitReason { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? QuitOn { get; set; }
        public string QuitBy { get; set; }
    }
}
