using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExClientcontract
    {
        public int CuIden { get; set; }
        public string ClientGroup { get; set; }
        public string Location { get; set; }
        public long Serialno { get; set; }
        public string Contractrefno { get; set; }
        public DateTime? Contractrefdate { get; set; }
        public string Iscontractsigned { get; set; }
        public DateTime? Contractsigneddate { get; set; }
        public DateTime? Contracteffectfrom { get; set; }
        public DateTime? Contracteffectto { get; set; }
        public string Contractsoftcopy { get; set; }
        public string Comcontractsigned { get; set; }
        public DateTime? Comcontractsigneddate { get; set; }
        public DateTime? Comcontracteffectfrom { get; set; }
        public DateTime? Comcontracteffectto { get; set; }
        public string Comkickoffapproved { get; set; }
        public string Isoktoonboard { get; set; }
        public DateTime? EntrystampLegal { get; set; }
        public DateTime? EntrystampFinance { get; set; }
        public string Status { get; set; }
        public string EntereredbyLegal { get; set; }
        public string EntereredbyFinance { get; set; }
        public string ContractStatus { get; set; }
        public string CommNegStatus { get; set; }
        public string LegalDeptComment { get; set; }
        public string FinDeptComment { get; set; }
        public int? AgreedNoticePeriod { get; set; }
        public string BlackoutPeriod { get; set; }
        public string BlackoutDesc { get; set; }
        public string Typeofservices { get; set; }
    }
}
