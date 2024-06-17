using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.EMPDATA
{
    public partial class ExIPcategoryLevel
    {
        public string CaCode { get; set; }
        public string CaValu { get; set; }
        public int? CaLevel { get; set; }
        public DateTime? Entrystamp { get; set; }
        public string Status { get; set; }
        public string EnteredBy { get; set; }
        public int? OrderBy { get; set; }
    }
}
