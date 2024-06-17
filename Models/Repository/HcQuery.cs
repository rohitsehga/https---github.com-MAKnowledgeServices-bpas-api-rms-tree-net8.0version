using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class HcQuery
    {
        public int Id { get; set; }
        public string Query { get; set; }
        public int? RoleId { get; set; }
        public string Status { get; set; }
        public string UserId { get; set; }
        public DateTime? EntryStamp { get; set; }
    }
}
