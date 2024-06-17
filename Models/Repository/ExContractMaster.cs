using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExContractMaster
    {
        public int? Cuiden { get; set; }
        public string Msanumber { get; set; }
        public DateTime? Msadate { get; set; }
        public string MsafilePath { get; set; }
        public string MsafileName { get; set; }
        public string Sownumber { get; set; }
        public DateTime? Sowdate { get; set; }
        public string SowfilePath { get; set; }
        public string SowfileName { get; set; }
        public string ServiceLine { get; set; }
        public int? NoOfResource { get; set; }
        public int? TotalBilledResource { get; set; }
        public string Backgroundcheck { get; set; }
        public string Drugcheck { get; set; }
        public string Idenditycheck { get; set; }
        public DateTime? Entrystamp { get; set; }
        public string Enteredby { get; set; }
        public string Status { get; set; }
    }
}
