using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExCompanyMaster
    {
        public int CntrlCc { get; set; }
        public string CcName { get; set; }
        public string CcAddrLine1 { get; set; }
        public string CcAddrLine2 { get; set; }
        public string CcAddrLine3 { get; set; }
        public string CcAddrLine4 { get; set; }
        public string RegistrationNo { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public string OwnerName { get; set; }
        public string MailAddrLine1 { get; set; }
        public string MailAddrLine2 { get; set; }
        public string MailAddrLine3 { get; set; }
        public string MailAddrLine4 { get; set; }
        public int? MailCountryId { get; set; }
        public int? MailLocnId { get; set; }
        public int? CcCountryId { get; set; }
        public int? CcLocnId { get; set; }
        public string Status { get; set; }
        public DateTime? EntryStamp { get; set; }
        public string EntreredbY { get; set; }
        public string Industryvertical { get; set; }
        public string Countrycode { get; set; }
    }
}
