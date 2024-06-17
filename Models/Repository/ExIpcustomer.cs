using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExIpcustomer
    {
        public int CuIden { get; set; }
        public string CuCode { get; set; }
        public string CuName { get; set; }
        public DateTime Entrystamp { get; set; }
        public string Status { get; set; }
        public string WinLoginid { get; set; }
        public string Clienttype { get; set; }
        public string NdasignDate { get; set; }
        public string LastupdatedBy { get; set; }
        public DateTime? LastupdatedOn { get; set; }
        public string Bgv { get; set; }
        public int? GracePeriod { get; set; }
        public string DrugTestReq { get; set; }
        public DateTime? Lastupdatedon1 { get; set; }
        public string Lastupdatedby1 { get; set; }
        public string RepliconDataPort { get; set; }
        public string ClientGroup { get; set; }
    }
}
