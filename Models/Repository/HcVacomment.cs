using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class HcVacomment
    {
        public int? Id { get; set; }
        public int? Qid { get; set; }
        public string Comments { get; set; }
        public string UserId { get; set; }
        public DateTime? EntryStamp { get; set; }
    }
}
