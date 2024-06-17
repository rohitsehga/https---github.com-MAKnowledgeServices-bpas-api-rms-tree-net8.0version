using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExUtilizationMaster
    {
        public DateTime? Date { get; set; }
        public string PeLogn { get; set; }
        public int? CuIden { get; set; }
        public int? ProjId { get; set; }
        public string Group { get; set; }
        public string Role { get; set; }
        public DateTime? KickOff { get; set; }
        public DateTime? DateOfMove { get; set; }
        public decimal? Workingdays { get; set; }
        public decimal? LeaveCount { get; set; }
        public decimal? HolidayCount { get; set; }
        public decimal? BillHrs { get; set; }
        public decimal? NonbillHrs { get; set; }
        public decimal? ExpectedHrs { get; set; }
        public decimal? Utilization { get; set; }
        public DateTime? Entrystamp { get; set; }
        public decimal? Noeffort { get; set; }
    }
}
