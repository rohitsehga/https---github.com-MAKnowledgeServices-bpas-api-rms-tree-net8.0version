using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExUnbilledMaster
    {
        public int SubreasonSl { get; set; }
        public string SubreasonDesc { get; set; }
        public string SubreasonComments { get; set; }
        public DateTime? Entrystamp { get; set; }
        public string Userlognid { get; set; }
        public DateTime? EnddateStamp { get; set; }
        public string EnddateUserlognid { get; set; }
        public string Status { get; set; }
    }
}
