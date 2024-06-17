using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExClientConfiguration
    {
        public int? CuIden { get; set; }
        public string ElCode { get; set; }
        public string IsCompliacneMandatory { get; set; }
        public string IsComplianceAutoApprove { get; set; }
        public string IsFinanceMandatory { get; set; }
        public string IsFinanceAutoApprove { get; set; }
        public string IsBgcmandatory { get; set; }
        public string IsDrugTestMandatory { get; set; }
        public string IsIdentityTestMandatory { get; set; }
        public string IsSowmandatory { get; set; }
        public string IsTimeSheetReq { get; set; }
        public string IsAcuityDriveReq { get; set; }
        public string IsVdireq { get; set; }
    }
}
