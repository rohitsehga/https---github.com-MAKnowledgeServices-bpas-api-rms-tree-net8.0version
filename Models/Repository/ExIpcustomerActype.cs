using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExIpcustomerActype
    {
        public int CuIden { get; set; }
        public string CuAccountType { get; set; }
        public DateTime CuFromdate { get; set; }
        public DateTime? CuTodate { get; set; }
        public DateTime Entrystamp { get; set; }
        public string Status { get; set; }
        public string WinLoginid { get; set; }
    }
}
