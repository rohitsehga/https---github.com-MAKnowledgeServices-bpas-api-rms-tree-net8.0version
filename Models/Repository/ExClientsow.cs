using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExClientsow
    {
        public int CuIden { get; set; }
        public long Serialno { get; set; }
        public string Sowno { get; set; }
        public string Grp { get; set; }
        public DateTime? Sowdate { get; set; }
        public DateTime? KickOffDt { get; set; }
        public string Typeofservices { get; set; }
        public string SowlegalStatus { get; set; }
        public string Sowstatus { get; set; }
        public string Sowapproved { get; set; }
        public string ComNegotiationStatus { get; set; }
        public string Oktoonboard { get; set; }
        public string LegalComments { get; set; }
        public string FinComments { get; set; }
        public string Status { get; set; }
        public string Entereredby { get; set; }
        public DateTime? Entrystamp { get; set; }
        public int? AgreedNoticePeriod { get; set; }
        public string BlackoutPeriod { get; set; }
        public string BlackoutDesc { get; set; }
        public string ContractSoftcopy { get; set; }
        public string Msano { get; set; }
    }
}
