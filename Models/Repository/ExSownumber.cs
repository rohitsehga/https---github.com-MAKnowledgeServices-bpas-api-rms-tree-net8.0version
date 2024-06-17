using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExSownumber
    {
        public int? CuIden { get; set; }
        public string ElCode { get; set; }
        public string SowNumber { get; set; }
        public int? Slnumber { get; set; }
        public DateTime? Sowdate { get; set; }
        public DateTime? SowrenewDate { get; set; }
        public int? TotalResource { get; set; }
        public int? TotalBilledResource { get; set; }
        public bool? Bgccheck { get; set; }
        public bool? DrugTestCheck { get; set; }
        public bool? IdentityCheck { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string Msanumber { get; set; }
        public DateTime? Msadate { get; set; }
        public string MsafileName { get; set; }
        public string MsafilePath { get; set; }
        public string MetaData { get; set; }
        public string Status { get; set; }
        public DateTime? EntryStamp { get; set; }
        public string UserLognId { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
    }
}
