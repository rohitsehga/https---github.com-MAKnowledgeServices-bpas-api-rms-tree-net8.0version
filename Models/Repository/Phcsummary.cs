using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class Phcsummary
    {
        public DateTime? Date { get; set; }
        public string PeLogn { get; set; }
        public int? CuIden { get; set; }
        public int? ProjId { get; set; }
        public string Group { get; set; }
        public string Role { get; set; }
        public DateTime? KickOff { get; set; }
        public DateTime? DateOfMove { get; set; }
        public DateTime? Startdate { get; set; }
        public DateTime? Enddate { get; set; }
        public DateTime? Billstart { get; set; }
        public DateTime? Billend { get; set; }
        public decimal? Allocation { get; set; }
        public string Status { get; set; }
        public int? StatusLvlId { get; set; }
        public string Currentstatus { get; set; }
        public string Onboardreason { get; set; }
        public string Offboardreason { get; set; }
        public int? PeLocn { get; set; }
        public string Finalstatus { get; set; }
        public DateTime? Entrystamp { get; set; }
        public decimal? Billpercent { get; set; }
    }
}
