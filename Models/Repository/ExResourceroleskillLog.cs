using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExResourceroleskillLog
    {
        public int? Sl { get; set; }
        public string MgrPelogn { get; set; }
        public string PeLogn { get; set; }
        public DateTime? RatingFromdt { get; set; }
        public DateTime? RatingTodate { get; set; }
        public string Skilltype { get; set; }
        public string ElCode { get; set; }
        public string CaCode { get; set; }
        public string Rating { get; set; }
        public string Comments { get; set; }
        public DateTime? Entrystamp { get; set; }
        public string Userlognid { get; set; }
        public string Status { get; set; }
        public int? CuIden { get; set; }
        public string Ambarole { get; set; }
        public DateTime? Logentrystamp { get; set; }
        public string Logenteredby { get; set; }
        public string Type { get; set; }
    }
}
