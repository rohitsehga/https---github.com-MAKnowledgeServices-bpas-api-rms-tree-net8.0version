using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExResourceresume
    {
        public string PeLogn { get; set; }
        public int? Sl { get; set; }
        public string EditorialCvFoldername { get; set; }
        public string OriginalCvFoldername { get; set; }
        public DateTime? Entrystamp { get; set; }
        public string Userlognid { get; set; }
    }
}
