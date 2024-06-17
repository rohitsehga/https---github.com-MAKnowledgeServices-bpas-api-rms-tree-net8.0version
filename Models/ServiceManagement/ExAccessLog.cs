using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.ServiceManagement
{
    public partial class ExAccessLog
    {
        public int Id { get; set; }
        public int? ProjectId { get; set; }
        public string UserPelogn { get; set; }
        public DateTime? Entrystamp { get; set; }
    }
}
