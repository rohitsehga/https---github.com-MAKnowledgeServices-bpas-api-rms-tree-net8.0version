using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class PromotionNomination
    {
        public string PromotionType { get; set; }
        public string PeLogn { get; set; }
        public string PeDesg { get; set; }
        public string PeDept { get; set; }
        public string PeSbt { get; set; }
        public DateTime? SbtStartdate { get; set; }
        public DateTime? NominationDate { get; set; }
        public string NominationStatus { get; set; }
        public string Userlognid { get; set; }
        public DateTime? Entrystamp { get; set; }
        public string FinalStatus { get; set; }
        public string FinalComments { get; set; }
    }
}
