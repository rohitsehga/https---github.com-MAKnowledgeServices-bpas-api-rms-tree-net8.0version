using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExNewclientrequest
    {
        public string CuCode { get; set; }
        public string LegalName { get; set; }
        public string Group { get; set; }
        public string Acmngr { get; set; }
        public string Chead { get; set; }
        public string ClientType { get; set; }
        public string ClientAnalyCountryRegion { get; set; }
        public DateTime? ClientStDt { get; set; }
        public string ServiceType { get; set; }
        public string ServicesId { get; set; }
        public string UserLognId { get; set; }
        public DateTime? EntryStamp { get; set; }
        public string Status { get; set; }
        public string MainEquitServ { get; set; }
        public string SubEquitServ { get; set; }
        public string QntsServ { get; set; }
    }
}
