using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExIpcustomerProject
    {
        public int Sl { get; set; }
        public int? CuIden { get; set; }
        public int ProjId { get; set; }
        public string ProjName { get; set; }
        public string Group { get; set; }
        public DateTime? Startdt { get; set; }
        public DateTime? Enddate { get; set; }
        public string Status { get; set; }
        public DateTime? Entrystamp { get; set; }
        public string Userlognid { get; set; }
        public DateTime? EnddateStamp { get; set; }
        public string EnddateUserlognid { get; set; }
    }
}
