using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ClientWorkordersWithAnalyst
    {
        public double? Slno { get; set; }
        public string ClientCode { get; set; }
        public string ClientCodeWithLocation { get; set; }
        public string Ambaanalystname { get; set; }
        public string ClientType { get; set; }
        public string ClientGroup { get; set; }
        public string WorkOrderNumber { get; set; }
        public string Msano { get; set; }
        public DateTime? Msadate { get; set; }
        public string ContractNo { get; set; }
        public string AccountManager { get; set; }
        public string WorkorderContactName { get; set; }
        public string WorkorderDate { get; set; }
        public string BillingPersonName { get; set; }
        public string BillingPersonEmailId { get; set; }
        public string EmailCc { get; set; }
        public string BillingFrequency { get; set; }
        public string BillingMethod { get; set; }
        public string RateType { get; set; }
        public double? BillingRate { get; set; }
        public string PresentationCurrency { get; set; }
        public string BillingCurrency { get; set; }
        public string BillingAddress1 { get; set; }
        public string BillingAddress2 { get; set; }
        public string BillingAddress3 { get; set; }
        public string BillingAddress4 { get; set; }
        public string BillingAddress5 { get; set; }
        public string BillingCity { get; set; }
        public string BillingCountry { get; set; }
        public string Nextrevision { get; set; }
        public double? Comments { get; set; }
    }
}
