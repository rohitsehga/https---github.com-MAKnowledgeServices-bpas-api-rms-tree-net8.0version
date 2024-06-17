using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class HcAduitDm
    {
        public int? Id { get; set; }
        public string AduitLogn { get; set; }
        public string UserId { get; set; }
        public DateTime? EntryStamp { get; set; }
        public string Status { get; set; }
    }
}
