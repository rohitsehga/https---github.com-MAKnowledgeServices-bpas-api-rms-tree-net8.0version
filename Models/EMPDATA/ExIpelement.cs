using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.EMPDATA
{
    public partial class ExIpelement
    {
        public string ElCode { get; set; }
        public string CaCode { get; set; }
        public string ElName { get; set; }
        public string ElArch { get; set; }
        public string ExtnElname { get; set; }
        public string Deptcode { get; set; }
        public string Loginid { get; set; }
        public DateTime? Entrystamp { get; set; }
        public string Lastupdatedby { get; set; }
        public DateTime? Lastupdatedon { get; set; }
        public string RoleInd { get; set; }
    }
}
