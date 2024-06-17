using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExCsatHelpdesk
    {
        public int? ReqId { get; set; }
        public int? CuIden { get; set; }
        public string Clientanal { get; set; }
        public string Sector { get; set; }
        public DateTime? ReviewFrom { get; set; }
        public DateTime? ReviewTo { get; set; }
        public string Skillset { get; set; }
        public string Benefitarea { get; set; }
        public string Status { get; set; }
        public string Userlognid { get; set; }
        public DateTime? Entrystamp { get; set; }
        public string ReqAttendedLogn { get; set; }
        public DateTime? ReqAttendedEntrystamp { get; set; }
    }
}
