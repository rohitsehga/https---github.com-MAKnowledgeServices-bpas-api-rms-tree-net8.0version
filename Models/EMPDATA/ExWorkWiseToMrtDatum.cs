using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.EMPDATA
{
    public partial class ExWorkWiseToMrtDatum
    {
        public int Id { get; set; }
        public string PeEmid { get; set; }
        public string PeName { get; set; }
        public string CcName { get; set; }
        public string PeJoin { get; set; }
        public string PeQuit { get; set; }
        public string PeLocn { get; set; }
        public string PeDesg { get; set; }
        public string PeMail { get; set; }
        public string PeDept { get; set; }
        public string StartDate { get; set; }
        public string OvBrdt { get; set; }
        public string OvMale { get; set; }
        public string OvSngl { get; set; }
        public string OvNatl { get; set; }
        public string OvSsno { get; set; }
        public string PeLmgr { get; set; }
        public string WorkType { get; set; }
        public string EmploymentType { get; set; }
        public string OvPad1 { get; set; }
        public string OvPad2 { get; set; }
        public string OvPad3 { get; set; }
        public string OvPcit { get; set; }
        public string OvPsta { get; set; }
        public string OvPcnt { get; set; }
        public string OvPpin { get; set; }
        public string EffectiveDate { get; set; }
        public DateTime? TriggeredStamp { get; set; }
        public string TriggeredStatus { get; set; }
        public string IsError { get; set; }
        public string ErrorDescription { get; set; }
        public string FileName { get; set; }
        public string EventName { get; set; }
    }
}
