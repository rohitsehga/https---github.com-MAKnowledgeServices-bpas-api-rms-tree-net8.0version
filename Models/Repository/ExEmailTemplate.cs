using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExEmailTemplate
    {
        public decimal Templateid { get; set; }
        public string Templatename { get; set; }
        public string Templatesubject { get; set; }
        public string Templatebody { get; set; }
        public string Creby { get; set; }
        public DateTime? Credate { get; set; }
        public string Updby { get; set; }
        public DateTime? Upddate { get; set; }
        public bool? Isactive { get; set; }
        public bool? IsEnabled { get; set; }
        public string Templatedesc { get; set; }
    }
}
