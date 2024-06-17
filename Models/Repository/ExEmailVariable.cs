using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExEmailVariable
    {
        public int Variableid { get; set; }
        public string Variablename { get; set; }
        public bool IsActive { get; set; }
        public bool IsEnabled { get; set; }
        public string Creby { get; set; }
        public DateTime Credate { get; set; }
        public string Updby { get; set; }
        public DateTime? Upddate { get; set; }
        public string Variabledesc { get; set; }
    }
}
