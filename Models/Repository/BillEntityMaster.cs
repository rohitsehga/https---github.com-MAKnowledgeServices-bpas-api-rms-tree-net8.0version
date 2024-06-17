using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class BillEntityMaster
    {
        public int Id { get; set; }
        public string EntityName { get; set; }
        public string EntityDesc { get; set; }
        public string Status { get; set; }
        public string UserLognId { get; set; }
        public DateTime? EntryStamp { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
