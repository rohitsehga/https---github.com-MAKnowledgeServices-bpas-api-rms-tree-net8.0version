using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExIpcustomerUnbilledReason
    {
        public string PeLogn { get; set; }
        public int SubreasonSl { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime? Enddate { get; set; }
        public string NofUnderDelLead { get; set; }
        public string ClientNameReason { get; set; }
        public string DateOfAllocReserv { get; set; }
        public string ExpBillStartdt { get; set; }
        public string IsDealSigned { get; set; }
        public string Skillset { get; set; }
        public string Status { get; set; }
        public string Comments { get; set; }
        public DateTime Entrystamp { get; set; }
        public string Userlognid { get; set; }
        public DateTime? EnddateStamp { get; set; }
        public string EnddateUserlognid { get; set; }
    }
}
