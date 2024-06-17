using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class Cupload
    {
        public string ClientCode { get; set; }
        public string LegalIdentity { get; set; }
        public string ContractType { get; set; }
        public string DeliveryManager { get; set; }
        public string ServiceLince { get; set; }
        public DateTime? ContractCommencementDate { get; set; }
        public string UseOfResources { get; set; }
        public string ChangesRequestProcedure { get; set; }
        public string DataSources { get; set; }
        public string NonSolicitationClause { get; set; }
        public string ConfidentialityClause { get; set; }
        public string IpRights { get; set; }
        public string AcceptanceProcedures { get; set; }
        public string BlackOutPeriod { get; set; }
        public string ImWaiver { get; set; }
        public string OverlapPeriod { get; set; }
        public string SecurityTokens { get; set; }
        public string BackgroundChecking { get; set; }
        public string BcpRequirements { get; set; }
        public string SeatingArrangments { get; set; }
        public string RelationshipManagement { get; set; }
        public string SubContracting { get; set; }
        public string TerminationClause { get; set; }
        public string TerminationRelatedObligations { get; set; }
        public string Audits { get; set; }
        public string LiabilityClause { get; set; }
        public string HrRelated { get; set; }
        public string AdminRelated { get; set; }
        public string ItIsRelated { get; set; }
        public string DeliveryRelated { get; set; }
        public string OtherObligations { get; set; }
        public string MnpiRequirements { get; set; }
        public string OtherComments { get; set; }
        public int? CuIden { get; set; }
    }
}
