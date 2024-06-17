using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExResourcerolestatus
    {
        public string PeLogn { get; set; }
        public int? CuIden { get; set; }
        public string Role { get; set; }
        public DateTime? Startdate { get; set; }
        public DateTime? Enddate { get; set; }
        public string Status { get; set; }
        public DateTime? Entrystamp { get; set; }
        public string ApproveStatus { get; set; }
        public string Type { get; set; }
        public string Userloginid { get; set; }
        public string EvaluationMethod { get; set; }
        public string Tdaconfirm { get; set; }
        public string TdaconfirmedBy { get; set; }
        public DateTime? TdaConfirmedOn { get; set; }
        public string ConfirmedBy { get; set; }
        public DateTime? ConfirmedOn { get; set; }
        public string Comments { get; set; }
    }
}
