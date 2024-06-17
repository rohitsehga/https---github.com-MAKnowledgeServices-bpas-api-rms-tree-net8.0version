using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExCompanyUnitMaster
    {
        public int? CntlCc { get; set; }
        public int? CntlUc { get; set; }
        public int? CntlOc { get; set; }
        public int? CntrlEntityId { get; set; }
        public string UcName { get; set; }
        public string OwnerName { get; set; }
        public string RegistrationNo { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public int? CountryId { get; set; }
        public string AddrLine1 { get; set; }
        public string AddrLine2 { get; set; }
        public string AddrLine3 { get; set; }
        public string AddrLine4 { get; set; }
        public int? LocnId { get; set; }
        public string ShortName { get; set; }
        public int? EmpSlno { get; set; }
        public string Status { get; set; }
        public DateTime? EntryStamp { get; set; }
        public string EnteredBy { get; set; }
        public int? OfficeStartTimeHh { get; set; }
        public int? OfficeStartTimeMm { get; set; }
        public int? OfficeEndTimeHh { get; set; }
        public int? OfficeEndTimeMm { get; set; }
    }
}
