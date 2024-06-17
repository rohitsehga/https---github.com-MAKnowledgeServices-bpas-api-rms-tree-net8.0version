using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.EMPDATA
{
    public partial class ExResourceclientanalyst
    {
        public string PeLogn { get; set; }
        public int? CuIden { get; set; }
        public string ClientAnalystName { get; set; }
        public string ClientAnalystCostcenterNo { get; set; }
        public string ClientAnalystEmail { get; set; }
        public string ClientAnalystPhone { get; set; }
        public string ClientAnalystaddr1 { get; set; }
        public string ClientAnalystaddr2 { get; set; }
        public string ClientAnalystaddr3 { get; set; }
        public string ClientAnalystaddr4 { get; set; }
        public string ClientAnalystlocn { get; set; }
        public string ClientAnalystDesgn { get; set; }
        public DateTime? ClientAnalystStartDt { get; set; }
        public DateTime? ClientAnalystEndDt { get; set; }
        public string ClientAnal { get; set; }
        public string AmbaLogn { get; set; }
        public string MainAnalyst { get; set; }
        public string RecordType { get; set; }
        public string Status { get; set; }
        public DateTime? EntryStamp { get; set; }
        public string UserlognId { get; set; }
    }
}
