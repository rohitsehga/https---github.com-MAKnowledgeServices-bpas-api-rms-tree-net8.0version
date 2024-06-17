using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExIpcategorySalaryBand
    {
        public string CaCode { get; set; }
        public string CaValu { get; set; }
        public int? CaSalaryband { get; set; }
        public DateTime? Startdate { get; set; }
        public DateTime? Enddate { get; set; }
        public string Status { get; set; }
        public DateTime? Entrystamp { get; set; }
        public string EnteredBy { get; set; }
        public DateTime? EnddateStamp { get; set; }
        public string EndUserlognid { get; set; }
    }
}
