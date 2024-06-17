using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.EMPDATA
{
    public partial class ExReportingmanagerAsOn23Nov2021
    {
        public int? CuIden { get; set; }
        public int? ProjId { get; set; }
        public string Group { get; set; }
        public string Valognid { get; set; }
        public string Mngrlognid { get; set; }
        public DateTime? KickOff { get; set; }
        public DateTime? DateOfMove { get; set; }
        public DateTime? Startdt { get; set; }
        public DateTime? Enddate { get; set; }
        public DateTime? Entrystamp { get; set; }
        public string Userlognid { get; set; }
        public string Status { get; set; }
        public int? Type { get; set; }
        public DateTime? EnddateStamp { get; set; }
        public string EnddateUserlognid { get; set; }
    }
}
