using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExResourceAssignmentSendBack
    {
        public int Id { get; set; }
        public int TranId { get; set; }
        public string Status { get; set; }
        public string Comments { get; set; }
        public string SendBackBy { get; set; }
        public DateTime? SendBackOn { get; set; }
        public string ReSubmitBy { get; set; }
        public DateTime? ReSubmitOn { get; set; }
    }
}
