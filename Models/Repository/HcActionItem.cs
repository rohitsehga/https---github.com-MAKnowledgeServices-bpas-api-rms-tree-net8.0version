using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class HcActionItem
    {
        public int? Id { get; set; }
        public int? TypeId { get; set; }
        public int? Sl { get; set; }
        public string ActionItems { get; set; }
        public string AssignedTo { get; set; }
        public DateTime? CompletionDate { get; set; }
        public string UserId { get; set; }
        public DateTime? EntryStamp { get; set; }
        public string Status { get; set; }
        public string Comments { get; set; }
    }
}
