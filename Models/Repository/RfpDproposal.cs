using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class RfpDproposal
    {
        public decimal Id { get; set; }
        public decimal ProId { get; set; }
        public int QuesId { get; set; }
        public int ResponseId { get; set; }
        public string AssignTo { get; set; }
        public bool IsActive { get; set; }
        public string CreBy { get; set; }
        public DateTime CreDate { get; set; }
        public string UpdBy { get; set; }
        public DateTime? UpdDate { get; set; }
    }
}
