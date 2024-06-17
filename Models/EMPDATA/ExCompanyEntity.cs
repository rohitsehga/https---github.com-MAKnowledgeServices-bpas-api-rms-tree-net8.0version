using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.EMPDATA
{
    public partial class ExCompanyEntity
    {
        public int? CntrlCc { get; set; }
        public int? CntrlEntityId { get; set; }
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
        public string EnteredBy { get; set; }
        public string BusinessUnitId { get; set; }
        public string SiteName { get; set; }
        public string OfficeName { get; set; }
    }
}
