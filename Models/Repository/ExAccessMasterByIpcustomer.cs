using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExAccessMasterByIpcustomer
    {
        public string PeLogn { get; set; }
        public int CuIden { get; set; }
        public string ServiceLine { get; set; }
        public int? Admin { get; set; }
        public int? Approver { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime? Enddate { get; set; }
        public string Status { get; set; }
        public DateTime Entrystamp { get; set; }
        public string Userlognid { get; set; }
        public DateTime? EnddateEntrystamp { get; set; }
        public string EnddateUserlognid { get; set; }
    }
}
