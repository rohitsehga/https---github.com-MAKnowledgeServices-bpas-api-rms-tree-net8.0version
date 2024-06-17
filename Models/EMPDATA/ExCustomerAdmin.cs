using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.EMPDATA
{
    public partial class ExCustomerAdmin
    {
        public short IplanCustid { get; set; }
        public string IplanCustomername { get; set; }
        public string IpLanPersonlOgin { get; set; }
        public DateTime Entrystamp { get; set; }
        public string Status { get; set; }
        public string UserLognId { get; set; }
        public string EntryAccess { get; set; }
        public string ViewAccess { get; set; }
        public string ReportAccess { get; set; }
        public string LoginRequired { get; set; }
        public string IsAdmin { get; set; }
        public string IsApprover { get; set; }
        public string IsTrajanAdmin { get; set; }
        public string IsFicAdmin { get; set; }
        public string IsQntsAdmin { get; set; }
        public string IsBdadmin { get; set; }
        public string IsEquitAdmin { get; set; }
        public string IsEdtlAdmin { get; set; }
        public string IsCompAdmin { get; set; }
        public string IsPtadmin { get; set; }
        public int? ModuleName { get; set; }
        public string Comments { get; set; }
        public int? Locn { get; set; }
        public string IsSuperAdmin { get; set; }
        public string IsDeptAdmin { get; set; }
        public string IsDeptIt { get; set; }
        public string IsDeptHr { get; set; }
        public string IsDeptFinance { get; set; }
        public string IsDeptSubs { get; set; }
        public string IsDeptMpm { get; set; }
        public string IsDeptTkm { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
        public string LastUpdatedBy { get; set; }
    }
}
