using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class MailLog
    {
        public string Modu { get; set; }
        public string Approval { get; set; }
        public string MailSub { get; set; }
        public string MailBody { get; set; }
        public string MailFrom { get; set; }
        public string MailTo { get; set; }
        public string MailCc { get; set; }
        public string Status { get; set; }
        public string Exception { get; set; }
        public DateTime? Entrystamp { get; set; }
        public string PeLogn { get; set; }
    }
}
