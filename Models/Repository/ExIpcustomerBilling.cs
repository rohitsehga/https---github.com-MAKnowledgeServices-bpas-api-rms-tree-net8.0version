using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExIpcustomerBilling
    {
        public int? Sl { get; set; }
        public int CuIden { get; set; }
        public int? ProjId { get; set; }
        public string PeLogn { get; set; }
        public string Group { get; set; }
        public string Jobrefno { get; set; }
        public string BillingRole { get; set; }
        public int? BillcatId { get; set; }
        public decimal? BillingRate { get; set; }
        public DateTime KickOff { get; set; }
        public DateTime? DateOfMove { get; set; }
        public DateTime BillStartdt { get; set; }
        public DateTime? BillEnddate { get; set; }
        public string Status { get; set; }
        public DateTime Entrystamp { get; set; }
        public string Userlognid { get; set; }
    }
}
