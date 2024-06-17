using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.EMPDATA
{
    public partial class ExIppersonContractdetail
    {
        public int Id { get; set; }
        public string PeLogn { get; set; }
        public DateTime? ContractStartDt { get; set; }
        public DateTime? ContractEndDt { get; set; }
        public string Status { get; set; }
        public DateTime? EntryStamp { get; set; }
        public string UserlognId { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
        public string LastUpdatedBy { get; set; }
    }
}
