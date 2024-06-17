using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExIpcustomerCancellation
    {
        public int Sl { get; set; }
        public int CuIden { get; set; }
        public string CuCode { get; set; }
        public int? ProjId { get; set; }
        public string Grp { get; set; }
        public DateTime? KickOff { get; set; }
        public string CancellationType { get; set; }
        public DateTime? CancelledDate { get; set; }
        public string SentBy { get; set; }
        public string PeLogn { get; set; }
        public string Role { get; set; }
        public string MngrLogn { get; set; }
        public DateTime? BillingEnddate { get; set; }
        public string Userlognid { get; set; }
        public string Status { get; set; }
        public DateTime? Entrystamp { get; set; }
        public string Comments { get; set; }
        public string CdhStatus { get; set; }
        public string CdhHindsight { get; set; }
        public string CdhDetailreason { get; set; }
        public string CdhCancelreason { get; set; }
        public string CdhOffbrdreason { get; set; }
        public string CdhUserlogn { get; set; }
        public string AcmngrLogn { get; set; }
        public string CheadLogn { get; set; }
        public DateTime? CdhEntrystamp { get; set; }
        public string Approvedby { get; set; }
        public DateTime? Approvedon { get; set; }
    }
}
