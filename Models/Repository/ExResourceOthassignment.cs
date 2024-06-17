using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExResourceOthassignment
    {
        public string PeLogn { get; set; }
        public int? CuIden { get; set; }
        public DateTime? Assigndate { get; set; }
        public string Assignto { get; set; }
        public string Comments { get; set; }
        public string Status { get; set; }
        public DateTime? Entrystamp { get; set; }
        public string Userlognid { get; set; }
    }
}
