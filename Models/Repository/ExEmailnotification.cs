using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExEmailnotification
    {
        public int Moduleid { get; set; }
        public string Modulename { get; set; }
        public int? CuIden { get; set; }
        public string CuCode { get; set; }
        public string Dept { get; set; }
        public int? Location { get; set; }
        public string Tomailid { get; set; }
        public string Ccmailid { get; set; }
        public DateTime? Entrystamp { get; set; }
        public string Userlognid { get; set; }
        public string Status { get; set; }
        public string Bccmailid { get; set; }
    }
}
