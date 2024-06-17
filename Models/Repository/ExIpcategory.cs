using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExIpcategory
    {
        public string CaCode { get; set; }
        public string CaValu { get; set; }
        public string CaName { get; set; }
        public short? CaOrdr { get; set; }
        public string CaArch { get; set; }
        public string JobCode { get; set; }
        public string Lob { get; set; }
        public string Userlognid { get; set; }
        public DateTime? Entrystamp { get; set; }
        public string Lastupdatedby { get; set; }
        public DateTime? Lastupdatedon { get; set; }
    }
}
