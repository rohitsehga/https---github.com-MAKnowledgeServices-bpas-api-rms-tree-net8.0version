using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExResourceroleskill
    {
        public int Id { get; set; }
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
        public string Type { get; set; }
        public string EvaluationMethod { get; set; }
        public string Tdaconfirm { get; set; }
        public string TdaconfirmedBy { get; set; }
        public DateTime? TdaconfirmedOn { get; set; }
        public string ConfirmedBy { get; set; }
        public DateTime? ConfirmedOn { get; set; }
    }
}
