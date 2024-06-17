using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExIppersonExitProcess
    {
        public int? Id { get; set; }
        public string PeLogn { get; set; }
        public DateTime? Resignationsubmitdate { get; set; }
        public int? Quitreason { get; set; }
        public DateTime? Expectedrelivingdate { get; set; }
        public string Managercomments { get; set; }
        public int? Managerstatus { get; set; }
        public string Hrcomments { get; set; }
        public int? Hrstatus { get; set; }
        public DateTime? Lastworkingday { get; set; }
        public string PeLmgr { get; set; }
        public DateTime? Entrystamp { get; set; }
        public string Usrlognid { get; set; }
    }
}
