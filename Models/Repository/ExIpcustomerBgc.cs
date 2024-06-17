using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExIpcustomerBgc
    {
        public int CuIden { get; set; }
        public string PeLogn { get; set; }
        public DateTime BgcinitiateDate { get; set; }
        public string Bgcstatus { get; set; }
        public string Bgccomments { get; set; }
        public DateTime? BgcclosureDate { get; set; }
        public int? BgcvendorId { get; set; }
        public DateTime? IdbcompletionDate { get; set; }
        public DateTime? IdccheckDate { get; set; }
        public DateTime? DrugTestDate { get; set; }
        public DateTime? NdasignDate { get; set; }
        public string Status { get; set; }
        public string UserLognId { get; set; }
        public DateTime? EntryStamp { get; set; }
    }
}
