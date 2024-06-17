using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class RfpDquesresp
    {
        public decimal Id { get; set; }
        public decimal QuesId { get; set; }
        public string Response { get; set; }
        public string RespHtml { get; set; }
        public string RespSfdt { get; set; }
        public decimal? AttachId { get; set; }
        public bool IsActive { get; set; }
        public int ResStatus { get; set; }
        public string CreBy { get; set; }
        public DateTimeOffset CreDate { get; set; }
        public string UpdBy { get; set; }
        public DateTimeOffset UpdDate { get; set; }
        public int SecId { get; set; }
        public bool? IsEncrypted { get; set; }
    }
}
